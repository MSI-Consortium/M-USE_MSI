﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using USE_Settings;

public class DisplaySwitcher : MonoBehaviour {

	public bool toggleDisplay = false;

	// Use this for initialization
	void Start () {
		toggleDisplay = (bool)SessionSettings.Get("sessionConfig", "toggledisplay");//ConfigReader.Get("sessionConfig").Bool["toggledisplay"];
	}

	void ToggleDisplay(){
		if(toggleDisplay){
			var cams = GameObject.FindObjectsOfType<Camera>();
			foreach(Camera c in cams){
				c.targetDisplay = 1 - c.targetDisplay; // 1 - 0 = 1; 1 - 1 = 0
			}

			var canvases = GameObject.FindObjectsOfType<Canvas>();
			foreach(Canvas c in canvases){
				c.targetDisplay = 1 - c.targetDisplay; // 1 - 0 = 1; 1 - 1 = 0
			}
			toggleDisplay = false;
		}
	}

	void Update(){
		if(InputBroker.GetKeyUp(KeyCode.W)){
			toggleDisplay = true;
		}
		ToggleDisplay();
	}
}