using System.Collections.Generic;
using UnityEngine;
using USE_Data;
using USE_ExperimentTemplate_Classes;

public class HaloFBController : MonoBehaviour
{
    public GameObject PositiveHaloPrefab;
    public GameObject NegativeHaloPrefab;

    private GameObject instantiated;
    private bool LeaveFBOn = false;

    public EventCodeManager EventCodeManager;
    public Dictionary<string, EventCode> SessionEventCodes;


    // Logging
    private enum State { None, Positive, Negative };
    private State state;

    public void Init(DataController frameData, EventCodeManager ec)
    {
        frameData.AddDatum("HaloType", () => state.ToString());
        if (instantiated != null) {
            Debug.LogWarning("Initializing HaloFB Controller with an already visible halo");
            Destroy(instantiated);
        }
        instantiated = null;

        EventCodeManager = ec;
    }

    public void SetLeaveFeedbackOn()
    {
        LeaveFBOn = true;
    }
    public void ShowPositive(GameObject gameObj)
    {
        state = State.Positive;
        Show(PositiveHaloPrefab, gameObj);
    }
    
    public void ShowNegative(GameObject gameObj)
    {
        state = State.Negative;
        Show(NegativeHaloPrefab, gameObj);
    }

    private void Show(GameObject haloPrefab, GameObject gameObj)
    {
        if (instantiated != null)
        {
            if (!LeaveFBOn)
            {
                Debug.LogWarning("Trying to show HaloFB but one is already being shown");
                Destroy(instantiated);
            }
        }
        GameObject rootObj = gameObj.transform.root.gameObject;
        instantiated = Instantiate(haloPrefab, rootObj.transform);
        instantiated.transform.SetParent(rootObj.transform);
        EventCodeManager.SendCodeImmediate(SessionEventCodes["HaloFbController_SelectionVisualFbOn"]);

        // Position the haloPrefab behind the game object
        float distanceBehind = 1.5f; // Set the distance behind the gameObj
        Vector3 behindPos = rootObj.transform.position - rootObj.transform.forward * distanceBehind;
        instantiated.transform.position = behindPos;
    }
    

    public void Destroy()
    {
        Destroy(instantiated);
        EventCodeManager.SendCodeImmediate(SessionEventCodes["HaloFbController_SelectionVisualFbOff"]);
        instantiated = null;
        state = State.None;
    }

    public HaloFBController SetHaloSize(float size)
    {
        Light light = PositiveHaloPrefab.GetComponent<Light>();
        light.range = size;
        light = NegativeHaloPrefab.GetComponent<Light>();
        light.range = size;
        return this;
    }

    public HaloFBController SetPositiveHaloColor(Color color)
    {
        PositiveHaloPrefab.GetComponent<Light>().color = color;
        return this;
    }

    public HaloFBController SetNegativeHaloColor(Color color)
    {
        NegativeHaloPrefab.GetComponent<Light>().color = color;
        return this;
    }

    public HaloFBController SetHaloIntensity(float intensity)
    {
        Light light = PositiveHaloPrefab.GetComponent<Light>();
        light.intensity = intensity;
        light = NegativeHaloPrefab.GetComponent<Light>();
        light.intensity = intensity;
        return this;
    }

}