using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using USE_States;
using USE_Settings;
using USE_ExperimenterDisplay;
using USE_ExperimentTemplate_Classes;
using USE_ExperimentTemplate_Data;
using USE_ExperimentTemplate_Task;
using USE_ExperimentTemplate_Trial;

namespace USE_ExperimentTemplate_Session
{
    public class ControlLevel_Session_Template : ControlLevel
    {
        protected SessionData SessionData;
        private SessionDataControllers SessionDataControllers;
        private bool StoreData;
        [HideInInspector] public string SubjectID, SessionID, SessionDataPath, FilePrefix;

        public string TaskSelectionSceneName;

        // protected Dictionary<string, ControlLevel_Task_Template> ActiveTaskLevels;
        // private Dictionary<string, Type> ActiveTaskTypes = new Dictionary<string, Type>();
        protected List<ControlLevel_Task_Template> ActiveTaskLevels;
        private ControlLevel_Task_Template CurrentTask;
        // public List<ControlLevel_Task_Template> AvailableTaskLevels;
        private OrderedDictionary TaskMappings;
        private string ContextName;
        private string ContextExternalFilePath;
        private string TaskIconsFolderPath;
        private Dictionary<string, string> TaskIcons;
        protected int taskCount;
        private float TaskSelectionTimeout;

        //For Loading config information
        public SessionDetails SessionDetails;
        public LocateFile LocateFile;

        private SerialPortThreaded SerialPortController;
        private SyncBoxController SyncBoxController;
        private EventCodeManager EventCodeManager;

        private Camera SessionCam;
        public DisplaySwitcher DisplaySwitcher;
        private ExperimenterDisplayController ExperimenterDisplayController;
        [HideInInspector] public RenderTexture CameraMirrorTexture;

        private string configFileFolder;
        private bool TaskSceneLoaded, SceneLoading;

        private bool SerialPortActive, SyncBoxActive, EventCodesActive, RewardPulsesActive, SonicationActive;
        private string EyetrackerType;
        private Dictionary<string, EventCode> SessionEventCodes;

