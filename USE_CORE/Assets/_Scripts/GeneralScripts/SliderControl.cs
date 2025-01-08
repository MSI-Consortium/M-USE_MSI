using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public bool AnimationOn = false;
    public float TargetValue;
    public Slider Slider;
    public float AnimationDuration = 60;

    private float AnimationStartTime;
    private bool AnimationStarted;
    // Update is called once per frame
    void Update()
    {
        if (AnimationOn)
        {
            if (!AnimationStarted)
            {
                AnimationStartTime = Time.time;
                AnimationStarted = true;
            }
            float progress = (Time.time - AnimationStartTime) / AnimationDuration;
            Debug.Log("Current Value = " + Slider.value + ", Target Value: " + TargetValue);
            Slider.value = Mathf.Lerp(Slider.value, TargetValue, progress);
            if (Math.Abs(Slider.value - TargetValue) <= 0.01)
            {
                Slider.value = TargetValue;
                AnimationOn = false;
                AnimationStarted = false;
            }
        }
    }
}
