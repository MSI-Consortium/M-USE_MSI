using System;
using System.Collections;
using System.Collections.Generic;   

using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;
using SRT_Namespace;
using SFB;
using USE_ExperimentTemplate_Task;

public class UpdateConfigs : MonoBehaviour
{

    public bool ConfigsUpdated = false;

    public GameObject nBlocks_go,
        nTrials_go,
        itiMinDur_go,
        itiMaxDur_go,
        stimDur_go,
        respMaxDur_go,
        timingSummary_go,
        dispX_go,
        dispY_go,
        dispWidth_go,
        stimWidth_go,
        respChar_go,
        maxLongTrials_go,
        maxShortTrials_go,
        visualDelayOnAvTrials_go;

    public string TaskName;

    private TMP_InputField nBlocks_if,
        nTrials_if,
        itiMinDur_if,
        itiMaxDur_if,
        stimDur_if,
        respMaxDur_if,
        dispX_if,
        dispY_if,
        dispWidth_if,
        stimW_if,
        respChar_if,
        maxLongTrials_if,
        maxShortTrials_if,
        visualDelayOnAvTrials_if;
    private int? nBlocks, nTrials, displayResX, displayResY, maxLongTrials, maxShortTrials;
    private float? itiMinDur, itiMaxDur, stimDur, respMaxDur, displayWidth, stimWidth, visualDelayOnAvTrials;
    private int[] visStimIndices, audStimIndices;
    private int fixCrossStimIndex;
    private string[] visStimPaths, audStimPaths;
    private string fixCrossPath, respChar, contextName;
    public ControlLevel_Task_Template TaskLevel;
    

    public void Start()
    {
        nBlocks_if = GetInputField(nBlocks_go);
        nTrials_if = GetInputField(nTrials_go);
        itiMinDur_if = GetInputField(itiMinDur_go);
        itiMaxDur_if = GetInputField(itiMaxDur_go);
        stimDur_if = GetInputField(stimDur_go);
        respMaxDur_if = GetInputField(respMaxDur_go);
        dispX_if = GetInputField(dispX_go);
        dispY_if = GetInputField(dispY_go);
        dispWidth_if = GetInputField(dispWidth_go);
        stimW_if = GetInputField(stimWidth_go);
        respChar_if = GetInputField(respChar_go);
        maxLongTrials_if = GetInputField(maxLongTrials_go);
        maxShortTrials_if = GetInputField(maxShortTrials_go);
        visualDelayOnAvTrials_if = GetInputField(visualDelayOnAvTrials_go);
        
        
        
        nBlocks_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
        nTrials_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
        itiMinDur_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
        itiMaxDur_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
        stimDur_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
        respMaxDur_if.onValueChanged.AddListener(delegate {UpdateTiming(); });
    }

    private TMP_InputField GetInputField(GameObject go)
    {
        return go.transform.Find("Entry").gameObject.GetComponent<TMP_InputField>();
    }

    public void LoadDefaults()
    {
        nBlocks_if.text = "12";
        nTrials_if.text = "30";
        itiMinDur_if.text = "1";
        itiMaxDur_if.text = "2";
        stimDur_if.text = "0.5";
        respMaxDur_if.text = "3";
        maxLongTrials_if.text = "5";
        maxShortTrials_if.text = "3";
        visualDelayOnAvTrials_if.text = "0.000";
            
        visStimIndices = new[] { 0, 1, 2 };
        audStimIndices = new[] { 3, 4 };
        fixCrossStimIndex = 5;

        string visPath = Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli/Visual/";
        string audPath = Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli/Audio/";
        visStimPaths = new[] { visPath + "Square_Red.png", visPath + "Square_Blue.png", visPath + "Square_Green.png" };
        audStimPaths = new[] { audPath + "beepC1.wav", audPath + "beepC2.wav", audPath + "beepG.wav" };
        fixCrossPath = Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli/white_plus_sign.png";

        dispX_if.text = "1920";
        dispY_if.text = "1080";
        dispWidth_if.text = "60";
        stimW_if.text = "2";

        respChar_if.text = "a";
    }

