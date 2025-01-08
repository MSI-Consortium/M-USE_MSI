using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.Video;
using USE_States;
public class TaskInstructions_Level : ControlLevel
{
    public string taskName, preVideoSlideFolderPath, postVideoSlideFolderPath, videoPath;
    public Camera taskCam;
    public SliderFBController SliderFbController;
    public VideoPlayer vp;
    
    public override void DefineControlLevel()
    {
        State PreVideoSlides = new State("PreVideoSlides");
        State Video = new State("Video");
        State PostVideoSlides = new State("PostVideoSlides");
        
        AddActiveStates(new List<State> {PreVideoSlides, Video, PostVideoSlides});

        SlidePlayer_Level slideLevel = GameObject.Find("ControlLevels").GetComponent<SlidePlayer_Level>();
        slideLevel.DefineControlLevel();

        GameObject taskCanvasGO = GameObject.Find(taskName + "_Canvas");
        slideLevel.taskCanvasGO = taskCanvasGO;

        bool skipPreVideoSlides = true;

        
        PreVideoSlides.AddUniversalInitializationMethod(() =>
        {
            if (!string.IsNullOrEmpty(preVideoSlideFolderPath))
            {
                // slideLevel.Terminated = false;
                skipPreVideoSlides = false;
                PreVideoSlides.ChildLevel = slideLevel;
            }
            else
            {
                skipPreVideoSlides = true;
                // slideLevel.Terminated = true;
            }

            if (!skipPreVideoSlides)
            {
                slideLevel.slidePaths = GetSlidePaths(preVideoSlideFolderPath);
                slideLevel.slideFolder = preVideoSlideFolderPath;
            }
        });
        PreVideoSlides.SpecifyTermination(()=> skipPreVideoSlides || slideLevel.Terminated, Video);

        bool skipVideo = true;

        VideoPlayer videoPlayer = null;
        bool videoStarted = false;
        Video.AddUniversalInitializationMethod(() =>
        {
            if (!string.IsNullOrEmpty(videoPath))
            {
                videoPlayer = taskCam.gameObject.AddComponent<VideoPlayer>();
                videoStarted = false;
                videoPlayer.errorReceived += VideoPlayer_errorReceived;
                // VideoClip clip = Resources.Load<VideoClip>(videoPath) as VideoClip;
                // videoPlayer.clip = clip;
                skipVideo = false;
                videoPlayer.source = VideoSource.Url;
                videoPlayer.url = videoPath;
                vp.Prepare();
                // StartCoroutine(LoadVideo(videoPlayer));
            }
            else
                skipVideo = true;
        });
        Video.AddUpdateMethod(() =>
        {
            if (!skipVideo && videoPlayer.isPrepared && !videoPlayer.isPlaying && !videoStarted)
            {
                videoPlayer.Play();
                videoStarted = true;
            }
        });
        Video.SpecifyTermination(
            () => skipVideo | (videoPlayer != null && (videoPlayer.isPrepared && !videoPlayer.isPlaying)) | InputBroker.GetKeyUp(KeyCode.Space),
            PostVideoSlides, () =>
            {
                if (videoPlayer != null)
                {
                    videoPlayer.Stop();
                    videoPlayer.clip = null;
                    Destroy(videoPlayer);
                }
            }); // skipVideo || videoFinished


        bool skipPostVideoSlides = true;
        // slideLevel.DefineControlLevel();
        // }
        // else
        //     skipPostVideoSlides = true;

        PostVideoSlides.AddUniversalInitializationMethod(() =>
        {
            if (!string.IsNullOrEmpty(postVideoSlideFolderPath))
            {
                skipPostVideoSlides = false;
                PostVideoSlides.ChildLevel = slideLevel;
            }
            else
            {
                skipPostVideoSlides = true;
            }

            if (!skipPostVideoSlides)
            {
                slideLevel.slidePaths = GetSlidePaths(postVideoSlideFolderPath);
                slideLevel.slideFolder = postVideoSlideFolderPath;
            }
        });
        PostVideoSlides.SpecifyTermination(()=> skipPostVideoSlides || slideLevel.Terminated, ()=> null);

    }

    private List<string> GetSlidePaths(string folderPath)
    {
        List<string> slidePaths = new List<string>();

        // Define the image file extensions to search for
        string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff" };

        try
        {
            // Get all files in the specified folder
            string[] files = Directory.GetFiles(folderPath);

            // Iterate through each file and check its extension
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();
                if (Array.Exists(imageExtensions, ext => ext.Equals(extension)))
                {
                    slidePaths.Add(Path.GetFileName(file));
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log("File could not be loaded: " + ex.Message);
        }

        return slidePaths;
    }

    private IEnumerator LoadVideo(VideoPlayer vp)
    {
        // vp.clip = Resources.Load("InstructionVideo.ogv") as VideoClip;
        vp.Prepare();
        while (!vp.isPrepared)
        {
            yield return new WaitForSeconds(1);
        }
    }

    private void VideoPlayer_errorReceived(VideoPlayer source, string message)
    {
        Debug.Log(message);
    }

}
