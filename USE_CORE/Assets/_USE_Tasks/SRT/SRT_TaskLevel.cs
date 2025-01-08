using System.Collections;
using System.Collections.Generic;
using System.IO;
using USE_Settings;
using USE_StimulusManagement;
using USE_ExperimentTemplate_Task;
using SRT_Namespace;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

public class SRT_TaskLevel : ControlLevel_Task_Template
{

    public SRT_BlockDef CurrentBlock => GetCurrentBlockDef<SRT_BlockDef>();
    public List<AudioClip> AudioClips;
    public SliderControl SliderControl;
    
    // public SRT_SimpleTrialData SimpleTrialData;
    public override void DefineControlLevel()
    {
        DefineBlockData();
        
        Add_ControlLevel_InitializationMethod(() =>
        {
            USE_CoordinateConverter.SetEyeDistance(60);
        });
        
        SetupBlock.AddDefaultInitializationMethod(() =>
        {
            InitBlockAsyncFinished = false;
            AudioClips = new List<AudioClip>();
            foreach (int iStim in CurrentBlock.AudioStimIndices)
            {
                string audioFilePath = ExternalStims.stimDefs[iStim].FileName;
                StartCoroutine(ConvertFilesToAudioClip(audioFilePath));
            }
        });
        SetupBlock.AddUpdateMethod(() =>
        {
            if (AudioClips.Count == CurrentBlock.AudioStimIndices.Length)
                InitBlockAsyncFinished = true;
        });
        
        RunBlock.AddSpecificInitializationMethod(() =>
        {
            CurrentBlock.ContextName = CurrentBlock.ContextName.Trim();
            SetSkyBox(CurrentBlock.ContextName);
            blockFeedbackFinished = false;
            // slidePlayerLevel.PATH
        });
        
        RunBlock.AddUniversalTerminationMethod(() =>
        {
            // Debug.Log("KILLING SLIDER");
            // TrialLevel.SliderFBController.SetSliderValue(0);
            // TrialLevel.SliderFBController.ResetSliderBarFull();
            // TrialLevel.SliderFBController.SliderGO.SetActive(false);
            // TrialLevel.SliderFBController.SliderHaloGO.SetActive(false);
        });
        
        TaskInstructions_Level taskInstructions_Level = GameObject.Find("ControlLevels").GetComponent<TaskInstructions_Level>();

        BlockFeedback.AddChildLevel(taskInstructions_Level);
        
        // VideoPlayer videoPlayer = TaskCam.gameObject.AddComponent<VideoPlayer>();
        // bool videoStarted = false;
        // bool videoFinished = false;
        // int startFrame = 0;
        BlockFeedback.AddUniversalInitializationMethod(()=>
        {
            blockFeedbackFinished = false;
            taskInstructions_Level.preVideoSlideFolderPath = "";
            taskInstructions_Level.postVideoSlideFolderPath = GetTaskDef<SRT_TaskDef>().InterBlockSlidePath;
            taskInstructions_Level.videoPath = GetTaskDef<SRT_TaskDef>().InterBlockVideoPath;
            
            SliderControl.Slider.gameObject.SetActive(true);
            // startFrame = Time.frameCount;
            Debug.Log("BLOCK COUNT: " + currentBlockDef.BlockCount + ", TOTAL BLOCKS: " + BlockDefs.Length + ", VALUE: " + ((float)currentBlockDef.BlockCount / BlockDefs.Length));
            SliderControl.TargetValue = (float)currentBlockDef.BlockCount / BlockDefs.Length;
            Debug.Log("TARGET VALUE: " + SliderControl.TargetValue);
            
            SliderControl.AnimationOn = true;
            
        });
        // BlockFeedback.AddUpdateMethod(()=>
        // {
        //     if (Time.frameCount == startFrame + 1)
        //     {
        //     }
        // });
        BlockFeedback.SpecifyTermination(() => taskInstructions_Level.Terminated && BlockCount < BlockDefs.Length - 1, SetupBlock, ()=> 
            SliderControl.Slider.gameObject.SetActive(false));
        BlockFeedback.SpecifyTermination(() => taskInstructions_Level.Terminated && BlockCount == BlockDefs.Length - 1,
            FinishTask, () => SliderControl.Slider.gameObject.SetActive(false));

    }

    
    private IEnumerator LoadVideo(VideoPlayer vp, string path)
    {
        vp.url = path;
        vp.Prepare();
        while (!vp.isPrepared)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("STILL LOADING VIDEO");
        }
    }

    private void VideoPlayer_errorReceived(VideoPlayer source, string message)
    {
        Debug.Log(message);
    }
    
    private void DefineBlockData()
    {
        BlockData.AddDatum("PreStim_MinDur", ()=> CurrentBlock.PreStim_MinDur);
        BlockData.AddDatum("PreStim_MaxDur", ()=> CurrentBlock.PreStim_MaxDur);
        BlockData.AddDatum("Stim_Dur", ()=> CurrentBlock.Stim_Dur);
        BlockData.AddDatum("Resp_MaxDur", ()=> CurrentBlock.Resp_MaxDur);
        BlockData.AddDatum("VisualStimIndices", ()=> CurrentBlock.VisualStimIndices);
        BlockData.AddDatum("AudioStimIndices", ()=> CurrentBlock.AudioStimIndices);
        BlockData.AddDatum("FixCrossStimIndex", ()=> CurrentBlock.FixCrossStimIndex);
        BlockData.AddDatum("ResponseChar", ()=> CurrentBlock.ResponseChar);
    }
    
    
    private IEnumerator ConvertFilesToAudioClip(string filePath)
    {
        string url = string.Format("file:/{0}", filePath);
        System.Uri _uri = new System.Uri(filePath);
        string extension = System.IO.Path.GetExtension(filePath);
        // Debug.Log("URL: " + url);

        AudioType at = AudioType.UNKNOWN;
        switch (extension.ToLower())
        {
            case ".aiff":
                at = AudioType.AIFF;
                break;
            case ".mp2":
                at = AudioType.MPEG;
                break;
            case ".mp3":
                at = AudioType.MPEG;
                break;
            case ".wav":
                at = AudioType.WAV;
                break;
            case ".ogg":
                at = AudioType.OGGVORBIS;
                break;
            
        }
        
        if(System.IO.File.Exists(filePath)) {
            using (var uwr = UnityWebRequestMultimedia.GetAudioClip(_uri, at))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;
 
                yield return uwr.SendWebRequest();
 
                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    Debug.LogError(uwr.error);
                    yield break;
                }
 
                DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)uwr.downloadHandler;
 
                if (dlHandler.isDone)
                {
                    AudioClip audioClip = dlHandler.audioClip;
 
                    if (audioClip != null)
                    {
                        var clip = DownloadHandlerAudioClip.GetContent(uwr);
                        if(clip != null)
                        {
                            AudioClips.Add(clip);
                        }
                       
                    }
                    else
                    {
                        Debug.Log("Couldn't find a valid AudioClip :(");
                    }
                }
                else
                {
                    Debug.Log("The download process is not completely finished.");
                }
            }
        }
        else
        {
            Debug.Log("Unable to locate audio file at " + filePath + ".");
        }
    }


}