    public void ParseAllInputs()
    {
        nBlocks = GetIntFieldVal(nBlocks_if.text);
        nTrials = GetIntFieldVal(nTrials_if.text);
        itiMinDur = GetFloatFieldVal(itiMinDur_if.text);
        itiMaxDur = GetFloatFieldVal(itiMaxDur_if.text);
        stimDur = GetFloatFieldVal(stimDur_if.text);
        respMaxDur = GetFloatFieldVal(respMaxDur_if.text);
        displayResX = GetIntFieldVal(dispX_if.text);
        displayResY = GetIntFieldVal(dispY_if.text);
        displayWidth = GetFloatFieldVal(dispWidth_if.text);
        stimWidth = GetFloatFieldVal(stimW_if.text);
        maxLongTrials = GetIntFieldVal(maxLongTrials_if.text);
        maxShortTrials = GetIntFieldVal(maxShortTrials_if.text);
        visualDelayOnAvTrials = GetFloatFieldVal(visualDelayOnAvTrials_if.text);
        respChar = "a";
        contextName = "BackdropGrey.png";
    }

    public void SelectVisualStim()
    {
        visStimPaths = StandaloneFileBrowser.OpenFilePanel("Select Visual Stimuli",
            Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli/Visual",
            new ExtensionFilter[] { new ExtensionFilter("Image Files", "jpg", "png") },
            true);
    }

    public void SelectAudioStim()
    {
        audStimPaths = StandaloneFileBrowser.OpenFilePanel("Select Audio Stimuli",
            Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli/Audio",
            new ExtensionFilter[] { new ExtensionFilter("Audio Files", "wav", "mp3", "ogg") },
            true);
    }

    public void SelectFixCross()
    {
        string[] fixCrossPaths = StandaloneFileBrowser.OpenFilePanel("Select Fixation Cross",
            Session.ResourcesFolderPath + "/" + TaskName + "/Stimuli",
            new ExtensionFilter[] { new ExtensionFilter("Image Files", "jpg", "png") },
            false);
        fixCrossPath = fixCrossPaths[0];
    }
    
    public void CreateAndSaveStimDefFile(string filePath)
    {
        if (visStimPaths != null & audStimPaths != null & !string.IsNullOrEmpty(fixCrossPath))
        {
            Debug.Log("WRITING STIM PATH");
            string stimDefString = "StimIndex\tFileName";
            
            visStimIndices = new int[visStimPaths.Length];
            for (int iVis = 0; iVis < visStimIndices.Length; iVis++)
            {
                visStimIndices[iVis] = iVis;
                stimDefString += "\n" + iVis + "\t" + Path.GetFileName(visStimPaths[iVis]);
            }

            audStimIndices = new int[audStimPaths.Length];
            for (int iAud = 0; iAud < audStimIndices.Length; iAud++)
            {
                audStimIndices[iAud] = visStimIndices.Length + iAud;
                stimDefString += "\n" + (visStimIndices.Length + iAud) + "\t" + Path.GetFileName(audStimPaths[iAud]);
            }

            fixCrossStimIndex = visStimIndices.Length + audStimIndices.Length;
            stimDefString += "\n" + fixCrossStimIndex + "\t" + Path.GetFileName(fixCrossPath);

            WriteToFile(filePath, stimDefString);
        }
        else
        {
            Debug.Log("NOT WRITING STIM PATH");
        }
        
    }

    public int? GetIntFieldVal(string text)
    {
        if (string.IsNullOrEmpty(text))
            return null;
        else
            return int.Parse(text);
    }

    public float? GetFloatFieldVal(string text)
    {
        if (string.IsNullOrEmpty(text))
            return null;
        else
            return float.Parse(text);
    }
    
    public void ConfirmAndRun()
    {
        ParseAllInputs();
        string blockDefFilePath = Session.ConfigFolderPath + "/" + TaskName + "/" + TaskName + "_BlockDef_array.txt";
        string stimDefFilePath = Session.ConfigFolderPath + "/" + TaskName + "/" + TaskName + "_StimDef_array.txt";
        string sessionDefFilePath = Session.ConfigFolderPath + "/SessionConfig_singleType.txt";
        string taskDefFilePath = Session.ConfigFolderPath + "/" + TaskName + "/" + TaskName + "_TaskDef_singleType.txt";
        CreateAndSaveStimDefFile(stimDefFilePath);
        CreateAndSaveBlockDefFile(blockDefFilePath);
        UpdateAndSaveSessionDefFile(sessionDefFilePath);
        UpdateAndSaveTaskDefFile(taskDefFilePath);
        USE_CoordinateConverter.SetEyeDistance(60);

        ConfigsUpdated = true;
    }

    public void UpdateAndSaveTaskDefFile(string taskDefFilePath)
    {
        UpdateConfigValue(taskDefFilePath, "MaxConsecutiveLongTrials", maxLongTrials.Value.ToString());
        UpdateConfigValue(taskDefFilePath, "MaxConsecutiveShortTrials", maxShortTrials.Value.ToString());
        UpdateConfigValue(taskDefFilePath, "VisualDelayOnAvTrials", visualDelayOnAvTrials.Value.ToString());
    }
    