        public override void LoadSettings()
        {
            //load session config file
            configFileFolder = LocateFile.GetPath("Config File Folder");
            SubjectID = SessionDetails.GetItemValue("SubjectID");
            SessionID = SessionDetails.GetItemValue("SessionID");
            FilePrefix = "Subject_" + SubjectID + "__Session_" + SessionID + "__" +
                         DateTime.Today.ToString("dd_MM_yyyy") + "__" + DateTime.Now.ToString("HH_mm_ss");
            SessionSettings.ImportSettings_MultipleType("Session",
                LocateFile.FindFileInFolder(configFileFolder, "*SessionConfig*"));


            if (SessionSettings.SettingExists("Session", "SyncBoxActive"))
                SyncBoxActive = (bool)SessionSettings.Get("Session", "SyncBoxActive");
            else
                SyncBoxActive = false;

            if (SessionSettings.SettingExists("Session", "EventCodesActive"))
                EventCodesActive = (bool)SessionSettings.Get("Session", "EventCodesActive");
            else
                EventCodesActive = false;

            if (SessionSettings.SettingExists("Session", "RewardPulsesActive"))
                RewardPulsesActive = (bool)SessionSettings.Get("Session", "RewardPulsesActive");
            else
                RewardPulsesActive = false;

            if (SessionSettings.SettingExists("Session", "SonicationActive"))
                SonicationActive = (bool)SessionSettings.Get("Session", "SonicationActive");
            else
                SonicationActive = false;

            // if (EventCodesActive || RewardPulsesActive || SonicationActive)
            // 	SyncBoxActive = true;

            //if there is a single syncbox config file for all experiments, load it
            string syncBoxFileString =
                    LocateFile.FindFileInFolder(configFileFolder, "*SyncBox*");
            if (!string.IsNullOrEmpty(syncBoxFileString))
            {
                SessionSettings.ImportSettings_MultipleType("SyncBoxConfig", syncBoxFileString);
                // SyncBoxActive = true;
            }

            //if there is a single event code config file for all experiments, load it
            string eventCodeFileString =
                LocateFile.FindFileInFolder(configFileFolder, "*EventCode*");
            if (!string.IsNullOrEmpty(eventCodeFileString))
            {
                SessionSettings.ImportSettings_SingleTypeJSON<Dictionary<string, EventCode>>("EventCodeConfig", eventCodeFileString);
                SessionEventCodes = (Dictionary<string, EventCode>)SessionSettings.Get("EventCodeConfig");
                // EventCodesActive = true;
            }
            else if (EventCodesActive)
                Debug.LogWarning("EventCodesActive variable set to true in Session Config file but no session level event codes file is given.");

            if (SyncBoxActive)
                SerialPortActive = true;

            // if (EventCodesActive)
            // {
            // 	SerialPortActive = true;
            // 	SyncBoxActive = true;
            // }


            List<string> taskNames;
            if (SessionSettings.SettingExists("Session", "TaskNames"))
            {
                taskNames = (List<string>)SessionSettings.Get("Session", "TaskNames");
                TaskMappings = new OrderedDictionary();
                taskNames.ForEach((taskName) => TaskMappings.Add(taskName, taskName));
            }
            else if (SessionSettings.SettingExists("Session", "TaskMappings"))
            {
                TaskMappings = (OrderedDictionary)SessionSettings.Get("Session", "TaskMappings");
            }
            else if (TaskMappings.Count == 0)
            {
                Debug.LogError("No task names or task mappings specified in Session config file or by other means.");
            }

            if (SessionSettings.SettingExists("Session", "ContextExternalFilePath"))
                ContextExternalFilePath = (string)SessionSettings.Get("Session", "ContextExternalFilePath");

            if (SessionSettings.SettingExists("Session", "TaskIconsFolderPath"))
                TaskIconsFolderPath = (string)SessionSettings.Get("Session", "TaskIconsFolderPath");

            if (SessionSettings.SettingExists("Session", "ContextName"))
                ContextName = (string)SessionSettings.Get("Session", "ContextName");

            if (SessionSettings.SettingExists("Session", "TaskIcons"))
                TaskIcons = (Dictionary<string, string>)SessionSettings.Get("Session", "TaskIcons");

            if (SessionSettings.SettingExists("Session", "StoreData"))
                StoreData = (bool)SessionSettings.Get("Session", "StoreData");

            if (SessionSettings.SettingExists("Session", "TaskSelectionTimeout"))
                TaskSelectionTimeout = (float)SessionSettings.Get("Session", "TaskSelectionTimeout");


            if (SessionSettings.SettingExists("Session", "SerialPortActive"))
                SerialPortActive = (bool)SessionSettings.Get("Session", "SerialPortActive");

            SessionDataPath = LocateFile.GetPath("Data Folder") + Path.DirectorySeparatorChar + FilePrefix;

            if (SessionSettings.SettingExists("Session", "ToggleDisplay"))
                if ((bool)SessionSettings.Get("Session", "ToggleDisplay"))
                    DisplaySwitcher.ToggleDisplay();
        }

