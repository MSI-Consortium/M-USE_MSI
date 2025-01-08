using System;
using System.Collections.Generic;
using UnityEngine;
using USE_StimulusManagement;
using USE_Def_Namespace;
using USE_ExperimentTemplate_Data;
using USE_States;
using Random = UnityEngine.Random;

namespace SRT_Namespace
{
    public class SRT_TaskDef : TaskDef
    {
        //Already-existing fields (inherited from TaskDef)      
        //public DateTime TaskStart_DateTime;
        //public int TaskStart_Frame;
        //public float TaskStart_UnityTime;
        //public string TaskName;
        //public string ExternalStimFolderPath;
        //public string PrefabStimFolderPath;
        //public string ExternalStimExtension;
        //public List<string[]> FeatureNames;
        //public string neutralPatternedColorName;
        //public float? ExternalStimScale;
        public string InterBlockSlidePath;
        public string InterBlockVideoPath;
        public string LongTimeWarningSlidePath;
        public string LongTimeWarningVideoPath;
        public string ShortTimeWarningSlidePath;
        public string ShortTimeWarningVideoPath;
        public int MaxConsecutiveLongTrials;
        public int MaxConsecutiveShortTrials;
        public float VisualDelayOnAvTrials;
    }

    public class SRT_BlockDef : BlockDef
    {
        //Already-existing fields (inherited from BlockDef)
		//public int BlockCount;
		//public TrialDef[] TrialDefs;
        public float PreStim_MinDur;
        public float PreStim_MaxDur;
        public float Stim_Dur;
        public float Resp_MaxDur;
        public int[] VisualStimIndices;
        public int[] AudioStimIndices;
        public int[] TactileStimIndices;
        public int FixCrossStimIndex;
        public string ResponseChar;
        public int N_Trials;
        public float VisualStimDVA;
        
        
        public override void GenerateTrialDefsFromBlockDef()
        {
            TrialDefs = new List<SRT_TrialDef>().ConvertAll(x => (TrialDef)x);


            //Generate all possible combinations of visual and auditory stimuli, and equal numbers of visual-only / auditory-only stimuli 
            for (int iVis = 0; iVis < VisualStimIndices.Length; iVis++)
            {
                for (int iAud = 0; iAud < AudioStimIndices.Length; iAud++)
                {
                    //combo trial 1
                    SRT_TrialDef td = new SRT_TrialDef();
                    td.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                    td.Stim_Dur = Stim_Dur;
                    td.Resp_MaxDur = Resp_MaxDur;
                    td.VisualStim_Index = VisualStimIndices[iVis];
                    td.AudioStim_Index = AudioStimIndices[iAud];
                    td.FixCrossStimIndex = FixCrossStimIndex;
                    td.VisualStim_Loc = new Vector3(0, 0, 0);
                    td.AudioStim_Loc = new Vector3(0, 0, 0);
                    td.ResponseChar = ResponseChar;
                    td.VisualStimDVA = VisualStimDVA;
                    TrialDefs.Add(td);

                    if (!CheckTimingTest(()=>Session.SessionDef.UseDigilentDevice))
                    {
                        //auditory only trial
                        SRT_TrialDef td_audonly = new SRT_TrialDef();
                        td_audonly.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                        td_audonly.Stim_Dur = Stim_Dur;
                        td_audonly.Resp_MaxDur = Resp_MaxDur;
                        td_audonly.VisualStim_Index = null;
                        td_audonly.AudioStim_Index = AudioStimIndices[iAud];
                        td_audonly.FixCrossStimIndex = FixCrossStimIndex;
                        td_audonly.VisualStim_Loc = new Vector3(0, 0, 0);
                        td_audonly.AudioStim_Loc = new Vector3(0, 0, 0);
                        td_audonly.ResponseChar = ResponseChar;
                        td_audonly.VisualStimDVA = VisualStimDVA;
                        TrialDefs.Add(td_audonly);

                        //visual only trial
                        SRT_TrialDef td_visonly = new SRT_TrialDef();
                        td_visonly.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                        td_visonly.Stim_Dur = Stim_Dur;
                        td_visonly.Resp_MaxDur = Resp_MaxDur;
                        td_visonly.VisualStim_Index = VisualStimIndices[iVis];
                        td_visonly.AudioStim_Index = null;
                        td_visonly.FixCrossStimIndex = FixCrossStimIndex;
                        td_visonly.VisualStim_Loc = new Vector3(0, 0, 0);
                        td_visonly.AudioStim_Loc = new Vector3(0, 0, 0);
                        td_visonly.ResponseChar = ResponseChar;
                        td_visonly.VisualStimDVA = VisualStimDVA;
                        TrialDefs.Add(td_visonly);
                    }
                }
            }

            //add extra trials (randomly selected) until we get the right number of trials
            //added in groups of 3 to be able to maintain 33% AV, A, V trials 
            while (TrialDefs.Count < N_Trials)
            {
                SRT_TrialDef td = new SRT_TrialDef();
                td.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                td.Stim_Dur = Stim_Dur;
                td.Resp_MaxDur = Resp_MaxDur;
                td.VisualStim_Index = VisualStimIndices[Random.Range(0, VisualStimIndices.Length)];
                td.AudioStim_Index = AudioStimIndices[Random.Range(0, AudioStimIndices.Length)];
                td.FixCrossStimIndex = FixCrossStimIndex;
                td.VisualStim_Loc = new Vector3(0, 0, 0);
                td.AudioStim_Loc = new Vector3(0, 0, 0);
                td.ResponseChar = ResponseChar;
                td.VisualStimDVA = VisualStimDVA;
                TrialDefs.Add(td);

                if (!CheckTimingTest(()=>Session.SessionDef.UseDigilentDevice))
                {
                    SRT_TrialDef td_audonly = new SRT_TrialDef();
                    td_audonly.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                    td_audonly.Stim_Dur = Stim_Dur;
                    td_audonly.Resp_MaxDur = Resp_MaxDur;
                    td_audonly.VisualStim_Index = null;
                    td_audonly.AudioStim_Index = AudioStimIndices[Random.Range(0, AudioStimIndices.Length)];
                    td_audonly.FixCrossStimIndex = FixCrossStimIndex;
                    td_audonly.VisualStim_Loc = new Vector3(0, 0, 0);
                    td_audonly.AudioStim_Loc = new Vector3(0, 0, 0);
                    td_audonly.ResponseChar = ResponseChar;
                    td_audonly.VisualStimDVA = VisualStimDVA;
                    TrialDefs.Add(td_audonly);

                    SRT_TrialDef td_visonly = new SRT_TrialDef();
                    td_visonly.PreStimDur = Random.Range(PreStim_MinDur, PreStim_MaxDur);
                    td_visonly.Stim_Dur = Stim_Dur;
                    td_visonly.Resp_MaxDur = Resp_MaxDur;
                    td_visonly.VisualStim_Index = VisualStimIndices[Random.Range(0, VisualStimIndices.Length)];
                    td_visonly.AudioStim_Index = null;
                    td_visonly.FixCrossStimIndex = FixCrossStimIndex;
                    td_visonly.VisualStim_Loc = new Vector3(0, 0, 0);
                    td_visonly.AudioStim_Loc = new Vector3(0, 0, 0);
                    td_visonly.ResponseChar = ResponseChar;
                    td_visonly.VisualStimDVA = VisualStimDVA;
                    TrialDefs.Add(td_visonly);
                }
            }

            //Randomize order
            TrialDefs = Shuffle(TrialDefs);
        }

