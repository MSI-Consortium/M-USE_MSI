using UnityEngine;
using System.IO.Ports;
// using System;
// using System.Buffers;

public class CaterpillarControl : MonoBehaviour
{
    public SerialPort _serialPort;
    private byte[] cmd_onAud, cmd_offAud, cmd_onTac, cmd_offTac, cmd_onVis, cmd_offVis;
    private byte[] cmd_setTacFreq, cmd_setAudFreq;
    private int module;
    private int audStim, tacStim, visStim;
    private int start;
    private int stop;
    private int setAudFreq, setTacFreq;
    private int audFreq, vibFreq;
    
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
        audStim = 0x23;
        tacStim = 0x21;            // value to tell caterpillar to trigger vibration
        visStim = 0x22; // //appropriate hex values for vis/aud Stim
        start = 0x11;        //start the stimulus
        stop = 0x00;         // stop the stimulus (we add other zeroes in the end of the byte array for safety)
        setTacFreq = 0x20;          // value to tell caterpillar you want to set vibration frequency
        setAudFreq = 0x24;
        vibFreq = 0x60;         // the frequency you want to set (refer to manual)
        
        
        cmd_onAud = new byte[6];
        cmd_offAud = new byte[6];
        cmd_onTac = new byte[6];
        cmd_offTac = new byte[6];
        cmd_onVis = new byte[6];
        cmd_offVis = new byte[6];
        cmd_setAudFreq = new byte[6];
        cmd_setTacFreq = new byte[6];
        
        //define cmd on/off Aud + Vis
        //define setAudFreq

        cmd_onTac[0] = (byte)module;
        cmd_onTac[1] = (byte)tacStim;
        cmd_onTac[2] = (byte)start;
        cmd_onTac[3] = (byte)stop;
        cmd_onTac[4] = (byte)stop;
        cmd_onTac[5] = (byte)stop;

        cmd_offTac[0] = (byte)module;
        cmd_offTac[1] = (byte)tacStim;
        cmd_offTac[2] = (byte)stop;
        cmd_offTac[3] = (byte)stop;
        cmd_offTac[4] = (byte)stop;
        cmd_offTac[5] = (byte)stop;

        cmd_setTacFreq[0] = (byte)module;
        cmd_setTacFreq[1] = (byte)setTacFreq;
        cmd_setTacFreq[2] = (byte)vibFreq;
        cmd_setTacFreq[3] = (byte)stop;
        cmd_setTacFreq[4] = (byte)stop;
        cmd_setTacFreq[5] = (byte)stop;

        _serialPort.Write(cmd_setTacFreq, 0, cmd_setTacFreq.Length); //set vibration frequency at the beginning
        
    }

    public void TurnTactileStimOn()
    {
        _serialPort.Write(cmd_onTac, 0, cmd_onTac.Length);
    }

    public void TurnTactileStimOff()
    {
        _serialPort.Write(cmd_offTac, 0, cmd_offTac.Length);
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