        public override void DefineControlLevel()
        {
            //DontDestroyOnLoad(gameObject);
            State setupSession = new State("SetupSession");
            State selectTask = new State("SelectTask");
            State loadTask = new State("LoadTask");
            State runTask = new State("RunTask");
            State finishSession = new State("FinishSession");
            AddActiveStates(new List<State> { setupSession, selectTask, loadTask, runTask, finishSession });

            SessionDataControllers = new SessionDataControllers(GameObject.Find("DataControllers"));
            ActiveTaskLevels = new List<ControlLevel_Task_Template>();//new Dictionary<string, ControlLevel_Task_Template>();

            SessionCam = Camera.main;


            GameObject experimenterDisplay = Instantiate(Resources.Load<GameObject>("Default_ExperimenterDisplay"));
            experimenterDisplay.name = "ExperimenterDisplay";
            ExperimenterDisplayController = experimenterDisplay.AddComponent<ExperimenterDisplayController>();
            experimenterDisplay.AddComponent<PreserveObject>();
            ExperimenterDisplayController.InitializeExperimenterDisplay(this);

            GameObject cameraObj = new GameObject("MirrorCamera");
            cameraObj.transform.SetParent(experimenterDisplay.transform);
            Camera mirrorCamera = cameraObj.AddComponent<Camera>();
            mirrorCamera.CopyFrom(Camera.main);
            mirrorCamera.cullingMask = 0;
            // mirrorCamera.targetDisplay = 2;

            RawImage mainCameraCopy = GameObject.Find("MainCameraCopy").GetComponent<RawImage>();

            bool waitForSerialPort = false;
            setupSession.AddDefaultInitializationMethod(() =>
            {
                SessionData.CreateFile();
                EventCodeManager = GameObject.Find("MiscScripts").GetComponent<EventCodeManager>(); //new EventCodeManager();
                if (SerialPortActive)
                {
                    SerialPortController = new SerialPortThreaded();
                    if (SyncBoxActive)
                    {
                        SyncBoxController = new SyncBoxController();
                        SyncBoxController.serialPortController = SerialPortController;
                    }

                    if (EventCodesActive)
                    {
                        EventCodeManager.SyncBoxController = SyncBoxController;
                        EventCodeManager.codesActive = true;
                    }
                    waitForSerialPort = true;
                    if (SessionSettings.SettingExists("Session", "SerialPortAddress"))
                        SerialPortController.SerialPortAddress =
                            (string)SessionSettings.Get("Session", "SerialPortAddress");
                    else if (SessionSettings.SettingClassExists("SyncBoxConfig"))
                    {
                        if (SessionSettings.SettingExists("SyncBoxConfig", "SerialPortAddress"))
                            SerialPortController.SerialPortAddress =
                                (string)SessionSettings.Get("SyncBoxConfig", "SerialPortAddress");
                    }

                    if (SessionSettings.SettingExists("Session", "SerialPortSpeed"))
                        SerialPortController.SerialPortSpeed =
                            (int)SessionSettings.Get("Session", "SerialPortSpeed");
                    else if (SessionSettings.SettingClassExists("SyncBoxConfig"))
                    {
                        if (SessionSettings.SettingExists("SyncBoxConfig", "SerialPortSpeed"))
                            SerialPortController.SerialPortSpeed =
                                (int)SessionSettings.Get("SyncBoxConfig", "SerialPortSpeed");
                    }

                    SerialPortController.Initialize();
                }
            });

            int iTask = 0;
            SceneLoading = false;
            string taskName = "";
            AsyncOperation loadScene = null;
            setupSession.AddUpdateMethod(() =>
            {
                if (waitForSerialPort && Time.time - StartTimeAbsolute > SerialPortController.initTimeout / 1000 + 0.5f)
                    waitForSerialPort = false;

                if (iTask < TaskMappings.Count)
                {
                    if (!SceneLoading)
                    {
                        //AsyncOperation loadScene;
                        SceneLoading = true;
                        taskName = (string)TaskMappings[iTask];
                        loadScene = SceneManager.LoadSceneAsync(taskName, LoadSceneMode.Additive);
                        // Unload it after memory because this loads the assets into memory but destroys the objects
                        loadScene.completed += (_) =>
                        {
                            SceneManager.UnloadSceneAsync(taskName);
                            SceneLoading = false;
                            iTask++;
                        };
                    }
                }
            });
            setupSession.SpecifyTermination(() => iTask >= TaskMappings.Count && !waitForSerialPort, selectTask,
                () =>
                {
                    if (SyncBoxActive)
                        if (SessionSettings.SettingClassExists("SyncBoxConfig"))
                            if (SessionSettings.SettingExists("SyncBoxConfig", "SyncBoxInitCommands"))
                                SyncBoxController.SendCommand((List<string>)SessionSettings.Get("SyncBoxConfig", "syncBoxInitCommands"));
                    SessionSettings.Save();
                });

            bool tasksFinished = false;
            GameObject taskButtons = null;
            Dictionary<string, GameObject> taskButtonsDict = new Dictionary<string, GameObject>();
            string selectedConfigName = null;
            selectTask.AddUniversalInitializationMethod(() =>
            {
                RenderSettings.skybox = ControlLevel_Trial_Template.CreateSkybox(ContextExternalFilePath + "/" + ContextName + ".png");
                SessionSettings.Restore();
                selectedConfigName = null;

                SessionCam.gameObject.SetActive(true);
                CameraMirrorTexture = new RenderTexture(Screen.width, Screen.height, 24);
                CameraMirrorTexture.Create();
                Camera.main.targetTexture = CameraMirrorTexture;
                mainCameraCopy.texture = CameraMirrorTexture;

                SceneLoading = true;
                if (taskCount >= TaskMappings.Count)
                {
                    tasksFinished = true;
                    return;
                }

                if (taskButtons != null)
                {
                    taskButtons.SetActive(true);
                    return;
                }
                taskButtons = new GameObject("TaskButtons");
                taskButtons.transform.parent = GameObject.Find("TaskSelectionCanvas").transform;
                taskButtons.transform.localPosition = Vector3.zero;
                taskButtons.transform.localScale = Vector3.one;
                // We'll use height for the calculations because it is generally smaller than the width
                int numTasks = TaskMappings.Count;
                float buttonSize = 200;
                float buttonSpacing = 20;
                float buttonsWidth = numTasks * buttonSize + (numTasks - 1) * buttonSpacing;
                float buttonStart = (buttonSize - buttonsWidth) / 2;
                foreach (DictionaryEntry task in TaskMappings)
                {
                    string configName = (string)task.Key;
                    string taskName = (string)task.Value;

                    string taskFolder = GetConfigFolderPath(configName);
                    if (!Directory.Exists(taskFolder))
                    {
                        Destroy(taskButtons);
                        throw new DirectoryNotFoundException($"Task folder for '{configName}' at '{taskFolder}' does not exist.");
                    }

                    GameObject taskButton = new GameObject(configName + "Button");
                    taskButtonsDict.Add(configName, taskButton);
                    taskButton.transform.parent = taskButtons.transform;

                    RawImage image = taskButton.AddComponent<RawImage>();
                    string taskIcon = TaskIcons[configName];
                    image.texture = ControlLevel_Trial_Template.LoadPNG(TaskIconsFolderPath + "/" + taskIcon + ".png");
                    image.rectTransform.localPosition = new Vector3(buttonStart, 0.0f, 0.0f);
                    image.rectTransform.localScale = Vector3.one;
                    image.rectTransform.sizeDelta = buttonSize * Vector3.one;
                    buttonStart += buttonSize + buttonSpacing;

                    Button button = taskButton.AddComponent<Button>();
                    button.onClick.AddListener(() => selectedConfigName = configName);
                }
            });
            selectTask.SpecifyTermination(() => selectedConfigName != null, loadTask);
            if (TaskSelectionTimeout >= 0)
            {
                selectTask.AddTimer(TaskSelectionTimeout, loadTask, () =>
                {
                    foreach (DictionaryEntry task in TaskMappings)
                    {
                        string configName = (string)task.Key;
                        string taskName = (string)task.Value;
                        GameObject taskButton = taskButtonsDict[configName];

                        if (taskButton.GetComponent<Button>() == null) continue;
                        selectedConfigName = configName;
                        break;
                    }
                });
            }
            selectTask.SpecifyTermination(() => tasksFinished, finishSession);

            loadTask.AddInitializationMethod(() =>
            {
                taskButtons.SetActive(false);
                GameObject taskButton = taskButtonsDict[selectedConfigName];
                RawImage image = taskButton.GetComponent<RawImage>();
                Button button = taskButton.GetComponent<Button>();
                image.color = Color.gray;
                Destroy(button);

                string taskName = (string)TaskMappings[selectedConfigName];
                loadScene = SceneManager.LoadSceneAsync(taskName, LoadSceneMode.Additive);
                loadScene.completed += (_) =>
                {
                    SceneLoaded(selectedConfigName);
                    CurrentTask = ActiveTaskLevels.Find((task) => task.ConfigName == selectedConfigName);
                };
            });
            loadTask.SpecifyTermination(() => !SceneLoading, runTask, () =>
            {
                runTask.AddChildLevel(CurrentTask);
                CameraMirrorTexture.Release();
                SessionCam.gameObject.SetActive(false);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(CurrentTask.TaskName));
                ExperimenterDisplayController.ResetTask(CurrentTask, CurrentTask.TrialLevel);
            });

