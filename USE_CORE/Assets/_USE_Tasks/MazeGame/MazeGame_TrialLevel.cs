using UnityEngine;
using USE_ExperimentTemplate;
using USE_States;
using USE_StimulusManagement;
using MazeGame_Namespace;


using HiddenMaze;
using UnityEngine.SceneManagement;
using USE_StimulusManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Data;

public class MazeGame_TrialLevel : ControlLevel_Trial_Template
{
    public MazeGame_TrialDef CurrentTrialDef => GetCurrentTrialDef<MazeGame_TrialDef>();


    // public MazeGame_BlocklDef CurrentBlockDef => GetCurrentBlockDef<MazeGame_BlockDef>();




    public List<Maze> mazeList = new List<Maze>();
    static bool end;
    private int dim;
    public int ind; 
    //game configs variables
    public float SCREEN_WIDTH;
    public float TILE_WIDTH;

    public Color START_COLOR;
    public Color FINISH_COLOR;
    public Color CORRECT_COLOR;
    public Color LAST_CORRECT_COLOR;
    public Color INCORRECT_RULEABIDING_COLOR;
    public Color INCORRECT_RULEBREAKING_COLOR;
    public Color DEFAULT_TILE_COLOR;

    public float CORRECT_FEEDBACK_SECONDS;
    public float PREV_CORRECT_FEEDBACK_SECONDS;
    public float INCORRECT_RULEABIDING_SECONDS;
    public float INCORRECT_RULEBREAKING_SECONDS;

    public float TIMEOUT_SECONDS;

    
    //MazeVis Variables
    public TileRow[] tileRows;

    public static GameObject mazeListObj;
    public LoadMazeList mazeListScript;
   // public static GameConfigs gameConfigs = new GameConfigs();
    public static Maze currMaze;
    private bool mazeLoaded = false;
    private static int count;
    private Tile tile;

    StimGroup tiles; // top of triallevel with other variable defs

    private static Slider slider;
    private static float sliderValueIncreaseAmount;
    private GameObject initButton;
    //private Button initButton;
    private Ray mouseRay;
    private int response;
    private GameObject sliderHalo, txt, startTxt;
    private SpriteRenderer sr;
    private float startTime;
    private int max;
    private int min;
    private static int numReps;
    private static int curRep;
    private int trialIndex;
    public static int totalErrors = 0;
    public static int ruleAbidingErrors = 0;
    public static int ruleBreakingErrors = 0;
    public static int retouchCorrect = 0;
    public static int correctTouches = 0;

    public static Color tileColor;
    public static int textureNum;

    public int curMDim;
    public int curMNumSquares;
    public int curMNumTurns;
    public string curMPath;
    public static bool viewPath = false;
    public static bool c;