        private bool CheckTimingTest(BoolDelegate tt)
        {
            return tt();
        }

        private static List<T> Shuffle<T>(List<T> ts) {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i) {
                var r = Random.Range(i, count);
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }

            return ts;
        }
    }

    public class SRT_TrialDef : TrialDef
    {
        //Already-existing fields (inherited from TrialDef)
		//public int BlockCount, TrialCountInBlock, TrialCountInTask;
		//public TrialStims TrialStims;
        public float PreStimDur;
        public float Stim_Dur;
        public float Resp_MaxDur;
        public Vector3 VisualStim_Loc;
        public Vector3 AudioStim_Loc;
        public int? VisualStim_Index;
        public int? AudioStim_Index;
        public int? TactileStim_Index;
        public int FixCrossStimIndex;
        public string ResponseChar;
        public float VisualStimDVA;
    }

    public class SRT_StimDef : StimDef
    {
        public float StimFreq;
        public string StimType;
        
        public int AudioStimIndex;
        //Already-existing fields (inherited from Stim  Def)
        //public Dictionary<string, StimGroup> StimGroups; //stimulus type field (e.g. sample/target/irrelevant/etc)
        //public string StimName;
        //public string StimPath;
        //public string PrefabPath;
        //public string ExternalFilePath;
        //public string StimFolderPath;
        //public string StimExtension;
        //public int StimCode; //optional, for analysis purposes
        //public string StimID;
        //public int[] StimDimVals; //only if this is parametrically-defined stim
        //[System.NonSerialized] //public GameObject StimGameObject; //not in config, generated at runtime
        //public Vector3 StimLocation; //to be passed in explicitly if trial doesn't include location method
        //public Vector3 StimRotation; //to be passed in explicitly if trial doesn't include location method
        //public Vector2 StimScreenLocation; //screen position calculated during trial
        //public float? StimScale;
        //public bool StimLocationSet;
        //public bool StimRotationSet;
        //public float StimTrialPositiveFbProb; //set to -1 if stim is irrelevant
        //public float StimTrialRewardMag; //set to -1 if stim is irrelevant
        //public TokenReward[] TokenRewards;
        //public int[] BaseTokenGain;
        //public int[] BaseTokenLoss;
        //public int TimesUsedInBlock;
        //public bool isRelevant;
        //public bool TriggersSonication;
        //public State SetActiveOnInitialization;
        //public State SetInactiveOnTermination;
    
    }
    
    
    public class SRT_SimpleTrialData : USE_Template_DataController
    {
        public override void DefineUSETemplateDataController()
        {
            DataControllerName = "SimpleTrialData";
            AddDatum("SubjectID", () => Session.SubjectID); //session level instead of task level
            AddDatum("SubjectAge", () => Session.SubjectAge);
            AddDatum("SessionTime", () => Session.FilePrefix);
            AddDatum("TaskName", () => Session.TaskLevel != null? Session.TaskLevel.TaskName:"NoTaskActive");
            AddDatum("BlockCount", () => Session.TaskLevel != null ? (Session.TaskLevel.BlockCount + 1).ToString():"NoTaskActive");
            AddDatum("TrialCount_InTask", () => Session.TrialLevel != null ? (Session.TrialLevel.TrialCount_InTask + 1).ToString() : "NoTaskActive");
            AddDatum("TrialCount_InBlock", () => Session.TrialLevel != null ? (Session.TrialLevel.TrialCount_InBlock + 1).ToString() : "NoTaskActive");
            // DataControllerHoldsFrames = true;
        }
    }

    public class DigilentDataController : USE_Template_DataController
    {

        public override void DefineUSETemplateDataController()
        {
            DataControllerName = "DigilentData";
        }
    }
}