            //automatically finish tasks after running one - placeholder for proper selection
            //runTask.AddLateUpdateMethod
            runTask.AddUniversalInitializationMethod(() =>
            {
                CameraMirrorTexture = new RenderTexture(Screen.width, Screen.height, 24);
                CameraMirrorTexture.Create();
                CurrentTask.TaskCam.targetTexture = CameraMirrorTexture;
                mainCameraCopy.texture = CameraMirrorTexture;
                // mirrorCamera.CopyFrom(CurrentTask.TaskCam);
                // mirrorCamera.cullingMask = 0;
            });

            if (EventCodesActive)
            {
                runTask.AddFixedUpdateMethod(() => EventCodeManager.EventCodeFixedUpdate());
                // runTask.AddLateUpdateMethod(() => EventCodeManager.EventCodeLateUpdate());
            }
            runTask.SpecifyTermination(() => CurrentTask.Terminated, selectTask, () =>
            {
                SceneManager.UnloadSceneAsync(CurrentTask.TaskName);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(TaskSelectionSceneName));
                SessionData.AppendData();
                SessionData.WriteData();
                CameraMirrorTexture.Release();
                ExperimenterDisplayController.ResetTask(null, null);
                taskCount++;
            });

            finishSession.SpecifyTermination(() => true, () => null, () =>
            {
                SessionData.AppendData();
            });