    public override void DefineControlLevel()
    {
        
         
           

        //define States within this Control Level
        State StartButton = new State("StartButton");
        State LoadMaze = new State("LoadMaze");
        State GameConf = new State("GameConf");
        State MazeVis = new State("MazeVis");
        State Feedback = new State("Feedback");
        State ITI = new State("ITI");
        AddActiveStates(new List<State> { StartButton, LoadMaze, GameConf, MazeVis, Feedback, ITI });

        string[] stateNames = new string[] { "StartButton", "LoadMaze", "GameConf", "MazeVis", "Feedback", "ITI" };

        SetupTrial.SpecifyTermination(() => true, LoadMaze);

        SelectionHandler<MazeGame_StimDef> mouseHandler = new SelectionHandler<MazeGame_StimDef>();

            // Define stimOn state
        LoadMaze.AddInitializationMethod(() =>
        {
          //  Camera.main.backgroundColor = new Color(1f, 0.5f, 1f);
            Material newMat = Resources.Load("BG_Materials/Skybox_2", typeof(Material)) as Material;
            //System.Random rnd = new System.Random();
            //int num = rnd.Next(0, 9);
            int num = 9;
            //  gameObject.GetComponent<MeshRenderer>().material = newMat;
           string textStr = "Textures/Picture" + num.ToString();
            Texture newTxt = Resources.Load(textStr, typeof(Texture)) as Texture;
            newMat.SetTexture("_MainTex", newTxt);
         //   Canvas c = GameObject.Find("Canvas").GetComponent<Canvas>();
            //CanvasRenderer cr = c.GetComponents<Renderer>;
          //  c.GetComponent<Image>().material = newMat;
           // c.GetComponent<Image>().SetMaterial(newMat, newTxt);

            //  CanvasRenderer.SetMaterial(newMat, newTxt);
            if (CurrentTrialDef.viewPath == 1)
            {
                viewPath = true;
            }
            else
            {
                viewPath = false;
            }
            DataTable tbl = new DataTable();

            tbl.Columns.Add(new DataColumn("dim"));
            tbl.Columns.Add(new DataColumn("numSquares"));
            tbl.Columns.Add(new DataColumn("numTurns"));
            tbl.Columns.Add(new DataColumn("mPath"));


            string[] lines = System.IO.File.ReadAllLines("Assets/MazeGameTest/Resources/AllMazes.txt");

            curMDim = CurrentTrialDef.mazeDim;
            curMNumSquares = CurrentTrialDef.mazeNumSquares;
            curMNumTurns = CurrentTrialDef.mazeNumTurns;

            string search = "";
            string and = "";
            if (curMDim != null)
            {
                search = search + "dim = " + curMDim.ToString();
                and = " AND ";
            }
            if (curMNumSquares != null)
            {
                search = search + and + "numSquares = " + curMNumSquares.ToString();
                and = " AND ";
            }
            if (curMDim != null)
            {
                search = search + and + "numTurns = " + curMDim.ToString();
            }

            foreach (string line in lines)
            {
                var cols = line.Split('\t');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < 4; cIndex++)
                {
                    dr[cIndex] = cols[cIndex];
                }

                tbl.Rows.Add(dr);
            }
            Debug.Log("TESTROWS");

            /* DataRow[] testRows = tbl.Select();
             foreach (DataRow row in testRows)
             {
                 Debug.Log(row[0].ToString() + "   " + row[1].ToString() + "   " + row[2].ToString() + "   " + row[3].ToString());
             }

             Debug.Log("ROWS");
             */
            DataRow[] rows = tbl.Select(search);
            //WHY DOESNT THIS WORK FOR 3???
            foreach (DataRow row in rows)
            {
                Debug.Log(row[0].ToString() + "   " + row[1].ToString() + "   " + row[2].ToString() + "   " + row[3].ToString());
                curMPath = row[3].ToString();
                ind = tbl.Rows.IndexOf(row);

            }
            Debug.Log("LENGTH");
            Debug.Log(rows.Length);
            // Debug.Log(rows[0].Length);




            // min = CurrentTrialDef.nRepetitionsMinMax[0];
            //   max = CurrentTrialDef.nRepetitionsMinMax[1];
            trialIndex = CurrentTrialDef.TrialCount - 1;
            Debug.Log("INDEX: " + trialIndex);
        //   System.Random rnd = new System.Random();
        //  numReps = rnd.Next(min, max);
        totalErrors = 0;
        ruleAbidingErrors = 0;
        ruleBreakingErrors = 0;
        retouchCorrect = 0;
        correctTouches = 0;

            if (count == 0)
            {
                slider = GameObject.Find("Slider").GetComponent<Slider>();

                initButton = GameObject.Find("StartButton");


                txt = GameObject.Find("FinalText");
                startTxt = GameObject.Find("StartText");

                sliderHalo = GameObject.Find("SliderHalo");
                Debug.Log("HALO FOUND");
                sr = sliderHalo.GetComponent<SpriteRenderer>();

                count = 0;
                // Load maze from JSON
                TextAsset[] textMazes = Resources.LoadAll<TextAsset>("Mazes");

                foreach (TextAsset textMaze in textMazes)
                {
                    string mazeJson = textMaze.text;
                    Maze mazeObj = new Maze(mazeJson);
                    Debug.Log(mazeObj);
                    mazeList.Add(mazeObj);
                }

                foreach (Maze maze in mazeList)
                {
                    // TODO: Here is where the maze levels can be put in order
                }
            }
            else
            {
                RenderSettings.skybox = newMat;
            }
            slider.gameObject.SetActive(true);
            initButton.gameObject.SetActive(true);
            startTxt.gameObject.SetActive(true);
            Debug.Log("CHECK");


        });

