using System.Collections.Generic;
using UnityEngine;
using USE_ExperimentTemplate;
using USE_States;
using USE_StimulusManagement;
using WorkingMemory_Namespace;

public class WorkingMemory_TrialLevel : ControlLevel_Trial_Template
{
    public WorkingMemory_TrialDef CurrentTrialDef => GetCurrentTrialDef<WorkingMemory_TrialDef>();

    private StimGroup sampleStims, targetStims, postSampleDistractorStims, targetDistractorStims;

    public override void DefineControlLevel()
    {
        State initTrial = new State("InitTrial");
        State delay = new State("Delay");
        State displaySample = new State("DisplaySample");
        State displayPostSampleDistractors = new State("DisplayPostSampleDistractors");
        State searchDisplay = new State("SearchDisplay");
        State selectionFeedback = new State("SelectionFeedback");
        State tokenFeedback = new State("TokenFeedback");
        State trialEnd = new State("TrialEnd");

        AddActiveStates(new List<State> { initTrial, delay, displaySample, displayPostSampleDistractors, searchDisplay, selectionFeedback, tokenFeedback, trialEnd });

        State stateAfterDelay = null;
        float delayDuration = 0;
        delay.AddTimer(() => delayDuration, () => stateAfterDelay);

        SetupTrial.SpecifyTermination(() => true, initTrial);

        initTrial.AddTimer(() => CurrentTrialDef.initTrialDuration, delay, () =>
          {
              stateAfterDelay = displaySample;
              delayDuration = CurrentTrialDef.baselineDuration;
          });

        displaySample.AddTimer(() => CurrentTrialDef.displaySampleDuration, delay, () =>
          {
              stateAfterDelay = displayPostSampleDistractors;
              delayDuration = CurrentTrialDef.postSampleDelayDuration;
          });

        displayPostSampleDistractors.AddTimer(() => CurrentTrialDef.displayPostSampleDistractorsDuration, delay, () =>
          {
              stateAfterDelay = searchDisplay;
              delayDuration = CurrentTrialDef.preTargetDelayDuration;
          });


        bool responseMade = false;
        searchDisplay.AddInitializationMethod(() => responseMade = false);
        searchDisplay.AddUpdateMethod(() =>
        {
            if (InputBroker.GetMouseButtonDown(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mouseRay, out RaycastHit hit))
                {
                    GameObject hitObj = hit.transform.root.gameObject;
                    foreach (WorkingMemory_StimDef sd in targetStims.stimDefs)
                    {
                        if (ReferenceEquals(sd.StimGameObject, hitObj))
                        {
                            Log("Correct!");
                            responseMade = true;
                        }
                    }
                    foreach (WorkingMemory_StimDef sd in targetDistractorStims.stimDefs)
                    {
                        if (ReferenceEquals(sd.StimGameObject, hitObj))
                        {
                            Log("Incorrect!");
                            responseMade = true;
                        }
                    }
                }
            }
        });
        searchDisplay.SpecifyTermination(() => responseMade, selectionFeedback);
        searchDisplay.AddTimer(() => CurrentTrialDef.maxSearchDuration, FinishTrial, () =>
        {
            Log("Response was not made");
        });

        selectionFeedback.AddInitializationMethod(() => { });
        //adapt from ChoseWrong/Right in whatwhenwhere task
        selectionFeedback.AddTimer(() => CurrentTrialDef.selectionFbDuration, tokenFeedback);


        bool tokenUpdated = false;
        tokenFeedback.AddInitializationMethod(() => tokenUpdated = false);
        //wait for Marcus to integrate token fb
        tokenFeedback.SpecifyTermination(() => true, trialEnd); //()=> tokenUpdated, tokenFeedback);

        trialEnd.AddTimer(() => CurrentTrialDef.trialEndDuration, FinishTrial);

        //adapt StartButton from whatwhenwhere task
    }

    protected override void DefineTrialStims()
    {
        //Define StimGroups consisting of StimDefs whose gameobjects will be loaded at TrialLevel_SetupTrial and 
        //destroyed at TrialLevel_Finish


        sampleStims = new StimGroup("SampleStims", ExternalStims, CurrentTrialDef.TargetIndices);
        sampleStims.SetVisibilityOnOffStates(GetStateFromName("DisplaySample"), GetStateFromName("DisplaySample"));
        sampleStims.SetLocations(CurrentTrialDef.TargetSampleLocations);
        TrialStims.Add(sampleStims);

        targetStims = new StimGroup("TargetStims", ExternalStims, CurrentTrialDef.TargetIndices);
        targetStims.SetVisibilityOnOffStates(GetStateFromName("SearchDisplay"), GetStateFromName("TokenFeedback"));
        targetStims.SetLocations(CurrentTrialDef.TargetSearchLocations);
        foreach (WorkingMemory_StimDef sd in targetStims.stimDefs)
            sd.IsTarget = true;
        TrialStims.Add(targetStims);

        postSampleDistractorStims = new StimGroup("PostSampleDistractor", ExternalStims, CurrentTrialDef.PostSampleDistractorIndices);
        postSampleDistractorStims.SetVisibilityOnOffStates(GetStateFromName("DisplayPostSampleDistractors"), GetStateFromName("DisplayPostSampleDistractors"));
        postSampleDistractorStims.SetLocations(CurrentTrialDef.PostSampleDistractorLocations);
        TrialStims.Add(postSampleDistractorStims);

        targetDistractorStims = new StimGroup("PreTargetDistractor", ExternalStims, CurrentTrialDef.TargetDistractorIndices);
        targetDistractorStims.SetVisibilityOnOffStates(GetStateFromName("SearchDisplay"), GetStateFromName("TokenFeedback"));
        targetDistractorStims.SetLocations(CurrentTrialDef.TargetDistractorLocations);
        TrialStims.Add(targetDistractorStims);
    }

    private void Log(object msg)
    {
        Debug.Log("[WorkingMemory] " + msg);
    }
}