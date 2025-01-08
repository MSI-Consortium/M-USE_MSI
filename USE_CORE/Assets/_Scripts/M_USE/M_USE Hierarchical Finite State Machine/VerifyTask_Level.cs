/*
MIT License

Copyright (c) 2023 Multitask - Unified - Suite -for-Expts

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files(the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/



using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ConfigDynamicUI;
using UnityEngine;
using USE_Def_Namespace;
using USE_ExperimentTemplate_Classes;
using USE_ExperimentTemplate_Task;
using USE_States;
using USE_StimulusManagement;
using Object = System.Object;


public class VerifyTask_Level : ControlLevel
{
    public ImportSettings_Level importSettings_Level;
    public bool fileParsed;
    public string currentFileName;
    public object parsedResult = null;
    public ControlLevel_Task_Template TaskLevel;

    private bool ui_closed;


    public override void DefineControlLevel()
    {
        State TaskDef_UI = new State("TaskDef_UI");
        State ImportTaskSettings = new State("ImportTaskSettings");
        State HandleTrialAndBlockDefs = new State("HandleTrialAndBlockDefs");
        State FindStims = new State("FindStims");

        AddActiveStates(new List<State> {TaskDef_UI, ImportTaskSettings, HandleTrialAndBlockDefs, FindStims});

        TaskDef_UI.AddDefaultInitializationMethod(() =>
        {
            ui_closed = false;
            //update ui_closed with close and save button 
            
            //generate experimenter taskdef ui interface if needed 
            if (TaskLevel.taskdef_ui_vars != null && TaskLevel.taskdef_ui_vars.Count > 0)
            {
                foreach (config_ui_var c_var in TaskLevel.taskdef_ui_vars)
                {
                    c_var.CreateAndPlace();
                }
                
            }
        });
        
        TaskDef_UI.SpecifyTermination(()=> TaskLevel.taskdef_ui_vars == null || TaskLevel.taskdef_ui_vars.Count == 0, ImportTaskSettings);
        TaskDef_UI.SpecifyTermination(()=> ui_closed, ImportTaskSettings);

        importSettings_Level = GameObject.Find("ControlLevels").GetComponent<ImportSettings_Level>();
        //importSettings_Level.TaskLevel = TaskLevel;
        ImportTaskSettings.AddChildLevel(importSettings_Level);
        ImportTaskSettings.AddSpecificInitializationMethod(() =>
        {
            if (Session.UsingDefaultConfigs)
                TaskLevel.TaskConfigPath += "_DefaultConfigs";

            if (Session.UsingDefaultConfigs)
                WriteTaskConfigsToPersistantDataPath();

            TaskLevel.SpecifyTypes();

            importSettings_Level.SettingsDetails = new List<SettingsDetails>()
            {
                new SettingsDetails(TaskLevel.TaskConfigPath, "TaskDef", TaskLevel.TaskDefType),
                new SettingsDetails(TaskLevel.TaskConfigPath, "BlockDef", TaskLevel.BlockDefType),
                new SettingsDetails(TaskLevel.TaskConfigPath, "TrialDef", TaskLevel.TrialDefType),
                new SettingsDetails(TaskLevel.TaskConfigPath, "StimDef", TaskLevel.StimDefType),
                new SettingsDetails(TaskLevel.TaskConfigPath, "EventCode", typeof(Dictionary<string, EventCode>)),
                new SettingsDetails(TaskLevel.TaskConfigPath, "ConfigUi", typeof(ConfigVarStore)),
            };
            
            
            if (Session.UseDefaultLocalPaths)
            {
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "ExternalStimFolderPath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Stimuli\"");
                // UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "TaskInstructionsVideoPath",
                //     "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/InstructionVideo.mp4\"");
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "TaskInstructionsPreVideoSlidesFolderPath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/PreVideoSlides\"");
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "TaskInstructionsPostVideoSlidesFolderPath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/PostVideoSlides\"");
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "InterBlockSlidePath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/InterblockSlides\"");
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "InterBlockVideoPath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/Break.mp4\"");
                //This should be in specific task level, not here...
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "LongTimeWarningSlidePath",
                "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/LongTimeWarningSlides\"");
                UpdateConfig(TaskLevel.TaskConfigPath, "TaskDef", "ShortTimeWarningSlidePath",
                    "\"" + Session.ExptFolderPath + "/Resources/" + TaskLevel.TaskName + "/Instructions/ShortTimeWarningSlides\"");
                
            }

            TaskLevel.customSettings = new List<CustomSettings>();
            TaskLevel.DefineCustomSettings();
            
            foreach (CustomSettings customSettingsType in TaskLevel.customSettings)
            {
                importSettings_Level.SettingsDetails.Add(new SettingsDetails(TaskLevel.TaskConfigPath,
                    customSettingsType.SearchString, customSettingsType.SettingsType));
            }

        });

        ImportTaskSettings.AddUpdateMethod(() =>
        {
            if (importSettings_Level.fileLoadingFinished)
            {
                importSettings_Level.importPaused = false;
            }

            if (importSettings_Level.fileParsed)
            {
                currentFileName = importSettings_Level.currentSettingsDetails.FilePath;
                parsedResult = importSettings_Level.parsedResult;
                Type currentType = importSettings_Level.currentSettingsDetails.SettingType;

                if (parsedResult != null)
                {
                    if (currentType.Equals(TaskLevel.TaskDefType))
                    {
                        MethodInfo SettingsConverter_methodTask = GetType()
                            .GetMethod(nameof(this.SettingsConverterTask)).MakeGenericMethod(new Type[] {currentType});
                        SettingsConverter_methodTask.Invoke(this, new object[] {parsedResult});
                        Debug.Log(TaskLevel.TaskName + " TaskDef imported.");
                    }
                    else if (currentType.Equals(TaskLevel.BlockDefType))
                    {
                        MethodInfo SettingsConverter_methodTask = GetType()
                            .GetMethod(nameof(this.SettingsConverterBlock)).MakeGenericMethod(new Type[] {currentType});
                        SettingsConverter_methodTask.Invoke(this, new object[] {parsedResult});
                        Debug.Log(TaskLevel.TaskName + " " + TaskLevel.BlockDefs.Length + " BlockDefs imported.");
                    }
                    else if (currentType.Equals(TaskLevel.TrialDefType))
                    {
                        
                        MethodInfo SettingsConverter_methodTask = GetType()
                            .GetMethod(nameof(this.SettingsConverterTrial)).MakeGenericMethod(new Type[] {currentType});
                        SettingsConverter_methodTask.Invoke(this, new object[] {parsedResult});
                        Debug.Log(TaskLevel.TaskName + " " + TaskLevel.AllTrialDefs.Length + " TrialDefs imported.");
                    }
                    else if (currentType.Equals(TaskLevel.StimDefType))
                    {
                        MethodInfo SettingsConverter_methodTask = GetType()
                            .GetMethod(nameof(this.SettingsConverterStim)).MakeGenericMethod(new Type[] {currentType});
                        SettingsConverter_methodTask.Invoke(this, new object[] {parsedResult});
                        if(Session.UsingLocalConfigs)
                            Debug.Log(TaskLevel.TaskName + " " + TaskLevel.ExternalStims.stimDefs.Count +
                                  " External StimDefs imported.");
                        else if (Session.UsingDefaultConfigs)
                            Debug.Log(TaskLevel.TaskName + " " + TaskLevel.PrefabStims.stimDefs.Count +
                                      " Prefab StimDefs imported.");
                    }
                    else if (currentType.Equals(typeof(Dictionary<string, EventCode>)))
                    {
                        TaskLevel.CustomTaskEventCodes = (Dictionary<string, EventCode>) parsedResult;
                        Debug.Log(TaskLevel.TaskName + " " + TaskLevel.CustomTaskEventCodes.Count +
                                  " Event Codes imported.");
                    }
                    else if (currentType.Equals(typeof(ConfigVarStore)))
                    {
                        TaskLevel.ConfigUiVariables = (ConfigVarStore) parsedResult;
                        Debug.Log(TaskLevel.TaskName + " " + TaskLevel.ConfigUiVariables.getAllVariables().Count +
                                  " Config UI Variables imported.");
                    }
                    else 
                    {
                        for(int iCustom = 0; iCustom < TaskLevel.customSettings.Count; iCustom++)
                        {
                            CustomSettings cs = TaskLevel.customSettings[iCustom];
                            object[] parameters = new object[] {parsedResult};

                            if (cs.SettingsParsingStyle.ToLower() == "array")
                            {
                                MethodInfo SettingsConverter_methodCustom = GetType()
                                    .GetMethod(nameof(this.SettingsConverterCustomArray))
                                    .MakeGenericMethod(new Type[] {currentType});
                                cs.ParsedResult = SettingsConverter_methodCustom.Invoke(this, parameters);
                                Debug.Log(cs.ParsedResult);
                            }
                            else
                            {
                                MethodInfo SettingsConverter_methodCustom = GetType()
                                    .GetMethod(nameof(this.SettingsConverterCustom))
                                    .MakeGenericMethod(new Type[] {currentType});
                                cs.ParsedResult = SettingsConverter_methodCustom.Invoke(this, parameters);
                            }

                            Debug.Log(TaskLevel.TaskName + " " + cs.SearchString + " file imported.");
                            //Debug.Log(((MazeGame_Namespace.MazeDef[])cs.ParsedResult)[0].mDims);

                        }
                        
                    }
                    
                }

                fileParsed = true;
                importSettings_Level.importPaused = false;
            }
        });
        ImportTaskSettings.SpecifyTermination(() => ImportTaskSettings.ChildLevel.Terminated, HandleTrialAndBlockDefs,
            () => Debug.Log("ImportSettings state terminated."));

        HandleTrialAndBlockDefs.AddSpecificInitializationMethod(() => { TaskLevel.HandleTrialAndBlockDefs(true); });
        HandleTrialAndBlockDefs.SpecifyTermination(() => TaskLevel.TrialAndBlockDefsHandled, FindStims);

        FindStims.AddSpecificInitializationMethod(() =>
        {
            if (Session.SessionDef.ParticipantDistance_CM != 0)
                USE_CoordinateConverter.SetEyeDistance(Session.SessionDef.ParticipantDistance_CM);
            else
                USE_CoordinateConverter.SetEyeDistance(60);
            
            TaskLevel.TaskStims = new TaskStims();
            TaskLevel.PrefabStims ??= new StimGroup("PrefabStims");
            TaskLevel.PreloadedStims ??= new StimGroup("PreloadedStims");
            TaskLevel.ExternalStims ??= new StimGroup("ExternalStims");
            TaskLevel.RuntimeStims ??= new StimGroup("RuntimeStims");

            TaskLevel.FindStims();
        });
        FindStims.SpecifyTermination(() => TaskLevel.StimsHandled, () => null);
    }

    public void ContinueToNextSetting()
    {
        importSettings_Level.importPaused = false;
    }


    private void WriteTaskConfigsToPersistantDataPath()
    {
        if (!Session.UsingDefaultConfigs)
            return;

        if (Directory.Exists(TaskLevel.TaskConfigPath))
            Directory.Delete(TaskLevel.TaskConfigPath, true);

        Directory.CreateDirectory(TaskLevel.TaskConfigPath);

        Dictionary<string, string> configDict = new Dictionary<string, string>
        {
            {"_TaskDef_singleType", "_TaskDef_singleType.txt"},
            {"_BlockDef_array", "_BlockDef_array.txt"},
            {"_TrialDef_array", "_TrialDef_array.txt"},
            {"_StimDef_array", "_StimDef_array.txt"},
            {"_ConfigUiDetails_json", "_ConfigUiDetails_json.json"},
            {"_EventCodeConfig_json", "_EventCodeConfig_json.json"},
            {"MazeDef_array", "MazeDef_array.txt"},
            {"_ObjectsDef_array", "_ObjectsDef_array.txt"}
        };
        TextAsset configTextAsset;
        foreach (var entry in configDict)
        {
            configTextAsset = Resources.Load<TextAsset>("DefaultSessionConfigs/" + TaskLevel.TaskName + "_DefaultConfigs/" + TaskLevel.TaskName + entry.Key);
            if (configTextAsset == null) //try it without task name (cuz MazeDef.txt doesnt have MazeGame in front of it)
                configTextAsset = Resources.Load<TextAsset>("DefaultSessionConfigs/" + TaskLevel.TaskName + "_DefaultConfigs/" + entry.Key);
            if (configTextAsset != null)
                File.WriteAllBytes(TaskLevel.TaskConfigPath + Path.DirectorySeparatorChar + TaskLevel.TaskName + entry.Value, configTextAsset.bytes);
        }
    }


    public void SettingsConverterTask<T>(object parsedSettings) where T : TaskDef
    {
        TaskLevel.TaskDef = (T) parsedSettings;
    }

    public void SettingsConverterBlock<T>(object parsedSettings) where T : BlockDef
    {
        TaskLevel.BlockDefs = (T[]) parsedSettings;
    }

    public void SettingsConverterTrial<T>(object parsedSettings) where T : TrialDef
    {
        TaskLevel.AllTrialDefs = (T[]) parsedSettings;
    }

    public void SettingsConverterStim<T>(object parsedSettings) where T : StimDef
    {
        if (Session.UsingDefaultConfigs)
            TaskLevel.PrefabStims = new StimGroup("PrefabStims", (T[]) parsedSettings);
        else if (Session.UsingLocalConfigs || Session.UsingServerConfigs)
        {
            TaskLevel.ExternalStims = new StimGroup("ExternalStims", (T[])parsedSettings);
        }
    }

    public T SettingsConverterCustom<T>(object parsedSettings)
    {
       return (T)parsedSettings;
    }
    public T[] SettingsConverterCustomArray<T>(object parsedSettings)
    {
        return (T[])parsedSettings;
    }
    
    public static void UpdateConfig(string ConfigFolderPath, string ConfigFileSearchString, string VarName, string NewValue)
    {
        // Get all files in the directory that match the search string
        string[] files = Directory.GetFiles(ConfigFolderPath, $"*{ConfigFileSearchString}*");

        if (files.Length == 0)
        {
            Console.WriteLine("No files found matching the search string.");
            return;
        }

        foreach (string file in files)
        {
            string[] lines = File.ReadAllLines(file);
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                // Check if the line contains the variable name
                if (lines[i].Contains(VarName))
                {
                    string[] parts = lines[i].Split('\t');

                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j] == VarName && j + 1 < parts.Length)
                        {
                            // Replace the value after the variable name with the new value
                            parts[j + 1] = NewValue;
                            found = true;
                            break;
                        }
                    }

                    // Reconstruct the line with the new value
                    if (found)
                    {
                        lines[i] = string.Join("\t", parts);
                        break;
                    }
                }
            }

            if (found)
            {
                // Write the updated lines back to the file
                File.WriteAllLines(file, lines);
                Console.WriteLine($"Updated {file}");
            }
            else
            {
                Console.WriteLine($"Variable name '{VarName}' not found in {file}");
            }
        }
    }
    
    // public void SettingsConverterCustomArray<T>(T[] parsedSettings, CustomSettings customSetting)
    // {
    //     customSetting.ParsedResult = parsedSettings;
    // }

}