        LoadMaze.SpecifyTermination(() => true, GameConf);


        GameConf.AddInitializationMethod(() =>
        {
            textureNum = CurrentTrialDef.Texture;

            // MAZE GAME WIDTHS
            ///*
            // TODO: Not implemented, but this should be the maximum screen width that tiles can take up without overfilling the screen
            SCREEN_WIDTH = 4;

             // Default tile width
             TILE_WIDTH = 0.5f;

             //---------------------------------------------------------

             // TILE COLORS

             // Start - Light yellow
             START_COLOR = new Color(0.94f, 0.93f, 0.48f);

             // Finish - Light blue
             FINISH_COLOR = new Color(0.37f, 0.59f, 0.94f);

             // Correct - Light green
             CORRECT_COLOR = new Color(0.62f, 1f, 0.5f);

             // Prev correct - Darker green
             LAST_CORRECT_COLOR = new Color(0.2f, 0.7f, 0.5f);

             // Incorrect rule-abiding - Orange
             INCORRECT_RULEABIDING_COLOR = new Color(1f, 0.5f, 0.25f);

             // Incorrect rule-breaking - Black
             INCORRECT_RULEBREAKING_COLOR = new Color(0f, 0f, 0f);

             // Default - Off-white
             // DEFAULT_TILE_COLOR = new Color(0.95f, 0.95f, 0.95f);
             DEFAULT_TILE_COLOR = new Color(CurrentTrialDef.TileColor[0], CurrentTrialDef.TileColor[1], CurrentTrialDef.TileColor[2]);
             //---------------------------------------------------------

             tileColor = new Color(CurrentTrialDef.TileColor[0], CurrentTrialDef.TileColor[1], CurrentTrialDef.TileColor[2]);
             // FEEDBACK LENGTH IN SECONDS

             // Correct - 0.5 seconds
             CORRECT_FEEDBACK_SECONDS = 0.5f;

             // Prev correct - 0.5 seconds
             PREV_CORRECT_FEEDBACK_SECONDS = 0.5f;

             // Incorrect rule-abiding - 0.5 seconds
             INCORRECT_RULEABIDING_SECONDS = 0.5f;

             // Incorrect rule-breaking - 1.0 seconds
             INCORRECT_RULEBREAKING_SECONDS = 1.0f;

             //---------------------------------------------------------

             // TIMEOUT

             TIMEOUT_SECONDS = 10.0f; 
            // */
            //gameConfigs.DEFAULT_TILE_COLOR = new Color(CurrentTrialDef.TileColor[0], CurrentTrialDef.TileColor[1], CurrentTrialDef.TileColor[2]);
            tileColor = new Color(CurrentTrialDef.TileColor[0], CurrentTrialDef.TileColor[1], CurrentTrialDef.TileColor[2]);

        });

        GameConf.SpecifyTermination(() => true, StartButton);

        MouseTracker.AddSelectionHandler(mouseHandler, StartButton);
        // define initScreen state
        StartButton.AddInitializationMethod(() =>
        {
            response = -1;
            txt.gameObject.SetActive(false);
            sliderHalo.SetActive(false);
            curRep = 0;

        });


        StartButton.AddUpdateMethod(() =>
        {
            
            if (InputBroker.GetMouseButtonDown(0))
            {
                mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                //initButton.OnClick
                RaycastHit hit;
                if (Physics.Raycast(mouseRay, out hit))
                {
                    if (hit.transform.name == "StartButton")
                    {
                        response = 0;

                    }
                } 
            } 

        });
      //  StartButton.SpecifyTermination(() => mouseHandler.SelectionMatches(initButton), MazeVis);
        StartButton.SpecifyTermination(() => response == 0, MazeVis);

