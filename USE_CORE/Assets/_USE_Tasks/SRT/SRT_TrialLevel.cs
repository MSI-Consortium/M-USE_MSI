using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using USE_States;
using USE_Settings;
using USE_ExperimentTemplate_Trial;
using USE_StimulusManagement;
using SRT_Namespace;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SRT_TrialLevel : ControlLevel_Trial_Template
{
    public SRT_TrialDef CurrentTrial => GetCurrentTrialDef<SRT_TrialDef>();
    public SRT_TaskLevel CurrentTaskLevel => GetTaskLevel<SRT_TaskLevel>();
    public SRT_TaskDef CurrentTask => GetTaskDef<SRT_TaskDef>();

    public string ResponseString;

    //public GameObject SRT_CanvasGO;
    
    private StimGroup trialStims;
    private GameObject StartButton;

    private float? RT, prevRT;

    private AudioSource _audioSource;
    private AudioClip _audioClip;
    private StimDef targetStimDef;
    private StimGroup fixCross;
    private int consecutiveLongTrials, consecutiveShortTrials = 0;
    private int maxConsecutiveLongTrials, maxConsecutiveShortTrials;
    private bool rtWarningTriggered;
    public SRT_SimpleTrialData SimpleTrialData;
    public DigilentDataController DigilentDataController;
    private int TrialModality, A_stim, V_stim = 0;
    public CaterpillarControl catControl;

    public override void DefineControlLevel()
    {
        State PreStim = new State("PreStim");
        State AudioStimPresentation = new State("AudioPrep");
        State TactilePrep = new State("TactilePrep");
        State VisualTactileStimPresentation = new State("VisualTactileStimPresentation");
        State Response = new State("Response");
        State Feedback = new State("Feedback");
        State TimeWarning = new State("TimeWarning");
        
        State nextState = new State("nextState"); 
        AddActiveStates(new List<State> { PreStim, AudioStimPresentation, TactilePrep, VisualTactileStimPresentation, Response, Feedback, TimeWarning, nextState });
        
        SimpleTrialData = (SRT_SimpleTrialData)Session.SessionDataControllers
            .InstantiateDataController<SRT_SimpleTrialData>(
                "SimpleTrialData", CurrentTask.TaskName, TaskLevel.TaskDataPath + Path.DirectorySeparatorChar + "SimpleTrialData");
        string filePrefix = $"{Session.FilePrefix}_{TaskLevel.ConfigFolderName}";
        SimpleTrialData.fileName = filePrefix + "__SimpleTrialData.txt";
        SimpleTrialData.InitDataController();
        SimpleTrialData.ManuallyDefine();

        catControl = CurrentTaskLevel.catControl;
        
        
        if (Session.SessionDef.UseDigilentDevice)
        {
            DigilentDataController = (DigilentDataController)Session.SessionDataControllers
                .InstantiateDataController<DigilentDataController>(
                    "DigilentData", CurrentTask.TaskName,
                    TaskLevel.TaskDataPath + Path.DirectorySeparatorChar + "DigilentData");
            DigilentDataController.InitDataController();
            DigilentDataController.ManuallyDefine();
        }

        
        DefineTrialData();
        StartCoroutine(SimpleTrialData.CreateFile());

        Add_ControlLevel_InitializationMethod(() =>
        {
            StimGroup availableStims = Session.UsingDefaultConfigs ? PrefabStims : ExternalStims;
            fixCross = new StimGroup("FixCross", availableStims, new List<int> { CurrentTaskLevel.CurrentBlock.FixCrossStimIndex });
            StartCoroutine(fixCross.LoadStims());
            //
            // if(SliderFBController.SliderGO)
            //     Destroy(SliderFBController.SliderGO);//. SetActive(false));
            // if(SliderFBController.SliderHaloGO)
            //     Destroy(SliderFBController.SliderHaloGO);//.SetActive(false));
            //
            // SliderFBController.InitializeSlider();
            // SliderFBController.ConfigureSlider(12,0);
            // SliderFBController.SliderGO.SetActive(true);
            // SliderFBController.FlashOnComplete = false;
            // SliderFBController.SetFlashingDuration(0);
            // SliderFBController.Slider.direction = Slider.Direction.BottomToTop;
            // SliderFBController.SliderGO.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 600);
            // SliderFBController.SliderGO.transform.localPosition = new Vector3(-350, 360, 0);
            // RectTransform fill = SliderFBController.SliderGO.transform.Find("Fill Area/Fill").gameObject.GetComponent<RectTransform>();
            // fill.offsetMin = new Vector2(-5, 0);
            // fill.offsetMax = new Vector2(15, 0);
            // SliderFBController.SliderHaloGO.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 310);
            // SliderFBController.SliderHaloGO.transform.localPosition = new Vector3(-350, 185, 0);
            
            
            
            consecutiveLongTrials = 0;
            consecutiveShortTrials = 0;
            maxConsecutiveLongTrials = GetTaskDef<SRT_TaskDef>().MaxConsecutiveLongTrials;
            maxConsecutiveShortTrials = GetTaskDef<SRT_TaskDef>().MaxConsecutiveShortTrials;
        });
        
        
        //SetupTrial state --------------------------------------------------------------------------------------------------------------------------------------------
        // change termination condition to consecutiveLongTrials < maxConsecutiveLongTrials && consecutiveShortTrials < maxConsecutiveShortTrials if we want timing feedback to
        //     participants
        SetupTrial.SpecifyTermination(() => true, PreStim, () =>
        {
            // if (TrialCount_InBlock == 0)
            // {
            //     // Debug.Log("CURRENT TRIAL = 0");
            //     // SliderFBController.SetSliderValue(0);
            //     // SliderFBController.targetValue = 0;
            //     // SliderFBController.sliderValueChange = 0;
            // }

            rtWarningTriggered = false;
            fixCross.ToggleVisibility(true);
            if (CurrentTrial.AudioStim_Index != null)
                _audioSource = targetStimDef.AddAudioSource();
            if (CurrentTrial.VisualStim_Index == null)
                TrialModality = 1;
            else if (CurrentTrial.AudioStim_Index == null)
                TrialModality = 2;
            else
                TrialModality = 3;
            
            if (Session.SessionDef.UseDigilentDevice)
                DigilentDataController.CreateNewTrialIndexedFile(TrialCount_InTask + 1, Session.FilePrefix);
            
        });
        TaskInstructions_Level taskInstructions_Level = GameObject.Find("ControlLevels").GetComponent<TaskInstructions_Level>();

        // SetupTrial.SpecifyTermination(()=> consecutiveLongTrials >= maxConsecutiveLongTrials, TimeWarning, () =>
        // {
        //     taskInstructions_Level.postVideoSlideFolderPath =
        //         GetTaskDef<SRT_TaskDef>().LongTimeWarningSlidePath;
        //     taskInstructions_Level.videoPath = GetTaskDef<SRT_TaskDef>().LongTimeWarningVideoPath;
        // });
        // SetupTrial.SpecifyTermination(()=> consecutiveShortTrials >= maxConsecutiveShortTrials, TimeWarning, () =>
        // {
        //     taskInstructions_Level.postVideoSlideFolderPath =
        //         GetTaskDef<SRT_TaskDef>().ShortTimeWarningSlidePath;
        //     taskInstructions_Level.videoPath = GetTaskDef<SRT_TaskDef>().ShortTimeWarningVideoPath;
        // });
        
        
        TimeWarning.AddChildLevel(taskInstructions_Level);

        TimeWarning.AddDefaultInitializationMethod(() =>
        {
            rtWarningTriggered = true;
            taskInstructions_Level.preVideoSlideFolderPath = "";
        });
        TimeWarning.SpecifyTermination(()=>taskInstructions_Level.Terminated, PreStim, () =>
        {
            rtWarningTriggered = false;
            fixCross.ToggleVisibility(true);
            if (CurrentTrial.AudioStim_Index != null)
                _audioSource = targetStimDef.AddAudioSource();
        });

        float audioDelay = 0;
        PreStim.AddDefaultInitializationMethod(()=>
        {
            RT = null;
            ResponseString = "";
            
            //Need to rework to handle AV, VT, AT trials
            audioDelay = CurrentTrial.AudioStim_Index == null
                ? 0
                : GetTaskDef<SRT_TaskDef>().VisualDelayOnAvTrials;
            
            
            nextState = CurrentTrial.AudioStim_Index == null && CurrentTrial.TactileStim_Index == null ? VisualTactileStimPresentation : AudioStimPresentation;
            if(Session.SessionDef.UseDigilentDevice)
                digilent_controller.StartRecording();
        });
        PreStim.AddUpdateMethod(() =>
        {
            if (InputBroker.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode),
                    CurrentTrial.ResponseChar.ToUpper())))
            {
                ResponseString = "Responded";
                RT = null;
            }
        });
        
        //replace audioDelay with general purpose delay
        PreStim.AddTimer(()=>CurrentTrial.PreStimDur - audioDelay, ()=> nextState, () =>
        {
        });
        PreStim.SpecifyTermination(() => !string.IsNullOrEmpty(ResponseString), Feedback);

        //Handle both tactile and visual stimuli?
        AudioStimPresentation.StateInitializationFinished += PlaySound;
        AudioStimPresentation.AddUpdateMethod(() =>
        {
            if (InputBroker.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode),
                    CurrentTrial.ResponseChar.ToUpper())))
            {
                ResponseString = "Responded";
                RT = null;
            }
        });
        AudioStimPresentation.AddTimer(()=> GetTaskDef<SRT_TaskDef>().VisualDelayOnAvTrials, VisualTactileStimPresentation);
        AudioStimPresentation.SpecifyTermination(() => !string.IsNullOrEmpty(ResponseString), Feedback);
        
        // StimPresentation.AddDefaultInitializationMethod
        //Assuming for now that visual/tactile delay is minimal
        VisualTactileStimPresentation.StateInitializationFinished += PrepareAudioTactileStim;
        
        VisualTactileStimPresentation.AddUpdateMethod(() =>
        {
            if (InputBroker.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode),
                    CurrentTrial.ResponseChar.ToUpper())))
            {
                ResponseString = "Responded";
                RT = Time.time - VisualTactileStimPresentation.TimingInfo.StartTimeAbsolute;
            }
        });
        VisualTactileStimPresentation.AddTimer(()=>CurrentTrial.Stim_Dur, Response, () =>
        {
            //send tactile stim off signal
            catControl.TurnTactileStimOff();
        });
        VisualTactileStimPresentation.SpecifyTermination(() => !string.IsNullOrEmpty(ResponseString), Feedback, ()=>
        {
            //send tactile stim off signal
            catControl.TurnTactileStimOff();
        });
        
        Response.AddDefaultInitializationMethod(()=>
        {
            ResponseString = "";
            // if(Session.SessionDef.UseDigilentDevice)
            //     digilent_controller.stop_recording();
        });
        Response.AddUpdateMethod(() =>
        {
            if (InputBroker.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode),
                    CurrentTrial.ResponseChar.ToUpper())))
            {
                ResponseString = "Responded";
                RT = Time.time - VisualTactileStimPresentation.TimingInfo.StartTimeAbsolute;
                    
            }
        });
        Response.AddTimer(()=>CurrentTrial.Resp_MaxDur, Feedback, ()=>
        {
            RT = null;
            if (Session.SessionDef.UseDigilentDevice)
            {
                digilent_controller.CollectData();
                digilent_controller.StopRecording();
                StartCoroutine(DigilentDataController.AppendDataToBuffer());
                StartCoroutine(DigilentDataController.AppendDataToFile());
            }
        });
        Response.SpecifyTermination(() => !string.IsNullOrEmpty(ResponseString) && !InputBroker.GetKey(
            (KeyCode)System.Enum.Parse(typeof(KeyCode),
                CurrentTrial.ResponseChar.ToUpper())), Feedback); //wait until key is up to end response state
        
        Feedback.AddDefaultInitializationMethod(()=>
        {
            // if (TrialCount_InBlock > 0)
            //     if (RT > prevRT || RT == 1000)
            //         consecutiveLongTrials += 1;
            //     else
            //         consecutiveLongTrials = 0;
            // if (RT < 0.05) // subjects responded before stim onset
            //     consecutiveShortTrials += 1;
            // else
            //     consecutiveShortTrials = 0;
            prevRT = RT;
            // SliderFBController.UpdateSliderValue((float)1/TaskLevel.GetCurrentBlockDef<SRT_BlockDef>().N_Trials);
        });
        Feedback.SpecifyTermination(()=> true, FinishTrial);
        
        FinishTrial.AddUniversalLateTerminationMethod(() =>
        {
            if (RT != null)
            {
                StartCoroutine(SimpleTrialData.AppendDataToBuffer());
                StartCoroutine(SimpleTrialData.AppendDataToFile());
            }
        });
        
        
        AddDefaultControlLevelTerminationMethod(() =>
        {
            fixCross.DestroyStimGroup();
        });
    }

    private void PlaySound(object sender, EventArgs e)
    {
        if (CurrentTrial.AudioStim_Index != null)
            targetStimDef.StimGameObject.GetComponent<AudioSource>().PlayOneShot(CurrentTaskLevel.AudioClips[
                CurrentTrial.AudioStim_Index.Value - CurrentTaskLevel.CurrentBlock.AudioStimIndices.Min()]);
        if (CurrentTrial.TactileStim_Index != null)
        {
            //trigger tactile stim
        }

    }

    private void PrepareAudioTactileStim(object sender, EventArgs e)
    {
        if (CurrentTrial.VisualStim_Index != null)
        {
            GameObject stimgo = TrialStims[0].stimDefs[0].StimGameObject;
            RectTransform rt = stimgo.GetComponent<RectTransform>();
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, TrialStims[0].stimDefs[0].StimSizePixels[0]);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, TrialStims[0].stimDefs[0].StimSizePixels[1]);
        }
        if (CurrentTrial.TactileStim_Index != null)
            catControl.TurnTactileStimOn();
    }
    
    protected override void DefineTrialStims()
    {
        //Define StimGroups consisting of StimDefs whose gameobjects will be loaded at TrialLevel_SetupTrial and 
        //destroyed at TrialLevel_Finish

        StimGroup availableStims = Session.UsingDefaultConfigs ? PrefabStims : ExternalStims;


        if (CurrentTrial.VisualStim_Index != null)
        {
            StimGroup visStims = new StimGroup("VisStim", availableStims, new List<int> { CurrentTrial.VisualStim_Index.Value });
            visStims.SetLocations(new List<Vector3> { CurrentTrial.VisualStim_Loc });
            visStims.SetVisibilityOnOffStates(GetStateFromName("VisualTactileStimPresentation"),
                GetStateFromName("VisualTactileStimPresentation"));
            // if (visStims.stimDefs[0].StimGameObject != null)
            //     visStims.stimDefs[0].StimAudioSource = visStims.stimDefs[0].StimGameObject.AddComponent<AudioSource>();
            // _audioSource = visStims.stimDefs[0].StimAudioSource;
            if (CurrentTrial.VisualStimDVA != 0)
            {
                foreach (StimDef sd in visStims.stimDefs)
                {
                    sd.StimSizePixels = USE_CoordinateConverter.GetMonitorPixel(new Vector2(CurrentTrial.VisualStimDVA, CurrentTrial.VisualStimDVA),
                        "monitordva", 60).Value;
                }
            }

            TrialStims.Add(visStims);
        }
        if (CurrentTrial.AudioStim_Index != null)
        {
            StimGroup audStims = new StimGroup("AudStims");
            audStims.AddStims(new GameObject("AudioStim"));
            audStims.SetLocations(new List<Vector3> { CurrentTrial.AudioStim_Loc });
            // if (audStims.stimDefs[0].StimGameObject != null)
            //     audStims.stimDefs[0].StimAudioSource = audStims.stimDefs[0].StimGameObject.AddComponent<AudioSource>();
            // _audioSource = audStims.stimDefs[0].StimAudioSource;
            TrialStims.Add(audStims);
            targetStimDef = audStims.stimDefs[0];
        }


    }

    private void DefineTrialData()
    {
        TrialData.AddDatum("PreStim_Dur", ()=> CurrentTrial.PreStimDur);
        TrialData.AddDatum("Stim_Dur", ()=> CurrentTrial.Stim_Dur);
        TrialData.AddDatum("Resp_Dur", ()=> CurrentTrial.Resp_MaxDur);
        TrialData.AddDatum("VisualStim_Loc", ()=> CurrentTrial.VisualStim_Loc);
        TrialData.AddDatum("AudioStim_Loc", ()=> CurrentTrial.AudioStim_Loc);
        TrialData.AddDatum("VisualStim_Index", ()=> CurrentTrial.VisualStim_Index);
        TrialData.AddDatum("AudioStim_Index", ()=> CurrentTrial.AudioStim_Index);
        TrialData.AddDatum("FixCrossStimIndex", ()=> CurrentTrial.FixCrossStimIndex);
        TrialData.AddDatum("ResponseChar", ()=> CurrentTrial.ResponseChar);
        TrialData.AddDatum("RT", ()=> RT);
        TrialData.AddDatum("RT_Warning", ()=> rtWarningTriggered ? 1 : 0);
        
        SimpleTrialData.AddDatum("modality", ()=> TrialModality);
        SimpleTrialData.AddDatum("audio_stim", ()=> CurrentTrial.AudioStim_Index is null ? 0 : CurrentTrial.AudioStim_Index + 1);
        SimpleTrialData.AddDatum("visual_stim", ()=> CurrentTrial.VisualStim_Index is null ? 0 : CurrentTrial.VisualStim_Index + 1);
        SimpleTrialData.AddDatum("reaction_time", ()=> RT * 1000);

        if (Session.SessionDef.UseDigilentDevice)
        {
            DigilentDataController.AddDatum("Timestamp\tChannel1Voltage\tChannel2Voltage", () => digilent_controller.Two_Channel_Data_String());
        }
    }

    private void DefineFrameData()
    {
        FrameData.AddDatum("ResponseButtonStatus", ()=> ResponseString);
    }
    
    
}