            SessionData = SessionDataControllers.InstantiateSessionData(StoreData, SessionDataPath);
            SessionData.sessionLevel = this;
            SessionData.InitDataController();
            SessionData.ManuallyDefine();

            void GetTaskLevelFromString<T>()
                where T : ControlLevel_Task_Template
            {
                foreach (ControlLevel_Task_Template taskLevel in ActiveTaskLevels)
                    if (taskLevel.GetType() == typeof(T))
                        CurrentTask = taskLevel;
                CurrentTask = null;
            }
        }

        string GetConfigFolderPath(string configName)
        {
            if (!SessionSettings.SettingExists("Session", "ConfigFolderNames"))
                return configFileFolder + Path.DirectorySeparatorChar + configName;
            else
            {
                List<string> configFolders =
                    (List<string>)SessionSettings.Get("Session", "ConfigFolderNames");
                int index = 0;
                foreach (string k in TaskMappings.Keys)
                {
                    if (k.Equals(configName)) break;
                    ++index;
                }
                return configFileFolder + Path.DirectorySeparatorChar + configFolders[index];
            }
        }

        ControlLevel_Task_Template PopulateTaskLevel(ControlLevel_Task_Template tl)
        {
            tl.SessionDataControllers = SessionDataControllers;
            tl.LocateFile = LocateFile;
            tl.SessionDataPath = SessionDataPath;
            tl.TaskConfigPath = GetConfigFolderPath(tl.ConfigName);

            tl.FilePrefix = FilePrefix;
            tl.StoreData = StoreData;
            tl.SubjectID = SubjectID;
            tl.SessionID = SessionID;
            if (SessionSettings.SettingExists("Session", "EyetrackerType"))
                tl.EyetrackerType = (string)SessionSettings.Get("Session", "EyetrackerType");
            else
                tl.EyetrackerType = "";

            if (SessionSettings.SettingExists("Session", "SelectionType"))
                tl.SelectionType = (string)SessionSettings.Get("Session", "SelectionType");
            else
                tl.SelectionType = "";

            tl.SyncBoxActive = SyncBoxActive;
            tl.EventCodesActive = EventCodesActive;
            if (SerialPortActive)
                tl.SerialPortController = SerialPortController;
            if (SyncBoxActive)
                tl.SyncBoxController = SyncBoxController;
            // if (EventCodesActive)
            tl.EventCodeManager = EventCodeManager;

            if (SessionSettings.SettingExists("Session", "RewardPulsesActive"))
                tl.RewardPulsesActive = (bool)SessionSettings.Get("Session", "RewardPulsesActive");
            else
                tl.RewardPulsesActive = false;

            if (SessionSettings.SettingExists("Session", "SonicationActive"))
                tl.SonicationActive = (bool)SessionSettings.Get("Session", "SonicationActive");
            else
                tl.SonicationActive = false;

            tl.DefineTaskLevel();
            // ActiveTaskTypes.Add(tl.TaskName, tl.TaskLevelType);
            ActiveTaskLevels.Add(tl);
            if (tl.TaskCanvasses != null)
                foreach (GameObject go in tl.TaskCanvasses)
                    go.SetActive(false);
            return tl;
        }
        //
        // void SceneLoaded(string sceneName)
        // {
        // 	var methodInfo = GetType().GetMethod(nameof(this.FindTaskCam));
        // 	MethodInfo findTaskCam = methodInfo.MakeGenericMethod(new Type[] {ActiveTaskTypes[sceneName]});
        // 	findTaskCam.Invoke(this, new object[] {sceneName});
        // 	// TaskSceneLoaded = true;
        // 	SceneLoading = false;
        // }

        void SceneLoaded(string configName)
        {
            string taskName = (string)TaskMappings[configName];
            var methodInfo = GetType().GetMethod(nameof(this.PrepareTaskLevel));
            Type taskType = USE_Tasks_CustomTypes.CustomTaskDictionary[taskName].TaskLevelType;
            MethodInfo prepareTaskLevel = methodInfo.MakeGenericMethod(new Type[] { taskType });
            prepareTaskLevel.Invoke(this, new object[] { configName });
            // TaskSceneLoaded = true;
            SceneLoading = false;
        }

        public void PrepareTaskLevel<T>(string configName) where T : ControlLevel_Task_Template
        {
            string taskName = (string)TaskMappings[configName];
            ControlLevel_Task_Template tl = GameObject.Find(taskName + "_Scripts").GetComponent<T>();
            tl.ConfigName = configName;
            tl = PopulateTaskLevel(tl);
            if (tl.TaskCam == null)
                tl.TaskCam = GameObject.Find(taskName + "_Camera").GetComponent<Camera>();
            tl.TaskCam.gameObject.SetActive(false);
        }
        // public void FindTaskCam<T>(string taskName) where T : ControlLevel_Task_Template
        // {
        // 	ControlLevel_Task_Template tl = GameObject.Find("ControlLevels").GetComponent<T>();
        // 	tl.TaskCam = GameObject.Find(taskName + "_Camera").GetComponent<Camera>();
        // 	tl.TaskCam.gameObject.SetActive(false);
        // }