        StartButton.AddDefaultTerminationMethod(() =>
        {
            startTxt.gameObject.SetActive(false);
            initButton.gameObject.SetActive(false);

        });

        MazeVis.AddInitializationMethod(() =>
        {
            //  if (!mazeLoaded)
            // {
            //   mazeLoaded = true;
            Debug.Log(count);

                end = false;
                Debug.Log("entered inst");
            slider.value = 0;

            InstantiateCurrMaze();
          
          // if (c)
          // {
             //  AudioFBController.Play("Positive");

          // }
         // else
         // {
             //   AudioFBController.Play("Negative");
         // }


        });

        MazeVis.AddUpdateMethod(() =>
        {
            
        });
        MazeVis.SpecifyTermination(() => end == true, Feedback);
        // MazeVis.SpecifyTermination(() => end == true && count < mazeList.Count, MazeVis);
        //MazeVis.SpecifyTermination(() => end == true && count >= mazeList.Count, Feedback);
        MazeVis.AddDefaultTerminationMethod(() =>
        {
            DestroyCurrMaze();
           // end = false;
        });

        Feedback.AddInitializationMethod(() =>
        {
            Debug.Log("the end");
            sliderHalo.SetActive(true);
            // sphereCount = 0;
            sr.color = new Color(1, 1, 1, 0.2f);
            txt.SetActive(true);
            initButton.gameObject.SetActive(true);

            startTime = Time.time;

        });

        Feedback.AddUpdateMethod(() =>
        {
            if ((int)(10 * (Time.time - startTime)) % 4 == 0)
            {
                sr.color = new Color(1, 1, 1, 0.2f);
            }
            else if ((int)(10 * (Time.time - startTime)) % 2 == 0)
            {
                sr.color = new Color(1, 0, 0, 0.2f);
            }
        });
        Feedback.AddTimer(3f, ITI, () =>
        {

            txt.SetActive(false);
            initButton.gameObject.SetActive(false);

            sliderHalo.SetActive(false);
            slider.gameObject.SetActive(false);

        });

      //  Feedback.SpecifyTermination(() => count < mazeList.Count, MazeVis);
      //  Feedback.SpecifyTermination(() => count >= mazeList.Count, Feedback);

