using UnityEngine;
using LSL;

public static class LSL_Manager
{
    public static StreamOutlet LSL_outlet;
    public static string LSL_streamname = "M-USE", LSL_streamtype = "Events";
    public static void Init()
    {
        //Setting up LSL connection
        Hash128 osc_hash = new();
        osc_hash.Append(LSL_streamname);
        osc_hash.Append(LSL_streamtype);
        StreamInfo streamInfo = new(LSL_streamname, LSL_streamtype, 1, LSL.LSL.IRREGULAR_RATE,
            channel_format_t.cf_string, osc_hash.ToString());
        LSL_outlet = new StreamOutlet(streamInfo);
    }
    
    public static void PushSample(string sample){
        string[] LSL_sample = {sample};
        LSL_outlet.push_sample(LSL_sample);
        
    }
}