#if UNITY_STANDALONE_WIN
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct ReparseDataBuffer
        {
            public uint ReparseTag;
            public ushort ReparseDataLength;
            public ushort Reserved;
            public ushort SubstituteNameOffset;
            public ushort SubstituteNameLength;
            public ushort PrintNameOffset;
            public ushort PrintNameLength;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string PathBuffer;
        }

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode,
            IntPtr lpSecurityAttributes, uint dwCreationDispositionulong, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref ReparseDataBuffer lpInBuffer,
            uint nInBufferSize, IntPtr lpOutBuffer, uint nOutBufferSize, IntPtr lpBytesReturned, IntPtr lpOverlapped);
        [DllImport("Kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);
#endif

        void OnApplicationQuit()
        {
            //	performancetext.AppendData();
            //	performancetext.WriteData();

            //	if (exptParameters.ContextMaterials != null)
            //	{
            //		foreach (var o in exptParameters.ContextMaterials)
            //		{
            //			Resources.UnloadAsset(o);
            //		}
            //	}

            //	if (eyeTrackType == 2)
            //	{
            //		if (calibLevel.calibrationUnfinished == true)
            //			udpManager.SendString("ET###leave_calibration");
            //		udpManager.SendString("ET###unsubscribe_eyetracker");
            //	}
            //	if (eventCodeManager.codesActive)
            //	{
            //		serialPortController.ClosePort();
            //	}
            //	trialLevel.WriteTrialData();
            //	blockData.AppendData();
            //	blockData.WriteData();
            //	//WriteFrameByFrameData();
            //	if (eyeTrackType == 2)
            //	{
            //		udpManager.SendString("DATA###clear_data");
            //		udpManager.CloseUDP();
            //	}
            //	//Save EditorLog and Player Log files
            if (StoreData)
            {
                System.IO.Directory.CreateDirectory(SessionDataPath + Path.DirectorySeparatorChar + "LogFile");
                string symlinkLocation = LocateFile.GetPath("Data Folder") + Path.DirectorySeparatorChar + "LatestSession";
#if UNITY_STANDALONE_WIN
                uint GENERIC_READ = 0x80000000;
                uint GENERIC_WRITE = 0x40000000;
                uint FILE_SHARE_READ = 0x00000001;
                uint OPEN_EXISTING = 3;
                uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
                uint FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000;
                uint FSCTL_SET_REPARSE_POINT = 0x900A4;
                uint IO_REPARSE_TAG_MOUNT_POINT = 0xA0000003;
                Directory.CreateDirectory(symlinkLocation);

                // Open the file with the correct perms
                IntPtr dirHandle = CreateFile(
                    symlinkLocation,
                    GENERIC_READ | GENERIC_WRITE,
                    FILE_SHARE_READ,
                    IntPtr.Zero,
                    OPEN_EXISTING,
                    FILE_FLAG_BACKUP_SEMANTICS | FILE_FLAG_OPEN_REPARSE_POINT,
                    IntPtr.Zero
                );

                // \??\ indicates that the path should be non-interpreted
                string prefix = @"\??\";
                string substituteName = prefix + SessionDataPath;
                // char is 2 bytes because strings are UTF-16
                int substituteByteLen = substituteName.Length * sizeof(char);
                ReparseDataBuffer rdb = new ReparseDataBuffer
                {
                    ReparseTag = IO_REPARSE_TAG_MOUNT_POINT,
                    // 12 bytes is the byte length from SubstituteNameOffset to
                    // before PathBuffer
                    ReparseDataLength = (ushort)(substituteByteLen + 12),
                    SubstituteNameOffset = 0,
                    SubstituteNameLength = (ushort)substituteByteLen,
                    // Needs to be at least 2 ahead (accounting for nonexistent null-terminator)
                    PrintNameOffset = (ushort)(substituteByteLen + 2),
                    PrintNameLength = 0,
                    PathBuffer = substituteName
                };

                var result = DeviceIoControl(
                    dirHandle,
                    FSCTL_SET_REPARSE_POINT,
                    ref rdb,
                    // 20 bytes is the byte length for everything but the PathBuffer
                    (uint)(substituteName.Length * sizeof(char) + 20),
                    IntPtr.Zero,
                    0,
                    IntPtr.Zero,
                    IntPtr.Zero
                );

                CloseHandle(dirHandle);
#endif
                string logPath = "";
                if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.MacOSX |
                    SystemInfo.operatingSystemFamily == OperatingSystemFamily.Linux)
                {
                    if (Application.isEditor)
                        logPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                                  "/Library/Logs/Unity/Editor.log";
                    else
                        logPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                                  "/Library/Logs/Unity/Player.log";
                }
                else if (SystemInfo.operatingSystemFamily == OperatingSystemFamily.Windows)
                {
                    if (Application.isEditor)
                    {
                        logPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                  "\\Unity\\Editor\\Editor.log";
                    }
                    else
                    {
                        logPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low\\" +
                                  Application.companyName + "\\" + Application.productName + "\\Player.log";
                    }
                }

                if (Application.isEditor)
                    File.Copy(logPath,
                        SessionDataPath + Path.DirectorySeparatorChar + "LogFile" + Path.DirectorySeparatorChar +
                        "Editor.log");
                else
                    File.Copy(logPath,
                        SessionDataPath + Path.DirectorySeparatorChar + "LogFile" + Path.DirectorySeparatorChar +
                        "Player.log");

                System.IO.Directory.CreateDirectory(SessionDataPath + Path.DirectorySeparatorChar + "SessionSettings");

                SessionSettings.StoreSettings(SessionDataPath + Path.DirectorySeparatorChar + "SessionSettings" +
                                              Path.DirectorySeparatorChar);
            }
        }
        public void OnGUI()
        {
            if (CameraMirrorTexture == null) return;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), CameraMirrorTexture);
        }
    }

    public class SessionDef
    {
        public string Subject;
        public DateTime SessionStart_DateTime;
        public int SessionStart_Frame;
        public float SessionStart_UnityTime;
        public string SessionID;
        public bool SerialPortActive, SyncBoxActive, EventCodesActive, RewardPulsesActive, SonicationActive;
        public string EyetrackerType, SelectionType;
    }
}