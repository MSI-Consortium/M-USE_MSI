﻿using UnityEngine;
using USE_ExperimentTemplate;
using USE_StimulusManagement;

namespace MazeGame_Namespace
{
    public class MazeGame_TaskDef : TaskDef
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

        public float[] TileColor;


    }

    public class MazeGame_BlockDef : BlockDef
    {
        //Already-existing fields (inherited from BlockDef)
        //public int BlockCount;
        //public TrialDef[] TrialDefs;

       // public string TrialID;
       // public int Context;
        public int Trial;

        public int[] nRepetitionsMinMax;
      //  public Color TileColor;
        public float[] TileColor;
        public int Texture;
        public int mazeDim;
        public int mazeNumSquares;
        public int mazeNumTurns;
        public int viewPath; 
     //   public string mazePath;

        //  public float MinTouchDuration;
        //  public float MaxTouchDuration;


        public override void GenerateTrialDefsFromBlockDef()
        {
            //pick # of trials from minmaxokay 
            // System.Random rnd = new System.Random();
            // int num = rnd.Next(nRepetitionsMinMax[0], nRepetitionsMinMax[1]);
            TrialDefs = new TrialDef[1];//actual correct # 
            for (int iTrial = 0; iTrial < TrialDefs.Length; iTrial++)
            {
                MazeGame_TrialDef td = new MazeGame_TrialDef();
                td.TrialCount = Trial;
                td.TileColor = TileColor;
                td.Texture = Texture;
                td.mazeDim = mazeDim;
                td.mazeNumSquares = mazeNumSquares;
                td.mazeNumTurns = mazeNumTurns;
                td.viewPath = viewPath;
               // td.mazePath = mazePath;
                if (td.TileColor == null && TileColor != null)
                    td.TileColor = TileColor;

             //   if (td.Texture == null && Texture != null)
                 //   td.Texture = Texture;
                //  Debug.Log("TRIAL: " + Trial);
                //   td.TrialID = TrialID;
                //   td.Context = Context;
                // td.MinTouchDuration = MinTouchDuration;
                //   td.MaxTouchDuration = MaxTouchDuration;

                TrialDefs[iTrial] = td;
            }
        }

        
    }

    public class MazeGame_TrialDef : TrialDef
    {
        //Already-existing fields (inherited from TrialDef)
        //public int BlockCount, TrialCountInBlock, TrialCountInTask;
        //public TrialStims TrialStims;
        public int TrialCount;
        public float[] TileColor;
        public int Texture;
        public int mazeDim;
        public int mazeNumSquares;
        public int mazeNumTurns;
        public int viewPath;

        //   public string mazePath;

        // public int[] nRepetitionsMinMax;
    }

    public class MazeGame_StimDef : StimDef
    {
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
       // public int test;
    }
}