        //Define iti state
        ITI.AddInitializationMethod(() =>
        {

        });
        ITI.SpecifyTermination(() => true, FinishTrial, () => Debug.Log("Trial" + " completed"));
        /*
               
                TrialData.AddDatum("TrialID", () => CurrentTrialDef.TrialID);
                TrialData.AddDatum("TouchedObjects", () => touchedObj);
                TrialData.AddDatum("SlotError", () => slotError);
                TrialData.AddDatum("RepetitionError", () => repetitionError);
                */
        Debug.Log("ERRORS: " + totalErrors);
        TrialData.AddDatum("TrialNum", () => CurrentTrialDef.TrialCount);
        TrialData.AddDatum("TotalErrors", () => totalErrors);
        TrialData.AddDatum("Rule-Abiding Errors", () => ruleAbidingErrors);
        TrialData.AddDatum("Rule-Breaking Errors", () => ruleBreakingErrors);
        TrialData.AddDatum("RetouchCorrect", () => retouchCorrect);



    }

    void InstantiateCurrMaze()
    {

       // sliderInitPosition = slider.gameObject.transform.position;



         slider.gameObject.SetActive(true);

        Debug.Log("Count: " + count);
      /*  TextAsset textMaze = Resources.Load<TextAsset>("output_mazes_json/3.6.3.c342e0c2-962d-4079-a198-ca04550a9a4f");
        string mazeJson = textMaze.text;
        Maze currMaze = new Maze(mazeJson);
        Debug.Log(currMaze);
        */
        TextAsset[] textMazes = Resources.LoadAll<TextAsset>("output_mazes_json");

        foreach (TextAsset textMaze in textMazes)
        {
            string mazeJson = textMaze.text;
            Maze mazeObj = new Maze(mazeJson);
            Debug.Log(mazeObj);
            mazeList.Add(mazeObj);
        }
        currMaze = mazeList[ind];
       

        /*   TextAsset[] textMazes = Resources.LoadAll<TextAsset>("Mazes");

           foreach (TextAsset textMaze in textMazes)
           {
               string mazeJson = textMaze.text;
               Maze mazeObj = new Maze(mazeJson);
               Debug.Log(mazeObj);
               mazeList.Add(mazeObj);
           }
           currMaze = mazeList[trialIndex];
           Debug.Log("index: " + trialIndex);
           */

        if (count != 0)
        {
            //   DestroyCurrMaze();
            // tile.gameObject.SetActive(true);

        } 

        dim = currMaze.mConfigs.dim;

        sliderValueIncreaseAmount = (100f / (currMaze.mNumSquares)) / 100f;

        //     tileRows = new TileRow[dim];
        Debug.Log("DIM: " + dim);


        GameObject mazeCenter = GameObject.FindWithTag("Center");

        float mazeWidth = dim * TILE_WIDTH;
        Vector3 bottomLeftMazePos = mazeCenter.transform.position - (new Vector3(mazeWidth / 2, mazeWidth / 2, 0));



        /*
        for (int x = 0; x < dim; ++x)
        {
            for (int y = 0; y < dim; ++y)
            {
                GameObject c = GameObject.CreatePrimitive(PrimitiveType.Cube);
               // c.transform.position = new Vector3(0, 1.5f, 0);
                if (count != 0)
                {
                    c.gameObject.SetActive(true);
                    c.gameObject.GetComponent<Tile>().enabled = true;
                }


                //    if (count == 0)
                //  {
                float displaceX = x * TILE_WIDTH;
                float displaceY = y * TILE_WIDTH;
                Vector3 newTilePosition = bottomLeftMazePos + new Vector3(displaceX, displaceY, 1);
                // Instantiate the tile

                c.transform.position = newTilePosition;
                c.transform.localScale = new Vector3(0.5f, 0.5f, 1.5f);

                // c.mCoord = new Coords(x, y);

                // Instantiate the row and assign the tile in the row
                //       tileRows[x] = new TileRow(dim);
                // tileRows[x].mTiles[y] = tile;

                // }

                //  Tile instTile = Instantiate(tile);
                Renderer tileRend = c.GetComponent<Renderer>();



                Color tileColor;

                if (x == currMaze.mStart.X && y == currMaze.mStart.Y)
                {
                    tileColor = START_COLOR;

                }
                else if (x == currMaze.mFinish.X && y == currMaze.mFinish.Y)
                {
                    tileColor = FINISH_COLOR;

                }
                else
                {
                    tileColor = DEFAULT_TILE_COLOR;
                }

                tileRend.material.SetColor("_BaseColor", tileColor);

                // instTile.transform.SetParent(this.transform);
                // instTile.gameObject.SetActive(false);
                // tileRows[x].mTiles[y] = instTile;
                // tiles.AddStims(tile.gameObject); //on creation of tile GameObject
                //  tiles.AddStims(instTile.gameObject); //on creation of tile GameObject

            }
        }
        */

        
                  tile = Resources.Load<Tile>("Prefabs/Tile") as Tile;

                  tiles = new StimGroup("Tiles"); //in DefineTrialStims
                                                  // tiles.DestroyStimGroup(); //when tiles should be destroyed

                  for (int x = 0; x < dim; ++x)
                  {
                      for (int y = 0; y < dim; ++y)
                      {
                          if (count != 0)
                          {
                              tile.gameObject.SetActive(true);
                              tile.gameObject.GetComponent<Tile>().enabled = true;
                          }


                          //    if (count == 0)
                          //  {
                          float displaceX = x * TILE_WIDTH;
                          float displaceY = y * TILE_WIDTH;
                          Vector3 newTilePosition = bottomLeftMazePos + new Vector3(displaceX, displaceY, 0);
                          // Instantiate the tile

                          tile.transform.position = newTilePosition;
                          tile.mCoord = new Coords(x, y);

                // Instantiate the row and assign the tile in the row
                //       tileRows[x] = new TileRow(dim);
                // tileRows[x].mTiles[y] = tile;

                // }

                // Tile instTile = Instantiate(tile);
                //  Renderer tileRend = instTile.GetComponent<Renderer>();

           


                //  Color tileColor;

                if (x == currMaze.mStart.X && y == currMaze.mStart.Y)
                          {
                    Debug.Log("SET COLOR");

                    tile.gameObject.GetComponent<Tile>().setColor(START_COLOR);
                     // tileColor = START_COLOR;
                  //  tileColor = FINISH_COLOR;



                }
                else if (x == currMaze.mFinish.X && y == currMaze.mFinish.Y)
                          {
                    tile.gameObject.GetComponent<Tile>().setColor(FINISH_COLOR);

                    

                          }
                          else
                          {
                    tile.gameObject.GetComponent<Tile>().setColor(DEFAULT_TILE_COLOR);

                    // tileColor = DEFAULT_TILE_COLOR;

                }


                // tileRend.material.SetColor("_BaseColor", tileColor);
                // instTile.gameObject.GetComponent<Renderer>().material.color = FINISH_COLOR;

                Tile instTile = Instantiate(tile);
                instTile.transform.SetParent(this.transform);


                // instTile.gameObject.SetActive(false);
                // tileRows[x].mTiles[y] = instTile;
                // tiles.AddStims(tile.gameObject); //on creation of tile GameObject
                tiles.AddStims(instTile.gameObject); //on creation of tile GameObject

                      }

        } 

            Debug.Log("end");

    }


    void DestroyCurrMaze()
    {
        Debug.Log("entered destroy");
        Debug.Log("dim: " + dim);
        tile.gameObject.SetActive(false);
        tile.gameObject.GetComponent<Tile>().enabled = false;
     //   slider.gameObject.SetActive(false);
        //  Destroy(tile);

        for (int x = 0; x < dim; ++x)
        {
            for (int y = 0; y < dim; ++y)
            {
                Debug.Log("FIRST: " + x + ", " + y);
                // tileRows[x].mTiles[y].GetComponent<Tile>().enabled = false;
                // Tile temp = tileRows[x].mTiles[y];
                // temp.gameObject.SetActive(false);

                tiles.DestroyStimGroup();
                // Destroy(tileRows[x].mTiles[y]);
                Debug.Log(x + ", " + y);

            }
            //tileRows[x].gameObject.SetActive(false);
        }
        Debug.Log("maze should be gone");
    }

    public static void setEnd(int i)
    {
        if(i == 0 || i==1)
        {
            slider.value += sliderValueIncreaseAmount;
        }
        if (i == 99)
        {
            slider.value += sliderValueIncreaseAmount;
           // if(curRep < numReps)
           // {
            //    ++curRep;
           // }
            //else
           // {
                ++count;
             //   curRep = 0;
          //  }
            end = true;
        }
        float progress = (float)correctTouches / (float)currMaze.mNumSquares;
        float ratio = (float)correctTouches / (float)totalErrors;
        Debug.Log("Progress: " + progress);
        Debug.Log("Accuracy: " + ratio);

    }

 
    // ManageTileTouch - Returns correctness code
    // Return values:
    // 0 - correct and regular tile
    // 1 - correct and start tile
    // 99 - correct and finish (maze is complete)

    // 30 - previous correct tile
    // 31 - previous correct tile and start

    // 10 - rule-abiding incorrect
    // 11 - rule-abiding incorrect and start
    // 12 - rule-abiding incorrect and finish

    // 20 - rule-breaking incorrect
    // 21 - rule-breaking incorrect and start
    // 22 - rule-breaking incorrect and finish
    public static int ManageTileTouch(Tile tile)
    {
        Coords touchedCoord = tile.mCoord;

        // CORRECT DEFAULT
        if (touchedCoord == currMaze.mNextStep && touchedCoord != currMaze.mStart && touchedCoord != currMaze.mFinish)
        {
            Debug.Log("correct");
            correctTouches++;


            // Every tile in maze is unique in path, path should NOT contain same tile twice
            currMaze.mNextStep = currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == touchedCoord) + 1];
            return 0;
        }

        // CORRECT and START
        else if (touchedCoord == currMaze.mStart && touchedCoord == currMaze.mNextStep)
        {
            Debug.Log("**** started maze ****");
            correctTouches++;

            currMaze.mNextStep = currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == touchedCoord) + 1];
            return 1;
        }

        // CORRECT and FINISH
        else if (touchedCoord == currMaze.mFinish && touchedCoord == currMaze.mNextStep)
        {
            Debug.Log("**** finished maze! ****");
            // ++count;
            /*   Debug.Log("Changing scene to ?...");
               SceneManager.UnloadSceneAsync("MazeScene");
               SceneManager.LoadSceneAsync("MazeScene");
               SceneManager.SetActiveScene(SceneManager.GetSceneByName("MazeScene")); */
        Debug.Log("restarted maze");
            // TODO: add maze finish operations
            currMaze.mNextStep = currMaze.mStart;
            //   mazeLoaded = false;
            //  end = true; 
            correctTouches++;
            return 99;
        }

        // LAST CORRECT STEP DEFAULT
        else if (touchedCoord != currMaze.mStart && touchedCoord == currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == currMaze.mNextStep) - 1])
        {
            Debug.Log("last correct step");
            retouchCorrect++;

            return 30;
        }

        // LAST CORRECT STEP and START
        else if (touchedCoord == currMaze.mStart && touchedCoord == currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == currMaze.mNextStep) - 1])
        {
            Debug.Log("last correct step");
            retouchCorrect++;

            return 31;
        }

        // RULE-ABIDING INCORRECT DEFAULT
        // Check if this isn't the first touch and the touch was adjacent to the previous correct tile
        // In order for something to be a rule-abiding touch, there must have already been at least one correct touch on the start tile
        else if ((currMaze.mNextStep != currMaze.mStart) && touchedCoord.isAdjacentTo(currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == currMaze.mNextStep) - 1])
                  && touchedCoord != currMaze.mStart
                  && touchedCoord != currMaze.mFinish)
        {
            Debug.Log("rule-abiding incorrect");
            totalErrors++;
            ruleAbidingErrors++;

            return 10;
        }

        // RULE-ABIDING INCORRECT and START
        else if ((currMaze.mNextStep != currMaze.mStart) && touchedCoord.isAdjacentTo(currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == currMaze.mNextStep) - 1])
                  && touchedCoord != currMaze.mFinish)
        {
            Debug.Log("rule-abiding incorrect");
            totalErrors++;
            ruleAbidingErrors++;
            return 11;
        }

        // RULE-ABIDING INCORRECT and FINISH
        else if ((currMaze.mNextStep != currMaze.mStart) && touchedCoord.isAdjacentTo(currMaze.mPath[currMaze.mPath.FindIndex(pathCoord => pathCoord == currMaze.mNextStep) - 1]))
        {
            Debug.Log("rule-abiding incorrect");
            totalErrors++;
            ruleAbidingErrors++;
            return 12;
        }

        // RULE-BREAKING INCORRECT DEFAULT
        else if (touchedCoord != currMaze.mStart && touchedCoord != currMaze.mFinish)
        {
            Debug.Log("rule-breaking incorrect");
            totalErrors++;
            ruleBreakingErrors++;
            return 20;
        }

        // RULE-BREAKING INCORRECT and START
        else if (touchedCoord != currMaze.mFinish)
        {
            Debug.Log("rule-breaking incorrect");
            totalErrors++;
            ruleBreakingErrors++;
            return 21;
        }

        // RULE-BREAKING INCORRECT and FINISH
        else
        {
            Debug.Log("rule-breaking incorrect");
            totalErrors++;
            ruleBreakingErrors++;
            return 22;
        }
    }
    protected override void DefineTrialStims()
    {
        //Define StimGroups consisting of StimDefs whose gameobjects will be loaded at TrialLevel_SetupTrial and 
        //destroyed at TrialLevel_Finish
    }
    
}