    public void UpdateAndSaveSessionDefFile(string sessionDefFilePath)
    {
        float displayHeight = displayWidth.Value * displayResY.Value / displayResX.Value;
        string newValue = "{\"PixelResolution\": {\"x\":" + displayResX + ", \"y\":" + displayResY +
                          "}, \"CmSize\": {\"x\":" + displayWidth + ", \"y\":" + displayHeight.ToString("0.0") + "}}";
        UpdateConfigValue(sessionDefFilePath, "MonitorDetails", newValue);
    }
    
    public void WriteToFile(string filePath, string fileContents)
    {
        string directory = Path.GetDirectoryName(filePath);
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);
        string previousDirectory = Path.Combine(directory, "Previous");

        if (!Directory.Exists(previousDirectory))
        {
            Directory.CreateDirectory(previousDirectory);
        }

        if (File.Exists(filePath))
        {
            string previousFilePath = Path.Combine(previousDirectory, $"{fileName}_prev{extension}");
            File.Copy(filePath, previousFilePath, true);
        }

        Debug.Log("Writing file to " + filePath);
        File.WriteAllText(filePath, fileContents);
    }
    public void CreateAndSaveBlockDefFile(string filePath)
    {

        string blockDefContents =
            "BlockCount\tN_Trials\tPreStim_MinDur\tPreStim_MaxDur\tStim_Dur\tResp_MaxDur\tVisualStimIndices\tAudioStimIndices\tFixCrossStimIndex\tVisualStimDVA\tResponseChar\tContextName";
        
        for (int blockCount = 1; blockCount <= nBlocks; blockCount++)
        {
            string visualStimIndicesStr = "[" + string.Join(",", visStimIndices) + "]";
            string audioStimIndicesStr = "[" + string.Join(",", audStimIndices) + "]";
                
            blockDefContents += ("\n" + $"{blockCount}\t{nTrials}\t{itiMinDur}\t{itiMaxDur}\t{stimDur}\t{respMaxDur}\t{visualStimIndicesStr}\t{audioStimIndicesStr}\t{fixCrossStimIndex}\t{stimWidth}\t{respChar}\t{contextName}");
        }

        WriteToFile(filePath, blockDefContents);
    }

    public void UpdateTiming()
    {
        ParseAllInputs();
        int? totalTrials = nBlocks * nTrials;
        float assumedRT = 0.5f;
        float? meanTrialDur = itiMinDur + (itiMaxDur - itiMinDur) / 2 + stimDur + assumedRT;

        int? minutes = null;
        int? seconds = null;
        if (meanTrialDur != null)
        {
            minutes = Convert.ToInt32(Math.Floor((double)(meanTrialDur * totalTrials) / 60));
            seconds = Convert.ToInt32(Math.Round((double)(meanTrialDur * totalTrials) % 60));
        }

        timingSummary_go.GetComponent<TMP_Text>().text = 
            nBlocks + " Blocks x " + nTrials + " Trials Per Block = <b>" + totalTrials + "</b> Total Trials.<br><br>" + 
            "Mean Trial Duration (assume mean RT = " + assumedRT + "s) = <b>" + meanTrialDur + "s</b>.<br><br>" +
            "Estimated Duration (all trials): <b>" + minutes + " min, " + seconds + "s</b>." ;
    }

    public void UpdateConfigValue(string ConfigFilePath, string VarName, string NewValue)
    {
        string[] lines = File.ReadAllLines(ConfigFilePath);
        bool found = false;

        for (int i = 0; i < lines.Length; i++)
        {
            // Check if the line contains the variable name
            if (lines[i].Contains(VarName))
            {
                string[] parts = lines[i].Split('\t');

                for (int j = 1; j < parts.Length; j++)
                {
                    if (parts[j] == VarName && j + 1 < parts.Length)
                    {
                        // Replace the value after the variable name with the new value
                        parts[j + 1] = NewValue;
                        lines[i] = string.Join("\t", parts);
                        found = true;
                        break;
                    }
                }
            }
        }

        if (found)
        {
            // Write the updated lines back to the file
            File.WriteAllLines(ConfigFilePath, lines);
            Debug.Log($"Updated {ConfigFilePath}");
        }
        else
        {
            Debug.Log($"Variable name '{VarName}' not found in {ConfigFilePath}");
        }
    }
}

