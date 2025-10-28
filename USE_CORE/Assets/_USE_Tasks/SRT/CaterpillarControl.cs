using UnityEngine;
using System.IO.Ports;
// using System;
// using System.Buffers;

public class CaterpillarControl //collisionTrigger //: MonoBehaviour
{
    public SerialPort _serialPort;
    private byte[] onCat;
    private byte[] offCat;
    private byte[] setVibFreq;
    private int module;
    private int stim;
    private int startCat;
    private int stopCat;
    private int setVib;
    private int vibFreq;
    
    public float waitTime = 0.03f;
    public float timer = 0.0f;
    public bool catIsOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitCat()
    {

        string[] ports = SerialPort.GetPortNames();
        Debug.Log("Ports: ");
        for (int i = 0; i < ports.Length; i++)
        {
            Debug.Log(ports[i]);
        }

        // Create a new SerialPort object with caterpillar settings.
        _serialPort = new SerialPort(ports[1], 250000, Parity.None, 8, StopBits.One);
        _serialPort.ReadTimeout = 500;
        _serialPort.Open();

        module = 0x81;          //serial number of the caterpillar 80+value (if you use only one it will be 1 so 81)
        stim = 0x21;            // value to tell caterpillar to trigger vibration
        startCat = 0x11;        //start the stimulus
        stopCat = 0x00;         // stop the stimulus (we add other zeroes in the end of the byte array for safety)
        setVib = 0x20;          // value to tell caterpillar you want to set vibration frequency
        vibFreq = 0x60;         // the frequency you want to set (refer to manual)

        onCat = new byte[6];
        offCat = new byte[6];
        setVibFreq = new byte[6];

        onCat[0] = (byte)module;
        onCat[1] = (byte)stim;
        onCat[2] = (byte)startCat;
        onCat[3] = (byte)stopCat;
        onCat[4] = (byte)stopCat;
        onCat[5] = (byte)stopCat;

        offCat[0] = (byte)module;
        offCat[1] = (byte)stim;
        offCat[2] = (byte)stopCat;
        offCat[3] = (byte)stopCat;
        offCat[4] = (byte)stopCat;
        offCat[5] = (byte)stopCat;

        setVibFreq[0] = (byte)module;
        setVibFreq[1] = (byte)setVib;
        setVibFreq[2] = (byte)vibFreq;
        setVibFreq[3] = (byte)stopCat;
        setVibFreq[4] = (byte)stopCat;
        setVibFreq[5] = (byte)stopCat;

        _serialPort.Write(setVibFreq, 0, setVibFreq.Length); //set vibration frequency at the beginning
        
    }

    public void TurnTactileStimOn()
    {
        _serialPort.Write(onCat, 0, onCat.Length);
    }

    public void TurnTactileStimOff()
    {
        _serialPort.Write(offCat, 0, offCat.Length);
    }
    
    // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if ((timer > waitTime) && catIsOn)
    //     {
    //         Debug.Log("write OFF cat");
    //         _serialPort.Write(offCat, 0, offCat.Length);
    //         catIsOn = false;
    //     }
    //
    // }
    //
    // void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("write ON Cat");
    //      _serialPort.Write(onCat, 0, onCat.Length);
    //     catIsOn = true;
    //     timer = 0f;
    //
    //
    // }
}
