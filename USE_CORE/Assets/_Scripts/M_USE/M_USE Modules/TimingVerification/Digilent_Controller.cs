using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using USE_Data;
using USE_ExperimentTemplate_Data;


public class Digilent_Controller : MonoBehaviour
{

    public Digilent_Device_Details ddd;
    public Two_Channel_Data RecordedData;

    public Digilent_Device_Details ActivateScope()
    {
        ddd = new Digilent_Device_Details();
        Debug.Log("HDWF1: " + ddd.HDWF);
        dwf.FDwfDeviceOpen(-1, ref ddd.HDWF);
        Debug.Log("HDWF2: " + ddd.HDWF);

        dwf.FDwfAnalogInReset(ddd.HDWF);
// enable all channels
        dwf.FDwfAnalogInChannelEnableSet(ddd.HDWF, 0, 1);
        dwf.FDwfAnalogInChannelEnableSet(ddd.HDWF, 1, 1);

// set offset voltage (in Volts)
        dwf.FDwfAnalogInChannelOffsetSet(ddd.HDWF, 0, ddd.offset);
        dwf.FDwfAnalogInChannelOffsetSet(ddd.HDWF, 1, ddd.offset);

// set range (maximum signal amplitude in Volts)
        dwf.FDwfAnalogInChannelRangeSet(ddd.HDWF, 0, ddd.amp_range);
        dwf.FDwfAnalogInChannelRangeSet(ddd.HDWF, 1, ddd.amp_range);

// set the buffer size (data point in a recording)
        dwf.FDwfAnalogInBufferSizeSet(ddd.HDWF, ddd.buffer_size);

// set the acquisition frequency (in Hz)
        dwf.FDwfAnalogInFrequencySet(ddd.HDWF, ddd.sampling_frequency);

        dwf.FDwfAnalogInAcquisitionModeSet(ddd.HDWF, 3);
// dwf.FDwfAnalogInFrequencySet(hdwf, hzAcq)
        dwf.FDwfAnalogInRecordLengthSet(ddd.HDWF, ddd.record_length); // -1 infinite record length

// disable averaging (for more info check the documentation)
        dwf.FDwfAnalogInChannelFilterSet(ddd.HDWF, -1, 1);
// device_data.sampling_frequency = sampling_frequency
// device_data.buffer_size = buffer_size
        return ddd;
    }


    public void CloseScope()
    {
        dwf.FDwfAnalogInReset(ddd.HDWF);
        dwf.FDwfDeviceCloseAll();
    }


    public void StartRecording()
    {
        dwf.FDwfAnalogInConfigure(ddd.HDWF, 0, 1);
    }

    public void StopRecording()
    {
        dwf.FDwfAnalogInConfigure(ddd.HDWF, 0, 0);
    }

    public Two_Channel_Data CollectData()
    {
        int cAvailable = 111;
        int clost = 111;
        int cCorrupted = 111;
        byte psts = new byte();
        double[] rgd_samples_1 = new double[ddd.n_samples];
        double[] rgd_samples_2 = new double[ddd.n_samples];
        float[] timestamp = new float[ddd.n_samples];

// #actually sample data
        dwf.FDwfAnalogInStatus(ddd.HDWF, 1, ref psts);
        dwf.FDwfAnalogInStatusRecord(ddd.HDWF, ref cAvailable, ref clost, ref cCorrupted);
        dwf.FDwfAnalogInStatusData(ddd.HDWF, 0, rgd_samples_1, cAvailable);
        dwf.FDwfAnalogInStatusData(ddd.HDWF, 1, rgd_samples_2, cAvailable);

// # calculate aquisition time
        timestamp = Array.ConvertAll(Enumerable.Range(0, ddd.buffer_size).ToArray(), Convert.ToSingle);
        timestamp = timestamp.Select(d => d / ddd.sampling_frequency * 1000).ToArray();
        RecordedData = new Two_Channel_Data(rgd_samples_1, rgd_samples_2, timestamp);
        return RecordedData;

    }

    public class Two_Channel_Data
    {

        public double[] rgd_samples_1;
        public double[] rgd_samples_2;
        public float[] timestamp;

        public Two_Channel_Data(double[] rgdSamples1, double[] rgdSamples2, float[] ts)
        {
            rgd_samples_1 = rgdSamples1;
            rgd_samples_2 = rgdSamples2;
            timestamp = ts;
        }
    }

    public string Two_Channel_Data_String()
    {
        int iOnset = FindOnsetIndex(RecordedData.rgd_samples_1, RecordedData.rgd_samples_2);
        return CombineArraysAsColumns(RecordedData.timestamp, RecordedData.rgd_samples_1, RecordedData.rgd_samples_2);
    }

    private int FindOnsetIndex(double[] ch1, double[] ch2, float voltageThreshold = 0.001f, int maxOnsetDiff = 10)
    {
        // Find the onset index for ch1
        int onsetIndex1 = FindFirstAboveThreshold(ch1, voltageThreshold);
        // Find the onset index for ch2
        int onsetIndex2 = FindFirstAboveThreshold(ch2, voltageThreshold);

        // If either array does not start with a sequence of values close to 0, return 0
        if (onsetIndex1 == -1 || onsetIndex2 == -1)
        {
            return 0;
        }

        // Check if the difference between the onset indices is less than maxOnsetDiff
        if (Math.Abs(onsetIndex1 - onsetIndex2) < maxOnsetDiff)
        {
            // Return the rounded mean of the two indices
            return (int)Math.Round((onsetIndex1 + onsetIndex2) / 2.0);
        }

        return 0;
    }

    private int FindFirstAboveThreshold(double[] channel, float threshold)
    {
        for (int i = 0; i < channel.Length; i++)
        {
            if (Math.Abs(channel[i]) > threshold)
            {
                return i;
            }
        }
        // If no value exceeds the threshold, return -1 to indicate failure
        return -1;
    }
    
    
    private string CombineArraysAsColumns(float[] array1, double[] array2, double[] array3)
    {
        if (array1.Length != array2.Length || array1.Length != array3.Length)
        {
            throw new ArgumentException("All arrays must have the same length.");
        }

        StringBuilder combinedData = new StringBuilder();
        for (int i = 0; i < array1.Length; i++)
        {
            combinedData.Append(array1[i]).Append("\t")
                .Append(array2[i]).Append("\t")
                .Append(array3[i]);
            
            if (i < array1.Length - 1)
            {
                combinedData.Append(Environment.NewLine);
            }
        }

        return combinedData.ToString();
    }



    public class Digilent_Device_Details
    {
        public int HDWF = 0;
        public int sampling_frequency = 10000;
        public float record_length = 1;
        public int n_samples;
        public int buffer_size;
        public string name = "";
        public float offset = 0;
        public float amp_range = 5;

        public Digilent_Device_Details()
        {
            n_samples = (int)Math.Round(record_length * sampling_frequency);
            buffer_size = n_samples;
        }
    }
}
