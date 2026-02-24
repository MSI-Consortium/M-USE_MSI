using UnityEngine;
using System.IO.Ports;
// using System;
// using System.Buffers;

public class CaterpillarControl : MonoBehaviour
{
    public SerialPort _serialPort;
    private byte[] onTac;
    private byte[] offTac;
    private byte[] setTacFreq;
    private int module;
    private int tacStim;
    private int startCat;
    private int stopCat;
    private int setVib;
    private int vibFreq;
    
    public float waitTime = 0.03f;
    public float timer = 0.0f;
    public bool catIsOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void InitCat(string portstring)
    {

        // string[] ports = SerialPort.GetPortNames();
        // Debug.Log("Ports: ");
        // for (int i = 0; i < ports.Length; i++)
        // {
        //     Debug.Log(ports[i]);
        // }
        //
        // string portname = "/dev/tty.usbserial-AV0K3FPG";
        // Create a new SerialPort object with caterpillar settings.
        _serialPort = new SerialPort(portstring, 250000, Parity.None, 8, StopBits.One);
        _serialPort.ReadTimeout = 500;
        _serialPort.Open();

        module = 0x81;          //serial number of the caterpillar 80+value (if you use only one it will be 1 so 81)
        tacStim = 0x21;            // value to tell caterpillar to trigger vibration
        startCat = 0x11;        //start the stimulus
        stopCat = 0x00;         // stop the stimulus (we add other zeroes in the end of the byte array for safety)
        setVib = 0x20;          // value to tell caterpillar you want to set vibration frequency
        vibFreq = 0x60;         // the frequency you want to set (refer to manual)
        //appropriate hex values for vis/aud Stim
        
        
        onTac = new byte[6];
        offTac = new byte[6];
        setTacFreq = new byte[6];
        
        //on+ off for vis / aud
        //set visfreq
        

        onTac[0] = (byte)module;
        onTac[1] = (byte)tacStim;
        onTac[2] = (byte)startCat;
        onTac[3] = (byte)stopCat;
        onTac[4] = (byte)stopCat;
        onTac[5] = (byte)stopCat;

        offTac[0] = (byte)module;
        offTac[1] = (byte)tacStim;
        offTac[2] = (byte)stopCat;
        offTac[3] = (byte)stopCat;
        offTac[4] = (byte)stopCat;
        offTac[5] = (byte)stopCat;

        setTacFreq[0] = (byte)module;
        setTacFreq[1] = (byte)setVib;
        setTacFreq[2] = (byte)vibFreq;
        setTacFreq[3] = (byte)stopCat;
        setTacFreq[4] = (byte)stopCat;
        setTacFreq[5] = (byte)stopCat;

        _serialPort.Write(setTacFreq, 0, setTacFreq.Length); //set vibration frequency at the beginning
        
    }

    public void TurnTactileStimOn()
    {
        _serialPort.Write(onTac, 0, onTac.Length);
    }

    public void TurnTactileStimOff()
    {
        _serialPort.Write(offTac, 0, offTac.Length);
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
