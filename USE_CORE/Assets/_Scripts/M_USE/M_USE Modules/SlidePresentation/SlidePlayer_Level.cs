using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using USE_States;
using USE_StimulusManagement;

public class SlidePlayer_Level : ControlLevel
{

    public string slideFolder;
    public List<string> slidePaths;
    public List<string> slideText;
    public GameObject taskCanvasGO;
    public KeyCode continueKeyCode = KeyCode.A;

    List<StimDef> slides = new List<StimDef>();
    private bool slidesLoaded = false;
    public float minSlideDelay = 0f;
    public float firstSlideDelay = 0f;
    private bool firstSlide;
    
    public override void DefineControlLevel()
    {
        State LoadSlides = new State("LoadSlides");
        State PlaySlide = new State("PlaySlide");
        AddActiveStates(new List<State> { LoadSlides, PlaySlide });

        bool imgSlides = false;
        bool textSlides = false;


        float slideOnsetTime = 0f;

        bool buttonPressed = false;
        LoadSlides.AddUniversalInitializationMethod(() =>
        {
            slidesLoaded = false;
            slides = new List<StimDef>();
            imgSlides = slidePaths != null && slidePaths.Count > 0;
            textSlides = slideText != null && slideText.Count > 0;
            StartCoroutine(LoadAllSlides());
        });
        LoadSlides.SpecifyTermination(() => slidesLoaded, PlaySlide, () =>
        {
            buttonPressed = false;
            firstSlide = true;
        });

        State Successor = null;
        PlaySlide.AddUniversalInitializationMethod(() =>
        {
            //slideOnsetTime = Time.time;
            buttonPressed = false;
            if (imgSlides)
            {
                slides[0].ToggleVisibility(true);
            }

            if (slides.Count == 1)
                Successor = null;
            else
            {
                Successor = PlaySlide;
            }
        });
        PlaySlide.AddUpdateMethod(() =>
        {
            if (InputBroker.GetKeyUp(KeyCode.A))
            {
                buttonPressed = true;
            }
        });
        // PlaySlide.SpecifyTermination(
        //     () =>  buttonPressed && slides.Count > 1 && Time.time - slideOnsetTime >= minSlideDelay, () => PlaySlide, () =>
        //     {
        //         if (imgSlides)
        //         {
        //             slides[0].DestroyStimGameObject();
        //             slides.RemoveAt(0);
        //             imgSlides = slidePaths.Count != 0;
        //         }
        //         if (textSlides)
        //         {
        //             slideText.RemoveAt(0);
        //             textSlides = slideText.Count != 0;
        //         }
        //     });
        PlaySlide.SpecifyTermination(
            () => CheckSlideEnd(buttonPressed, PlaySlide.TimingInfo.StartTimeAbsolute), () => Successor, () =>
            {
                if (imgSlides)
                {
                    slides[0].DestroyStimGameObject();
                    slides.RemoveAt(0);
                }
                if (textSlides)
                {
                    slideText.RemoveAt(0);
                }

                // slides = null;
            });
        
        ControlLevelTermination(()=> slides= null);
    }

    private bool CheckSlideEnd(bool buttonPressed, float slideOnset)
    {
        if(firstSlide && firstSlideDelay > 0)
            if (Time.time - slideOnset > firstSlideDelay)
            {
                firstSlide = false;
                return true;
            }

        if (buttonPressed && Time.time - slideOnset > minSlideDelay)
        {
            firstSlide = false;
            return true;
        }

        return false;
    }

    private IEnumerator LoadAllSlides()
    {
        for (int iPath = 0; iPath < slidePaths.Count; iPath++)
        {
            string path = slidePaths[iPath];
            StimDef sd = new StimDef();
            sd.StimFolderPath = slideFolder;
            sd.FileName = path;
            sd.CanvasGameObject = taskCanvasGO;
            slides.Add(sd);
            yield return CoroutineHelper.StartCoroutine(sd.Load(stimResultGO =>
            {
                if (stimResultGO != null)
                {
                    sd.StimGameObject = stimResultGO;
                    if (iPath == slidePaths.Count - 1)
                        slidesLoaded = true;
                }
                else
                    Debug.Log("LOAD COROUTINE - STIM RESULT GAMEOBJECT IS NULL!!!!!!!!!!!!");
            }));
            sd.StimGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1920);
            sd.StimGameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1080);
        }
    }
}
