
public class dwf {


   // device enumeration filters
   public const int enumfilterAll      = 0;
   public const int enumfilterEExplorer= 1;
   public const int enumfilterDiscovery= 2;

   // device ID
   public const int devidEExplorer  = 1;
   public const int devidDiscovery  = 2;
   public const int devidDiscovery2 = 3;
   public const int devidDDiscovery = 4;
   
   // device version
   public const int devverEExplorerC   = 2;
   public const int devverEExplorerE   = 4;
   public const int devverEExplorerF   = 5;
   public const int devverDiscoveryA   = 1;
   public const int devverDiscoveryB   = 2;
   public const int devverDiscoveryC   = 3;

   // trigger source
   public const byte trigsrcNone               = 0;
   public const byte trigsrcPC                 = 1;
   public const byte trigsrcDetectorAnalogIn   = 2;
   public const byte trigsrcDetectorDigitalIn  = 3;
   public const byte trigsrcAnalogIn           = 4;
   public const byte trigsrcDigitalIn          = 5;
   public const byte trigsrcDigitalOut         = 6;
   public const byte trigsrcAnalogOut1         = 7;
   public const byte trigsrcAnalogOut2         = 8;
   public const byte trigsrcAnalogOut3         = 9;
   public const byte trigsrcAnalogOut4         = 10;
   public const byte trigsrcExternal1          = 11;
   public const byte trigsrcExternal2          = 12;
   public const byte trigsrcExternal3          = 13;
   public const byte trigsrcExternal4          = 14;

   // instrument states:
   public const byte DwfStateReady        = 0;
   public const byte DwfStateConfig       = 4;
   public const byte DwfStatePrefill      = 5;
   public const byte DwfStateArmed        = 1;
   public const byte DwfStateWait         = 7;
   public const byte DwfStateTriggered    = 3;
   public const byte DwfStateRunning      = 3;
   public const byte DwfStateDone         = 2;

   // acquisition modes:
   public const int acqmodeSingle     = 0;
   public const int acqmodeScanShift  = 1;
   public const int acqmodeScanScreen = 2;
   public const int acqmodeRecord     = 3;
   public const int acqmodeOvers      = 4;
   public const int acqmodeSingle1    = 5;

   // analog acquisition filter:
   public const int filterDecimate = 0;
   public const int filterAverage  = 1;
   public const int filterMinMax   = 2;

   // analog acquisition filter:
   public const int DwfTriggerSlopeRise   = 0;
   public const int DwfTriggerSlopeFall   = 1;
   public const int DwfTriggerSlopeEdge   = 2;


   // analog input coupling:
   public const int DwfAnalogCouplingDC = 0;
   public const int DwfAnalogCouplingAC = 1;


   // analog in trigger mode:
   public const int trigtypeEdge         = 0;
   public const int trigtypePulse        = 1;
   public const int trigtypeTransition   = 2;


   // analog in trigger length condition
   public const int triglenLess       = 0;
   public const int triglenTimeout    = 1;
   public const int triglenMore       = 2;

   // error codes for DWF Public API:                         
   public const   int dwfercNoErc                  = 0;        //  No error occurred
   public const   int dwfercUnknownError           = 1;        //  API waiting on pending API timed out
   public const   int dwfercApiLockTimeout         = 2;        //  API waiting on pending API timed out
   public const   int dwfercAlreadyOpened          = 3;        //  Device already opened
   public const   int dwfercNotSupported           = 4;        //  Device not supported
   public const   int dwfercInvalidParameter0      = 0x10;     //  Invalid parameter sent in API call
   public const   int dwfercInvalidParameter1      = 0x11;     //  Invalid parameter sent in API call
   public const   int dwfercInvalidParameter2      = 0x12;     //  Invalid parameter sent in API call
   public const   int dwfercInvalidParameter3      = 0x13;     //  Invalid parameter sent in API call
   public const   int dwfercInvalidParameter4      = 0x14;     //  Invalid parameter sent in API call

   // analog out signal types
   public const byte funcDC       = 0;
   public const byte funcSine     = 1;
   public const byte funcSquare   = 2;
   public const byte funcTriangle = 3;
   public const byte funcRampUp   = 4;
   public const byte funcRampDown = 5;
   public const byte funcNoise    = 6;
   public const byte funcPulse    = 7;
   public const byte funcTrapezium= 8;
   public const byte funcSinePower= 9;
   public const byte funcCustom   = 30;
   public const byte funcPlay     = 31;

   // analog io channel node types
   public const byte analogioEnable       = 1;
   public const byte analogioVoltage      = 2;
   public const byte analogioCurrent      = 3;
   public const byte analogioPower        = 4;
   public const byte analogioTemperature  = 5;
   public const byte analogioDmm          = 6;
   public const byte analogioRange        = 7;
   public const byte analogioMeasure      = 8;

   public const int AnalogOutNodeCarrier  = 0;
   public const int AnalogOutNodeFM       = 1;
   public const int AnalogOutNodeAM       = 2;

   public const int DwfAnalogOutModeVoltage  = 0;
   public const int DwfAnalogOutModeCurrent  = 1;

   public const int DwfAnalogOutIdleDisable  = 0;
   public const int DwfAnalogOutIdleOffset   = 1;
   public const int DwfAnalogOutIdleInitial  = 2;

   public const int DwfDigitalInClockSourceInternal = 0;
   public const int DwfDigitalInClockSourceExternal = 1;

   public const int DwfDigitalInSampleModeSimple   = 0;
   // alternate samples: noise|sample|noise|sample|...  
   // where noise is more than 1 transition between 2 samples
   public const int DwfDigitalInSampleModeNoise    = 1; 

   public const int DwfDigitalOutOutputPushPull   = 0;
   public const int DwfDigitalOutOutputOpenDrain  = 1;
   public const int DwfDigitalOutOutputOpenSource = 2;
   public const int DwfDigitalOutOutputThreeState = 3; // for custom and random

   public const int DwfDigitalOutTypePulse      = 0;
   public const int DwfDigitalOutTypeCustom     = 1;
   public const int DwfDigitalOutTypeRandom     = 2;
   public const int DwfDigitalOutTypeFSM        = 3;

   public const int DwfDigitalOutIdleInit     = 0;
   public const int DwfDigitalOutIdleLow      = 1;
   public const int DwfDigitalOutIdleHigh     = 2;
   public const int DwfDigitalOutIdleZet      = 3;


  public static int FDwfGetLastError(ref int pdwferc) {
    int ret = dwfPINVOKE.FDwfGetLastError(ref pdwferc);
    return ret;
  }

  public static int FDwfGetLastErrorMsg(out string szError) {
    System.Text.StringBuilder sb = new System.Text.StringBuilder(512);
    int ret = dwfPINVOKE.FDwfGetLastErrorMsg(sb);
    szError = sb.ToString();
    return ret;
  }

  public static int FDwfGetVersion(out string szVersion) {
      System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
      int ret = dwfPINVOKE.FDwfGetVersion(sb);
      szVersion = sb.ToString();
      return ret;
  }

  public static int FDwfEnum(int enumfilter, ref int pcDevice) {
    int ret = dwfPINVOKE.FDwfEnum(enumfilter, ref pcDevice);
    return ret;
  }

  public static int FDwfEnumDeviceType(int idxDevice, ref int pDeviceId, ref int pDeviceRevision) {
    int ret = dwfPINVOKE.FDwfEnumDeviceType(idxDevice, ref pDeviceId, ref pDeviceRevision);
    return ret;
  }

  public static int FDwfEnumDeviceIsOpened(int idxDevice, ref int pfIsUsed) {
    int ret = dwfPINVOKE.FDwfEnumDeviceIsOpened(idxDevice, ref pfIsUsed);
    return ret;
  }

  public static int FDwfEnumUserName(int idxDevice, out string szUserName) {
    System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
    int ret = dwfPINVOKE.FDwfEnumUserName(idxDevice, sb);
    szUserName = sb.ToString();
    return ret;
  }

  public static int FDwfEnumDeviceName(int idxDevice, out string szDeviceName) {
    System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
    int ret = dwfPINVOKE.FDwfEnumDeviceName(idxDevice, sb);
    szDeviceName = sb.ToString();
    return ret;
  }

  public static int FDwfEnumSN(int idxDevice, out string szSN) {
    System.Text.StringBuilder sb = new System.Text.StringBuilder(32);
    int ret = dwfPINVOKE.FDwfEnumSN(idxDevice, sb);
    szSN = sb.ToString();
    return ret;
  }

  public static int FDwfEnumConfig(int idxDevice, ref int pcConfig) {
    int ret = dwfPINVOKE.FDwfEnumConfig(idxDevice, ref pcConfig);
    return ret;
  }

  public static int FDwfEnumConfigInfo(int idxConfig, int info, ref int pv) {
    int ret = dwfPINVOKE.FDwfEnumConfigInfo(idxConfig, info, ref pv);
    return ret;
  }

  public static int FDwfDeviceOpen(int idxDevice, ref int phdwf) {
    int ret = dwfPINVOKE.FDwfDeviceOpen(idxDevice, ref phdwf);
    return ret;
  }

  public static int FDwfDeviceConfigOpen(int idxDev, int idxCfg, ref int phdwf) {
    int ret = dwfPINVOKE.FDwfDeviceConfigOpen(idxDev, idxCfg, ref phdwf);
    return ret;
  }

  public static int FDwfDeviceClose(int hdwf) {
    int ret = dwfPINVOKE.FDwfDeviceClose(hdwf);
    return ret;
  }

  public static int FDwfDeviceCloseAll() {
    int ret = dwfPINVOKE.FDwfDeviceCloseAll();
    return ret;
  }

  public static int FDwfDeviceAutoConfigureSet(int hdwf, int fAutoConfigure) {
    int ret = dwfPINVOKE.FDwfDeviceAutoConfigureSet(hdwf, fAutoConfigure);
    return ret;
  }

  public static int FDwfDeviceAutoConfigureGet(int hdwf, ref int pfAutoConfigure) {
    int ret = dwfPINVOKE.FDwfDeviceAutoConfigureGet(hdwf, ref pfAutoConfigure);
    return ret;
  }

  public static int FDwfDeviceReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfDeviceReset(hdwf);
    return ret;
  }

  public static int FDwfDeviceEnableSet(int hdwf, int fEnable) {
    int ret = dwfPINVOKE.FDwfDeviceEnableSet(hdwf, fEnable);
    return ret;
  }

  public static int FDwfDeviceTriggerInfo(int hdwf, ref int pfstrigsrc) {
    int ret = dwfPINVOKE.FDwfDeviceTriggerInfo(hdwf, ref pfstrigsrc);
    return ret;
  }

  public static int FDwfDeviceTriggerSet(int hdwf, int idxPin, byte trigsrc) {
    int ret = dwfPINVOKE.FDwfDeviceTriggerSet(hdwf, idxPin, trigsrc);
    return ret;
  }

  public static int FDwfDeviceTriggerGet(int hdwf, int idxPin, ref byte ptrigsrc) {
    int ret = dwfPINVOKE.FDwfDeviceTriggerGet(hdwf, idxPin, ref ptrigsrc);
    return ret;
  }

  public static int FDwfDeviceTriggerPC(int hdwf) {
    int ret = dwfPINVOKE.FDwfDeviceTriggerPC(hdwf);
    return ret;
  }

  public static int FDwfDeviceTriggerSlopeInfo(int hdwf, ref int pfsslope) {
    int ret = dwfPINVOKE.FDwfDeviceTriggerSlopeInfo(hdwf, ref pfsslope);
    return ret;
  }

  public static int FDwfAnalogInReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfAnalogInReset(hdwf);
    return ret;
  }

  public static int FDwfAnalogInConfigure(int hdwf, int fReconfigure, int fStart) {
    int ret = dwfPINVOKE.FDwfAnalogInConfigure(hdwf, fReconfigure, fStart);
    return ret;
  }

  public static int FDwfAnalogInStatus(int hdwf, int fReadData, ref byte psts) {
    int ret = dwfPINVOKE.FDwfAnalogInStatus(hdwf, fReadData, ref psts);
    return ret;
  }

  public static int FDwfAnalogInStatusSamplesLeft(int hdwf, ref int pcSamplesLeft) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusSamplesLeft(hdwf, ref pcSamplesLeft);
    return ret;
  }

  public static int FDwfAnalogInStatusSamplesValid(int hdwf, ref int pcSamplesValid) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusSamplesValid(hdwf, ref pcSamplesValid);
    return ret;
  }

  public static int FDwfAnalogInStatusIndexWrite(int hdwf, ref int pidxWrite) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusIndexWrite(hdwf, ref pidxWrite);
    return ret;
  }

  public static int FDwfAnalogInStatusAutoTriggered(int hdwf, ref int pfAuto) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusAutoTriggered(hdwf, ref pfAuto);
    return ret;
  }

  public static int FDwfAnalogInStatusData(int hdwf, int idxChannel, double[] rgdVoltData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusData(hdwf, idxChannel, rgdVoltData, cdData);
    return ret;
  }

  public static int FDwfAnalogInStatusData2(int hdwf, int idxChannel, double[] rgdVoltData, int idxData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusData2(hdwf, idxChannel, rgdVoltData, idxData, cdData);
    return ret;
  }

  public static int FDwfAnalogInStatusData16(int hdwf, int idxChannel, short[] rgu16Data, int idxData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusData16(hdwf, idxChannel, rgu16Data, idxData, cdData);
    return ret;
  }

  public static int FDwfAnalogInStatusNoise(int hdwf, int idxChannel, double[] rgdMin, ref double rgdMax, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusNoise(hdwf, idxChannel, rgdMin, ref rgdMax, cdData);
    return ret;
  }

  public static int FDwfAnalogInStatusNoise2(int hdwf, int idxChannel, double[] rgdMin, ref double rgdMax, int idxData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusNoise2(hdwf, idxChannel, rgdMin, ref rgdMax, idxData, cdData);
    return ret;
  }

  public static int FDwfAnalogInStatusSample(int hdwf, int idxChannel, ref double pdVoltSample) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusSample(hdwf, idxChannel, ref pdVoltSample);
    return ret;
  }

  public static int FDwfAnalogInStatusTime(int hdwf, ref uint psecUtc, ref uint ptick, ref uint pticksPerSecond) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusTime(hdwf, ref psecUtc, ref ptick, ref pticksPerSecond);
    return ret;
  }

  public static int FDwfAnalogInStatusRecord(int hdwf, ref int pcdDataAvailable, ref int pcdDataLost, ref int pcdDataCorrupt) {
    int ret = dwfPINVOKE.FDwfAnalogInStatusRecord(hdwf, ref pcdDataAvailable, ref pcdDataLost, ref pcdDataCorrupt);
    return ret;
  }

  public static int FDwfAnalogInRecordLengthSet(int hdwf, double sLegth) {
    int ret = dwfPINVOKE.FDwfAnalogInRecordLengthSet(hdwf, sLegth);
    return ret;
  }

  public static int FDwfAnalogInRecordLengthGet(int hdwf, ref double psLegth) {
    int ret = dwfPINVOKE.FDwfAnalogInRecordLengthGet(hdwf, ref psLegth);
    return ret;
  }

  public static int FDwfAnalogInFrequencyInfo(int hdwf, ref double phzMin, ref double phzMax) {
    int ret = dwfPINVOKE.FDwfAnalogInFrequencyInfo(hdwf, ref phzMin, ref phzMax);
    return ret;
  }

  public static int FDwfAnalogInFrequencySet(int hdwf, double hzFrequency) {
    int ret = dwfPINVOKE.FDwfAnalogInFrequencySet(hdwf, hzFrequency);
    return ret;
  }

  public static int FDwfAnalogInFrequencyGet(int hdwf, ref double phzFrequency) {
    int ret = dwfPINVOKE.FDwfAnalogInFrequencyGet(hdwf, ref phzFrequency);
    return ret;
  }

  public static int FDwfAnalogInBitsInfo(int hdwf, ref int pnBits) {
    int ret = dwfPINVOKE.FDwfAnalogInBitsInfo(hdwf, ref pnBits);
    return ret;
  }

  public static int FDwfAnalogInBufferSizeInfo(int hdwf, ref int pnSizeMin, ref int pnSizeMax) {
    int ret = dwfPINVOKE.FDwfAnalogInBufferSizeInfo(hdwf, ref pnSizeMin, ref pnSizeMax);
    return ret;
  }

  public static int FDwfAnalogInBufferSizeSet(int hdwf, int nSize) {
    int ret = dwfPINVOKE.FDwfAnalogInBufferSizeSet(hdwf, nSize);
    return ret;
  }

  public static int FDwfAnalogInBufferSizeGet(int hdwf, ref int pnSize) {
    int ret = dwfPINVOKE.FDwfAnalogInBufferSizeGet(hdwf, ref pnSize);
    return ret;
  }

  public static int FDwfAnalogInNoiseSizeInfo(int hdwf, ref int pnSizeMax) {
    int ret = dwfPINVOKE.FDwfAnalogInNoiseSizeInfo(hdwf, ref pnSizeMax);
    return ret;
  }

  public static int FDwfAnalogInNoiseSizeSet(int hdwf, int nSize) {
    int ret = dwfPINVOKE.FDwfAnalogInNoiseSizeSet(hdwf, nSize);
    return ret;
  }

  public static int FDwfAnalogInNoiseSizeGet(int hdwf, ref int pnSize) {
    int ret = dwfPINVOKE.FDwfAnalogInNoiseSizeGet(hdwf, ref pnSize);
    return ret;
  }

  public static int FDwfAnalogInAcquisitionModeInfo(int hdwf, ref int pfsacqmode) {
    int ret = dwfPINVOKE.FDwfAnalogInAcquisitionModeInfo(hdwf, ref pfsacqmode);
    return ret;
  }

  public static int FDwfAnalogInAcquisitionModeSet(int hdwf, int acqmode) {
    int ret = dwfPINVOKE.FDwfAnalogInAcquisitionModeSet(hdwf, acqmode);
    return ret;
  }

  public static int FDwfAnalogInAcquisitionModeGet(int hdwf, ref int pacqmode) {
    int ret = dwfPINVOKE.FDwfAnalogInAcquisitionModeGet(hdwf, ref pacqmode);
    return ret;
  }

  public static int FDwfAnalogInChannelCount(int hdwf, ref int pcChannel) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelCount(hdwf, ref pcChannel);
    return ret;
  }

  public static int FDwfAnalogInChannelEnableSet(int hdwf, int idxChannel, int fEnable) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelEnableSet(hdwf, idxChannel, fEnable);
    return ret;
  }

  public static int FDwfAnalogInChannelEnableGet(int hdwf, int idxChannel, ref int pfEnable) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelEnableGet(hdwf, idxChannel, ref pfEnable);
    return ret;
  }

  public static int FDwfAnalogInChannelFilterInfo(int hdwf, ref int pfsfilter) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelFilterInfo(hdwf, ref pfsfilter);
    return ret;
  }

  public static int FDwfAnalogInChannelFilterSet(int hdwf, int idxChannel, int filter) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelFilterSet(hdwf, idxChannel, filter);
    return ret;
  }

  public static int FDwfAnalogInChannelFilterGet(int hdwf, int idxChannel, ref int pfilter) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelFilterGet(hdwf, idxChannel, ref pfilter);
    return ret;
  }

  public static int FDwfAnalogInChannelRangeInfo(int hdwf, ref double pvoltsMin, ref double pvoltsMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelRangeInfo(hdwf, ref pvoltsMin, ref pvoltsMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInChannelRangeSet(int hdwf, int idxChannel, double voltsRange) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelRangeSet(hdwf, idxChannel, voltsRange);
    return ret;
  }

  public static int FDwfAnalogInChannelRangeGet(int hdwf, int idxChannel, ref double pvoltsRange) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelRangeGet(hdwf, idxChannel, ref pvoltsRange);
    return ret;
  }

  public static int FDwfAnalogInChannelOffsetInfo(int hdwf, ref double pvoltsMin, ref double pvoltsMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelOffsetInfo(hdwf, ref pvoltsMin, ref pvoltsMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInChannelOffsetSet(int hdwf, int idxChannel, double voltOffset) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelOffsetSet(hdwf, idxChannel, voltOffset);
    return ret;
  }

  public static int FDwfAnalogInChannelOffsetGet(int hdwf, int idxChannel, ref double pvoltOffset) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelOffsetGet(hdwf, idxChannel, ref pvoltOffset);
    return ret;
  }

  public static int FDwfAnalogInChannelAttenuationSet(int hdwf, int idxChannel, double xAttenuation) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelAttenuationSet(hdwf, idxChannel, xAttenuation);
    return ret;
  }

  public static int FDwfAnalogInChannelAttenuationGet(int hdwf, int idxChannel, ref double pxAttenuation) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelAttenuationGet(hdwf, idxChannel, ref pxAttenuation);
    return ret;
  }

  public static int FDwfAnalogInChannelCouplingInfo(int hdwf, ref int pfscoupling) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelCouplingInfo(hdwf, ref pfscoupling);
    return ret;
  }

  public static int FDwfAnalogInChannelCouplingSet(int hdwf, int idxChannel, int coupling) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelCouplingSet(hdwf, idxChannel, coupling);
    return ret;
  }

  public static int FDwfAnalogInChannelCouplingGet(int hdwf, int idxChannel, ref int pcoupling) {
    int ret = dwfPINVOKE.FDwfAnalogInChannelCouplingGet(hdwf, idxChannel, ref pcoupling);
    return ret;
  }

  public static int FDwfAnalogImpedanceInfo(int hdwf, ref int fSupported) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceInfo(hdwf, ref fSupported);
    return ret;
  }

  public static int FDwfAnalogImpedanceEnableSet(int hdwf, int fEnable) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceEnableSet(hdwf, fEnable);
    return ret;
  }

  public static int FDwfAnalogImpedanceEnableGet(int hdwf, ref int pfEnable) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceEnableGet(hdwf, ref pfEnable);
    return ret;
  }

  public static int FDwfAnalogImpedanceReferenceInfo(int hdwf, ref double pOhmMin, ref double pOhmMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceReferenceInfo(hdwf, ref pOhmMin, ref pOhmMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogImpedanceReferenceSet(int hdwf, double ohms) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceReferenceSet(hdwf, ohms);
    return ret;
  }

  public static int FDwfAnalogImpedanceReferenceGet(int hdwf, ref double pohms) {
    int ret = dwfPINVOKE.FDwfAnalogImpedanceReferenceGet(hdwf, ref pohms);
    return ret;
  }

  public static int FDwfAnalogInTriggerSourceSet(int hdwf, byte trigsrc) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerSourceSet(hdwf, trigsrc);
    return ret;
  }

  public static int FDwfAnalogInTriggerSourceGet(int hdwf, ref byte ptrigsrc) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerSourceGet(hdwf, ref ptrigsrc);
    return ret;
  }

  public static int FDwfAnalogInTriggerPositionInfo(int hdwf, ref double psecMin, ref double psecMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerPositionInfo(hdwf, ref psecMin, ref psecMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInTriggerPositionSet(int hdwf, double secPosition) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerPositionSet(hdwf, secPosition);
    return ret;
  }

  public static int FDwfAnalogInTriggerPositionGet(int hdwf, ref double psecPosition) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerPositionGet(hdwf, ref psecPosition);
    return ret;
  }

  public static int FDwfAnalogInTriggerPositionStatus(int hdwf, ref double psecPosition) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerPositionStatus(hdwf, ref psecPosition);
    return ret;
  }

  public static int FDwfAnalogInTriggerAutoTimeoutInfo(int hdwf, ref double psecMin, ref double psecMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerAutoTimeoutInfo(hdwf, ref psecMin, ref psecMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInTriggerAutoTimeoutSet(int hdwf, double secTimeout) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerAutoTimeoutSet(hdwf, secTimeout);
    return ret;
  }

  public static int FDwfAnalogInTriggerAutoTimeoutGet(int hdwf, ref double psecTimeout) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerAutoTimeoutGet(hdwf, ref psecTimeout);
    return ret;
  }

  public static int FDwfAnalogInTriggerHoldOffInfo(int hdwf, ref double psecMin, ref double psecMax, ref double pnStep) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHoldOffInfo(hdwf, ref psecMin, ref psecMax, ref pnStep);
    return ret;
  }

  public static int FDwfAnalogInTriggerHoldOffSet(int hdwf, double secHoldOff) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHoldOffSet(hdwf, secHoldOff);
    return ret;
  }

  public static int FDwfAnalogInTriggerHoldOffGet(int hdwf, ref double psecHoldOff) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHoldOffGet(hdwf, ref psecHoldOff);
    return ret;
  }

  public static int FDwfAnalogInTriggerTypeInfo(int hdwf, ref int pfstrigtype) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerTypeInfo(hdwf, ref pfstrigtype);
    return ret;
  }

  public static int FDwfAnalogInTriggerTypeSet(int hdwf, int trigtype) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerTypeSet(hdwf, trigtype);
    return ret;
  }

  public static int FDwfAnalogInTriggerTypeGet(int hdwf, ref int ptrigtype) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerTypeGet(hdwf, ref ptrigtype);
    return ret;
  }

  public static int FDwfAnalogInTriggerChannelInfo(int hdwf, ref int pidxMin, ref int pidxMax) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerChannelInfo(hdwf, ref pidxMin, ref pidxMax);
    return ret;
  }

  public static int FDwfAnalogInTriggerChannelSet(int hdwf, int idxChannel) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerChannelSet(hdwf, idxChannel);
    return ret;
  }

  public static int FDwfAnalogInTriggerChannelGet(int hdwf, ref int pidxChannel) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerChannelGet(hdwf, ref pidxChannel);
    return ret;
  }

  public static int FDwfAnalogInTriggerFilterInfo(int hdwf, ref int pfsfilter) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerFilterInfo(hdwf, ref pfsfilter);
    return ret;
  }

  public static int FDwfAnalogInTriggerFilterSet(int hdwf, int filter) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerFilterSet(hdwf, filter);
    return ret;
  }

  public static int FDwfAnalogInTriggerFilterGet(int hdwf, ref int pfilter) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerFilterGet(hdwf, ref pfilter);
    return ret;
  }

  public static int FDwfAnalogInTriggerLevelInfo(int hdwf, ref double pvoltsMin, ref double pvoltsMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLevelInfo(hdwf, ref pvoltsMin, ref pvoltsMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInTriggerLevelSet(int hdwf, double voltsLevel) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLevelSet(hdwf, voltsLevel);
    return ret;
  }

  public static int FDwfAnalogInTriggerLevelGet(int hdwf, ref double pvoltsLevel) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLevelGet(hdwf, ref pvoltsLevel);
    return ret;
  }

  public static int FDwfAnalogInTriggerHysteresisInfo(int hdwf, ref double pvoltsMin, ref double pvoltsMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHysteresisInfo(hdwf, ref pvoltsMin, ref pvoltsMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInTriggerHysteresisSet(int hdwf, double voltsLevel) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHysteresisSet(hdwf, voltsLevel);
    return ret;
  }

  public static int FDwfAnalogInTriggerHysteresisGet(int hdwf, ref double pvoltsHysteresis) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerHysteresisGet(hdwf, ref pvoltsHysteresis);
    return ret;
  }

  public static int FDwfAnalogInTriggerConditionInfo(int hdwf, ref int pfstrigcond) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerConditionInfo(hdwf, ref pfstrigcond);
    return ret;
  }

  public static int FDwfAnalogInTriggerConditionSet(int hdwf, int trigcond) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerConditionSet(hdwf, trigcond);
    return ret;
  }

  public static int FDwfAnalogInTriggerConditionGet(int hdwf, ref int ptrigcond) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerConditionGet(hdwf, ref ptrigcond);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthInfo(int hdwf, ref double psecMin, ref double psecMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthInfo(hdwf, ref psecMin, ref psecMax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthSet(int hdwf, double secLength) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthSet(hdwf, secLength);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthGet(int hdwf, ref double psecLength) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthGet(hdwf, ref psecLength);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthConditionInfo(int hdwf, ref int pfstriglen) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthConditionInfo(hdwf, ref pfstriglen);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthConditionSet(int hdwf, int triglen) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthConditionSet(hdwf, triglen);
    return ret;
  }

  public static int FDwfAnalogInTriggerLengthConditionGet(int hdwf, ref int ptriglen) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerLengthConditionGet(hdwf, ref ptriglen);
    return ret;
  }

  public static int FDwfAnalogInTriggerForce(int hdwf) {
    int ret = dwfPINVOKE.FDwfAnalogInTriggerForce(hdwf);
    return ret;
  }

  public static int FDwfAnalogOutCount(int hdwf, ref int pcChannel) {
    int ret = dwfPINVOKE.FDwfAnalogOutCount(hdwf, ref pcChannel);
    return ret;
  }

  public static int FDwfAnalogOutMasterSet(int hdwf, int idxChannel, int idxMaster) {
    int ret = dwfPINVOKE.FDwfAnalogOutMasterSet(hdwf, idxChannel, idxMaster);
    return ret;
  }

  public static int FDwfAnalogOutMasterGet(int hdwf, int idxChannel, ref int pidxMaster) {
    int ret = dwfPINVOKE.FDwfAnalogOutMasterGet(hdwf, idxChannel, ref pidxMaster);
    return ret;
  }

  public static int FDwfAnalogOutTriggerSourceSet(int hdwf, int idxChannel, byte trigsrc) {
    int ret = dwfPINVOKE.FDwfAnalogOutTriggerSourceSet(hdwf, idxChannel, trigsrc);
    return ret;
  }

  public static int FDwfAnalogOutTriggerSourceGet(int hdwf, int idxChannel, ref byte ptrigsrc) {
    int ret = dwfPINVOKE.FDwfAnalogOutTriggerSourceGet(hdwf, idxChannel, ref ptrigsrc);
    return ret;
  }

  public static int FDwfAnalogOutTriggerSlopeSet(int hdwf, int idxChannel, int slope) {
    int ret = dwfPINVOKE.FDwfAnalogOutTriggerSlopeSet(hdwf, idxChannel, slope);
    return ret;
  }

  public static int FDwfAnalogOutTriggerSlopeGet(int hdwf, int idxChannel, ref int pslope) {
    int ret = dwfPINVOKE.FDwfAnalogOutTriggerSlopeGet(hdwf, idxChannel, ref pslope);
    return ret;
  }

  public static int FDwfAnalogOutRunInfo(int hdwf, int idxChannel, ref double psecMin, ref double psecMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutRunInfo(hdwf, idxChannel, ref psecMin, ref psecMax);
    return ret;
  }

  public static int FDwfAnalogOutRunSet(int hdwf, int idxChannel, double secRun) {
    int ret = dwfPINVOKE.FDwfAnalogOutRunSet(hdwf, idxChannel, secRun);
    return ret;
  }

  public static int FDwfAnalogOutRunGet(int hdwf, int idxChannel, ref double psecRun) {
    int ret = dwfPINVOKE.FDwfAnalogOutRunGet(hdwf, idxChannel, ref psecRun);
    return ret;
  }

  public static int FDwfAnalogOutRunStatus(int hdwf, int idxChannel, ref double psecRun) {
    int ret = dwfPINVOKE.FDwfAnalogOutRunStatus(hdwf, idxChannel, ref psecRun);
    return ret;
  }

  public static int FDwfAnalogOutWaitInfo(int hdwf, int idxChannel, ref double psecMin, ref double psecMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutWaitInfo(hdwf, idxChannel, ref psecMin, ref psecMax);
    return ret;
  }

  public static int FDwfAnalogOutWaitSet(int hdwf, int idxChannel, double secWait) {
    int ret = dwfPINVOKE.FDwfAnalogOutWaitSet(hdwf, idxChannel, secWait);
    return ret;
  }

  public static int FDwfAnalogOutWaitGet(int hdwf, int idxChannel, ref double psecWait) {
    int ret = dwfPINVOKE.FDwfAnalogOutWaitGet(hdwf, idxChannel, ref psecWait);
    return ret;
  }

  public static int FDwfAnalogOutRepeatInfo(int hdwf, int idxChannel, ref int pnMin, ref int pnMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatInfo(hdwf, idxChannel, ref pnMin, ref pnMax);
    return ret;
  }

  public static int FDwfAnalogOutRepeatSet(int hdwf, int idxChannel, int cRepeat) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatSet(hdwf, idxChannel, cRepeat);
    return ret;
  }

  public static int FDwfAnalogOutRepeatGet(int hdwf, int idxChannel, ref int pcRepeat) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatGet(hdwf, idxChannel, ref pcRepeat);
    return ret;
  }

  public static int FDwfAnalogOutRepeatStatus(int hdwf, int idxChannel, ref int pcRepeat) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatStatus(hdwf, idxChannel, ref pcRepeat);
    return ret;
  }

  public static int FDwfAnalogOutRepeatTriggerSet(int hdwf, int idxChannel, int fRepeatTrigger) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatTriggerSet(hdwf, idxChannel, fRepeatTrigger);
    return ret;
  }

  public static int FDwfAnalogOutRepeatTriggerGet(int hdwf, int idxChannel, ref int pfRepeatTrigger) {
    int ret = dwfPINVOKE.FDwfAnalogOutRepeatTriggerGet(hdwf, idxChannel, ref pfRepeatTrigger);
    return ret;
  }

  public static int FDwfAnalogOutLimitationInfo(int hdwf, int idxChannel, ref double pMin, ref double pMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutLimitationInfo(hdwf, idxChannel, ref pMin, ref pMax);
    return ret;
  }

  public static int FDwfAnalogOutLimitationSet(int hdwf, int idxChannel, double limit) {
    int ret = dwfPINVOKE.FDwfAnalogOutLimitationSet(hdwf, idxChannel, limit);
    return ret;
  }

  public static int FDwfAnalogOutLimitationGet(int hdwf, int idxChannel, ref double plimit) {
    int ret = dwfPINVOKE.FDwfAnalogOutLimitationGet(hdwf, idxChannel, ref plimit);
    return ret;
  }

  public static int FDwfAnalogOutModeSet(int hdwf, int idxChannel, int mode) {
    int ret = dwfPINVOKE.FDwfAnalogOutModeSet(hdwf, idxChannel, mode);
    return ret;
  }

  public static int FDwfAnalogOutModeGet(int hdwf, int idxChannel, ref int pmode) {
    int ret = dwfPINVOKE.FDwfAnalogOutModeGet(hdwf, idxChannel, ref pmode);
    return ret;
  }

  public static int FDwfAnalogOutIdleInfo(int hdwf, int idxChannel, ref int pfsidle) {
    int ret = dwfPINVOKE.FDwfAnalogOutIdleInfo(hdwf, idxChannel, ref pfsidle);
    return ret;
  }

  public static int FDwfAnalogOutIdleSet(int hdwf, int idxChannel, int idle) {
    int ret = dwfPINVOKE.FDwfAnalogOutIdleSet(hdwf, idxChannel, idle);
    return ret;
  }

  public static int FDwfAnalogOutIdleGet(int hdwf, int idxChannel, ref int pidle) {
    int ret = dwfPINVOKE.FDwfAnalogOutIdleGet(hdwf, idxChannel, ref pidle);
    return ret;
  }

  public static int FDwfAnalogOutNodeInfo(int hdwf, int idxChannel, ref int pfsnode) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeInfo(hdwf, idxChannel, ref pfsnode);
    return ret;
  }

  public static int FDwfAnalogOutNodeEnableSet(int hdwf, int idxChannel, int node, int fEnable) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeEnableSet(hdwf, idxChannel, node, fEnable);
    return ret;
  }

  public static int FDwfAnalogOutNodeEnableGet(int hdwf, int idxChannel, int node, ref int pfEnable) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeEnableGet(hdwf, idxChannel, node, ref pfEnable);
    return ret;
  }

  public static int FDwfAnalogOutNodeFunctionInfo(int hdwf, int idxChannel, int node, ref int pfsfunc) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFunctionInfo(hdwf, idxChannel, node, ref pfsfunc);
    return ret;
  }

  public static int FDwfAnalogOutNodeFunctionSet(int hdwf, int idxChannel, int node, byte func) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFunctionSet(hdwf, idxChannel, node, func);
    return ret;
  }

  public static int FDwfAnalogOutNodeFunctionGet(int hdwf, int idxChannel, int node, ref byte pfunc) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFunctionGet(hdwf, idxChannel, node, ref pfunc);
    return ret;
  }

  public static int FDwfAnalogOutNodeFrequencyInfo(int hdwf, int idxChannel, int node, ref double phzMin, ref double phzMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFrequencyInfo(hdwf, idxChannel, node, ref phzMin, ref phzMax);
    return ret;
  }

  public static int FDwfAnalogOutNodeFrequencySet(int hdwf, int idxChannel, int node, double hzFrequency) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFrequencySet(hdwf, idxChannel, node, hzFrequency);
    return ret;
  }

  public static int FDwfAnalogOutNodeFrequencyGet(int hdwf, int idxChannel, int node, ref double phzFrequency) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeFrequencyGet(hdwf, idxChannel, node, ref phzFrequency);
    return ret;
  }

  public static int FDwfAnalogOutNodeAmplitudeInfo(int hdwf, int idxChannel, int node, ref double pMin, ref double pMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeAmplitudeInfo(hdwf, idxChannel, node, ref pMin, ref pMax);
    return ret;
  }

  public static int FDwfAnalogOutNodeAmplitudeSet(int hdwf, int idxChannel, int node, double vAmplitude) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeAmplitudeSet(hdwf, idxChannel, node, vAmplitude);
    return ret;
  }

  public static int FDwfAnalogOutNodeAmplitudeGet(int hdwf, int idxChannel, int node, ref double pvAmplitude) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeAmplitudeGet(hdwf, idxChannel, node, ref pvAmplitude);
    return ret;
  }

  public static int FDwfAnalogOutNodeOffsetInfo(int hdwf, int idxChannel, int node, ref double pMin, ref double pMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeOffsetInfo(hdwf, idxChannel, node, ref pMin, ref pMax);
    return ret;
  }

  public static int FDwfAnalogOutNodeOffsetSet(int hdwf, int idxChannel, int node, double vOffset) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeOffsetSet(hdwf, idxChannel, node, vOffset);
    return ret;
  }

  public static int FDwfAnalogOutNodeOffsetGet(int hdwf, int idxChannel, int node, ref double pvOffset) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeOffsetGet(hdwf, idxChannel, node, ref pvOffset);
    return ret;
  }

  public static int FDwfAnalogOutNodeSymmetryInfo(int hdwf, int idxChannel, int node, ref double ppercentageMin, ref double ppercentageMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeSymmetryInfo(hdwf, idxChannel, node, ref ppercentageMin, ref ppercentageMax);
    return ret;
  }

  public static int FDwfAnalogOutNodeSymmetrySet(int hdwf, int idxChannel, int node, double percentageSymmetry) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeSymmetrySet(hdwf, idxChannel, node, percentageSymmetry);
    return ret;
  }

  public static int FDwfAnalogOutNodeSymmetryGet(int hdwf, int idxChannel, int node, ref double ppercentageSymmetry) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeSymmetryGet(hdwf, idxChannel, node, ref ppercentageSymmetry);
    return ret;
  }

  public static int FDwfAnalogOutNodePhaseInfo(int hdwf, int idxChannel, int node, ref double pdegreeMin, ref double pdegreeMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodePhaseInfo(hdwf, idxChannel, node, ref pdegreeMin, ref pdegreeMax);
    return ret;
  }

  public static int FDwfAnalogOutNodePhaseSet(int hdwf, int idxChannel, int node, double degreePhase) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodePhaseSet(hdwf, idxChannel, node, degreePhase);
    return ret;
  }

  public static int FDwfAnalogOutNodePhaseGet(int hdwf, int idxChannel, int node, ref double pdegreePhase) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodePhaseGet(hdwf, idxChannel, node, ref pdegreePhase);
    return ret;
  }

  public static int FDwfAnalogOutNodeDataInfo(int hdwf, int idxChannel, int node, ref int pnSamplesMin, ref int pnSamplesMax) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeDataInfo(hdwf, idxChannel, node, ref pnSamplesMin, ref pnSamplesMax);
    return ret;
  }

  public static int FDwfAnalogOutNodeDataSet(int hdwf, int idxChannel, int node, double[] rgdData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodeDataSet(hdwf, idxChannel, node, rgdData, cdData);
    return ret;
  }

  public static int FDwfAnalogOutCustomAMFMEnableSet(int hdwf, int idxChannel, int fEnable) {
    int ret = dwfPINVOKE.FDwfAnalogOutCustomAMFMEnableSet(hdwf, idxChannel, fEnable);
    return ret;
  }

  public static int FDwfAnalogOutCustomAMFMEnableGet(int hdwf, int idxChannel, ref int pfEnable) {
    int ret = dwfPINVOKE.FDwfAnalogOutCustomAMFMEnableGet(hdwf, idxChannel, ref pfEnable);
    return ret;
  }

  public static int FDwfAnalogOutReset(int hdwf, int idxChannel) {
    int ret = dwfPINVOKE.FDwfAnalogOutReset(hdwf, idxChannel);
    return ret;
  }

  public static int FDwfAnalogOutConfigure(int hdwf, int idxChannel, int fStart) {
    int ret = dwfPINVOKE.FDwfAnalogOutConfigure(hdwf, idxChannel, fStart);
    return ret;
  }

  public static int FDwfAnalogOutStatus(int hdwf, int idxChannel, ref byte psts) {
    int ret = dwfPINVOKE.FDwfAnalogOutStatus(hdwf, idxChannel, ref psts);
    return ret;
  }

  public static int FDwfAnalogOutNodePlayStatus(int hdwf, int idxChannel, int node, ref int cdDataFree, ref int cdDataLost, ref int cdDataCorrupted) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodePlayStatus(hdwf, idxChannel, node, ref cdDataFree, ref cdDataLost, ref cdDataCorrupted);
    return ret;
  }

  public static int FDwfAnalogOutNodePlayData(int hdwf, int idxChannel, int node, double[] rgdData, int cdData) {
    int ret = dwfPINVOKE.FDwfAnalogOutNodePlayData(hdwf, idxChannel, node, rgdData, cdData);
    return ret;
  }

  public static int FDwfAnalogIOReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfAnalogIOReset(hdwf);
    return ret;
  }

  public static int FDwfAnalogIOConfigure(int hdwf) {
    int ret = dwfPINVOKE.FDwfAnalogIOConfigure(hdwf);
    return ret;
  }

  public static int FDwfAnalogIOStatus(int hdwf) {
    int ret = dwfPINVOKE.FDwfAnalogIOStatus(hdwf);
    return ret;
  }

  public static int FDwfAnalogIOEnableInfo(int hdwf, ref int pfSet, ref int pfStatus) {
    int ret = dwfPINVOKE.FDwfAnalogIOEnableInfo(hdwf, ref pfSet, ref pfStatus);
    return ret;
  }

  public static int FDwfAnalogIOEnableSet(int hdwf, int fMasterEnable) {
    int ret = dwfPINVOKE.FDwfAnalogIOEnableSet(hdwf, fMasterEnable);
    return ret;
  }

  public static int FDwfAnalogIOEnableGet(int hdwf, ref int pfMasterEnable) {
    int ret = dwfPINVOKE.FDwfAnalogIOEnableGet(hdwf, ref pfMasterEnable);
    return ret;
  }

  public static int FDwfAnalogIOEnableStatus(int hdwf, ref int pfMasterEnable) {
    int ret = dwfPINVOKE.FDwfAnalogIOEnableStatus(hdwf, ref pfMasterEnable);
    return ret;
  }

  public static int FDwfAnalogIOChannelCount(int hdwf, ref int pnChannel) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelCount(hdwf, ref pnChannel);
    return ret;
  }

  public static int FDwfAnalogIOChannelName(int hdwf, int idxChannel, out string szName, out string szLabel) {
    System.Text.StringBuilder sb1 = new System.Text.StringBuilder(32);
    System.Text.StringBuilder sb2 = new System.Text.StringBuilder(8);
    int ret = dwfPINVOKE.FDwfAnalogIOChannelName(hdwf, idxChannel, sb1, sb2);
    szName = sb1.ToString();
    szLabel = sb2.ToString();
    return ret;
  }

  public static int FDwfAnalogIOChannelInfo(int hdwf, int idxChannel, ref int pnNodes) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelInfo(hdwf, idxChannel, ref pnNodes);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeName(int hdwf, int idxChannel, int idxNode, out string szNodeName, out string szNodeUnits) {
    System.Text.StringBuilder sb1 = new System.Text.StringBuilder(32);
    System.Text.StringBuilder sb2 = new System.Text.StringBuilder(8);
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeName(hdwf, idxChannel, idxNode, sb1, sb2);
    szNodeName = sb1.ToString();
    szNodeUnits = sb2.ToString();
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeInfo(int hdwf, int idxChannel, int idxNode, ref byte panalogio) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeInfo(hdwf, idxChannel, idxNode, ref panalogio);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeSetInfo(int hdwf, int idxChannel, int idxNode, ref double pmin, ref double pmax, ref int pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeSetInfo(hdwf, idxChannel, idxNode, ref pmin, ref pmax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeSet(int hdwf, int idxChannel, int idxNode, double value) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeSet(hdwf, idxChannel, idxNode, value);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeGet(int hdwf, int idxChannel, int idxNode, ref double pvalue) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeGet(hdwf, idxChannel, idxNode, ref pvalue);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeStatusInfo(int hdwf, int idxChannel, int idxNode, ref double pmin, ref double pmax, ref int pnSteps) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeStatusInfo(hdwf, idxChannel, idxNode, ref pmin, ref pmax, ref pnSteps);
    return ret;
  }

  public static int FDwfAnalogIOChannelNodeStatus(int hdwf, int idxChannel, int idxNode, ref double pvalue) {
    int ret = dwfPINVOKE.FDwfAnalogIOChannelNodeStatus(hdwf, idxChannel, idxNode, ref pvalue);
    return ret;
  }

  public static int FDwfDigitalIOReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfDigitalIOReset(hdwf);
    return ret;
  }

  public static int FDwfDigitalIOConfigure(int hdwf) {
    int ret = dwfPINVOKE.FDwfDigitalIOConfigure(hdwf);
    return ret;
  }

  public static int FDwfDigitalIOStatus(int hdwf) {
    int ret = dwfPINVOKE.FDwfDigitalIOStatus(hdwf);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableInfo(int hdwf, ref uint pfsOutputEnableMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableInfo(hdwf, ref pfsOutputEnableMask);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableSet(int hdwf, uint fsOutputEnable) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableSet(hdwf, fsOutputEnable);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableGet(int hdwf, ref uint pfsOutputEnable) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableGet(hdwf, ref pfsOutputEnable);
    return ret;
  }

  public static int FDwfDigitalIOOutputInfo(int hdwf, ref uint pfsOutputMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputInfo(hdwf, ref pfsOutputMask);
    return ret;
  }

  public static int FDwfDigitalIOOutputSet(int hdwf, uint fsOutput) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputSet(hdwf, fsOutput);
    return ret;
  }

  public static int FDwfDigitalIOOutputGet(int hdwf, ref uint pfsOutput) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputGet(hdwf, ref pfsOutput);
    return ret;
  }

  public static int FDwfDigitalIOInputInfo(int hdwf, ref uint pfsInputMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOInputInfo(hdwf, ref pfsInputMask);
    return ret;
  }

  public static int FDwfDigitalIOInputStatus(int hdwf, ref uint pfsInput) {
    int ret = dwfPINVOKE.FDwfDigitalIOInputStatus(hdwf, ref pfsInput);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableInfo64(int hdwf, ref ulong pfsOutputEnableMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableInfo64(hdwf, ref pfsOutputEnableMask);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableSet64(int hdwf, ulong fsOutputEnable) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableSet64(hdwf, fsOutputEnable);
    return ret;
  }

  public static int FDwfDigitalIOOutputEnableGet64(int hdwf, ref ulong pfsOutputEnable) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputEnableGet64(hdwf, ref pfsOutputEnable);
    return ret;
  }

  public static int FDwfDigitalIOOutputInfo64(int hdwf, ref ulong pfsOutputMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputInfo64(hdwf, ref pfsOutputMask);
    return ret;
  }

  public static int FDwfDigitalIOOutputSet64(int hdwf, ulong fsOutput) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputSet64(hdwf, fsOutput);
    return ret;
  }

  public static int FDwfDigitalIOOutputGet64(int hdwf, ref ulong pfsOutput) {
    int ret = dwfPINVOKE.FDwfDigitalIOOutputGet64(hdwf, ref pfsOutput);
    return ret;
  }

  public static int FDwfDigitalIOInputInfo64(int hdwf, ref ulong pfsInputMask) {
    int ret = dwfPINVOKE.FDwfDigitalIOInputInfo64(hdwf, ref pfsInputMask);
    return ret;
  }

  public static int FDwfDigitalIOInputStatus64(int hdwf, ref ulong pfsInput) {
    int ret = dwfPINVOKE.FDwfDigitalIOInputStatus64(hdwf, ref pfsInput);
    return ret;
  }

  public static int FDwfDigitalInReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfDigitalInReset(hdwf);
    return ret;
  }

  public static int FDwfDigitalInConfigure(int hdwf, int fReconfigure, int fStart) {
    int ret = dwfPINVOKE.FDwfDigitalInConfigure(hdwf, fReconfigure, fStart);
    return ret;
  }

  public static int FDwfDigitalInStatus(int hdwf, int fReadData, ref byte psts) {
    int ret = dwfPINVOKE.FDwfDigitalInStatus(hdwf, fReadData, ref psts);
    return ret;
  }

  public static int FDwfDigitalInStatusSamplesLeft(int hdwf, ref int pcSamplesLeft) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusSamplesLeft(hdwf, ref pcSamplesLeft);
    return ret;
  }

  public static int FDwfDigitalInStatusSamplesValid(int hdwf, ref int pcSamplesValid) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusSamplesValid(hdwf, ref pcSamplesValid);
    return ret;
  }

  public static int FDwfDigitalInStatusIndexWrite(int hdwf, ref int pidxWrite) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusIndexWrite(hdwf, ref pidxWrite);
    return ret;
  }

  public static int FDwfDigitalInStatusAutoTriggered(int hdwf, ref int pfAuto) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusAutoTriggered(hdwf, ref pfAuto);
    return ret;
  }

  public static int FDwfDigitalInStatusData(int hdwf, byte[] rgData, int countOfDataBytes) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusData(hdwf, rgData, countOfDataBytes);
    return ret;
  }

  public static int FDwfDigitalInStatusData2(int hdwf, byte[] rgData, int idxSample, int countOfDataBytes) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusData2(hdwf, rgData, idxSample, countOfDataBytes);
    return ret;
  }

  public static int FDwfDigitalInStatusNoise2(int hdwf, byte[] rgData, int idxSample, int countOfDataBytes) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusNoise2(hdwf, rgData, idxSample, countOfDataBytes);
    return ret;
  }

  public static int FDwfDigitalInStatusRecord(int hdwf, ref int pcdDataAvailable, ref int pcdDataLost, ref int pcdDataCorrupt) {
    int ret = dwfPINVOKE.FDwfDigitalInStatusRecord(hdwf, ref pcdDataAvailable, ref pcdDataLost, ref pcdDataCorrupt);
    return ret;
  }

  public static int FDwfDigitalInInternalClockInfo(int hdwf, ref double phzFreq) {
    int ret = dwfPINVOKE.FDwfDigitalInInternalClockInfo(hdwf, ref phzFreq);
    return ret;
  }

  public static int FDwfDigitalInClockSourceInfo(int hdwf, ref int pfsDwfDigitalInClockSource) {
    int ret = dwfPINVOKE.FDwfDigitalInClockSourceInfo(hdwf, ref pfsDwfDigitalInClockSource);
    return ret;
  }

  public static int FDwfDigitalInClockSourceSet(int hdwf, int v) {
    int ret = dwfPINVOKE.FDwfDigitalInClockSourceSet(hdwf, v);
    return ret;
  }

  public static int FDwfDigitalInClockSourceGet(int hdwf, ref int pv) {
    int ret = dwfPINVOKE.FDwfDigitalInClockSourceGet(hdwf, ref pv);
    return ret;
  }

  public static int FDwfDigitalInDividerInfo(int hdwf, ref uint pdivMax) {
    int ret = dwfPINVOKE.FDwfDigitalInDividerInfo(hdwf, ref pdivMax);
    return ret;
  }

  public static int FDwfDigitalInDividerSet(int hdwf, uint div) {
    int ret = dwfPINVOKE.FDwfDigitalInDividerSet(hdwf, div);
    return ret;
  }

  public static int FDwfDigitalInDividerGet(int hdwf, ref uint pdiv) {
    int ret = dwfPINVOKE.FDwfDigitalInDividerGet(hdwf, ref pdiv);
    return ret;
  }

  public static int FDwfDigitalInBitsInfo(int hdwf, ref int pnBits) {
    int ret = dwfPINVOKE.FDwfDigitalInBitsInfo(hdwf, ref pnBits);
    return ret;
  }

  public static int FDwfDigitalInSampleFormatSet(int hdwf, int nBits) {
    int ret = dwfPINVOKE.FDwfDigitalInSampleFormatSet(hdwf, nBits);
    return ret;
  }

  public static int FDwfDigitalInSampleFormatGet(int hdwf, ref int pnBits) {
    int ret = dwfPINVOKE.FDwfDigitalInSampleFormatGet(hdwf, ref pnBits);
    return ret;
  }

  public static int FDwfDigitalInInputOrderSet(int hdwf, bool fDioFirst) {
    int ret = dwfPINVOKE.FDwfDigitalInInputOrderSet(hdwf, fDioFirst);
    return ret;
  }

  public static int FDwfDigitalInBufferSizeInfo(int hdwf, ref int pnSizeMax) {
    int ret = dwfPINVOKE.FDwfDigitalInBufferSizeInfo(hdwf, ref pnSizeMax);
    return ret;
  }

  public static int FDwfDigitalInBufferSizeSet(int hdwf, int nSize) {
    int ret = dwfPINVOKE.FDwfDigitalInBufferSizeSet(hdwf, nSize);
    return ret;
  }

  public static int FDwfDigitalInBufferSizeGet(int hdwf, ref int pnSize) {
    int ret = dwfPINVOKE.FDwfDigitalInBufferSizeGet(hdwf, ref pnSize);
    return ret;
  }

  public static int FDwfDigitalInSampleModeInfo(int hdwf, ref int pfsDwfDigitalInSampleMode) {
    int ret = dwfPINVOKE.FDwfDigitalInSampleModeInfo(hdwf, ref pfsDwfDigitalInSampleMode);
    return ret;
  }

  public static int FDwfDigitalInSampleModeSet(int hdwf, int v) {
    int ret = dwfPINVOKE.FDwfDigitalInSampleModeSet(hdwf, v);
    return ret;
  }

  public static int FDwfDigitalInSampleModeGet(int hdwf, ref int pv) {
    int ret = dwfPINVOKE.FDwfDigitalInSampleModeGet(hdwf, ref pv);
    return ret;
  }

  public static int FDwfDigitalInAcquisitionModeInfo(int hdwf, ref int pfsacqmode) {
    int ret = dwfPINVOKE.FDwfDigitalInAcquisitionModeInfo(hdwf, ref pfsacqmode);
    return ret;
  }

  public static int FDwfDigitalInAcquisitionModeSet(int hdwf, int acqmode) {
    int ret = dwfPINVOKE.FDwfDigitalInAcquisitionModeSet(hdwf, acqmode);
    return ret;
  }

  public static int FDwfDigitalInAcquisitionModeGet(int hdwf, ref int pacqmode) {
    int ret = dwfPINVOKE.FDwfDigitalInAcquisitionModeGet(hdwf, ref pacqmode);
    return ret;
  }

  public static int FDwfDigitalInMixedSet(int hdwf, int fEnable) {
    int ret = dwfPINVOKE.FDwfDigitalInMixedSet(hdwf, fEnable);
    return ret;
  }

  public static int FDwfDigitalInTriggerSourceSet(int hdwf, byte trigsrc) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerSourceSet(hdwf, trigsrc);
    return ret;
  }

  public static int FDwfDigitalInTriggerSourceGet(int hdwf, ref byte ptrigsrc) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerSourceGet(hdwf, ref ptrigsrc);
    return ret;
  }

  public static int FDwfDigitalInTriggerSlopeSet(int hdwf, int slope) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerSlopeSet(hdwf, slope);
    return ret;
  }

  public static int FDwfDigitalInTriggerSlopeGet(int hdwf, ref int pslope) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerSlopeGet(hdwf, ref pslope);
    return ret;
  }

  public static int FDwfDigitalInTriggerPositionInfo(int hdwf, ref uint pnSamplesAfterTriggerMax) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerPositionInfo(hdwf, ref pnSamplesAfterTriggerMax);
    return ret;
  }

  public static int FDwfDigitalInTriggerPositionSet(int hdwf, uint cSamplesAfterTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerPositionSet(hdwf, cSamplesAfterTrigger);
    return ret;
  }

  public static int FDwfDigitalInTriggerPositionGet(int hdwf, ref uint pcSamplesAfterTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerPositionGet(hdwf, ref pcSamplesAfterTrigger);
    return ret;
  }

  public static int FDwfDigitalInTriggerPrefillSet(int hdwf, uint cSamplesBeforeTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerPrefillSet(hdwf, cSamplesBeforeTrigger);
    return ret;
  }

  public static int FDwfDigitalInTriggerPrefillGet(int hdwf, ref uint pcSamplesBeforeTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerPrefillGet(hdwf, ref pcSamplesBeforeTrigger);
    return ret;
  }

  public static int FDwfDigitalInTriggerAutoTimeoutInfo(int hdwf, ref double psecMin, ref double psecMax, ref double pnSteps) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerAutoTimeoutInfo(hdwf, ref psecMin, ref psecMax, ref pnSteps);
    return ret;
  }

  public static int FDwfDigitalInTriggerAutoTimeoutSet(int hdwf, double secTimeout) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerAutoTimeoutSet(hdwf, secTimeout);
    return ret;
  }

  public static int FDwfDigitalInTriggerAutoTimeoutGet(int hdwf, ref double psecTimeout) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerAutoTimeoutGet(hdwf, ref psecTimeout);
    return ret;
  }

  public static int FDwfDigitalInTriggerInfo(int hdwf, ref uint pfsLevelLow, ref uint pfsLevelHigh, ref uint pfsEdgeRise, ref uint pfsEdgeFall) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerInfo(hdwf, ref pfsLevelLow, ref pfsLevelHigh, ref pfsEdgeRise, ref pfsEdgeFall);
    return ret;
  }

  public static int FDwfDigitalInTriggerSet(int hdwf, uint fsLevelLow, uint fsLevelHigh, uint fsEdgeRise, uint fsEdgeFall) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerSet(hdwf, fsLevelLow, fsLevelHigh, fsEdgeRise, fsEdgeFall);
    return ret;
  }

  public static int FDwfDigitalInTriggerGet(int hdwf, ref uint pfsLevelLow, ref uint pfsLevelHigh, ref uint pfsEdgeRise, ref uint pfsEdgeFall) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerGet(hdwf, ref pfsLevelLow, ref pfsLevelHigh, ref pfsEdgeRise, ref pfsEdgeFall);
    return ret;
  }

  public static int FDwfDigitalInTriggerResetSet(int hdwf, uint fsLevelLow, uint fsLevelHigh, uint fsEdgeRise, uint fsEdgeFall) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerResetSet(hdwf, fsLevelLow, fsLevelHigh, fsEdgeRise, fsEdgeFall);
    return ret;
  }

  public static int FDwfDigitalInTriggerCountSet(int hdwf, int cCount, int fRestart) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerCountSet(hdwf, cCount, fRestart);
    return ret;
  }

  public static int FDwfDigitalInTriggerLengthSet(int hdwf, double secMin, double secMax, int idxSync) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerLengthSet(hdwf, secMin, secMax, idxSync);
    return ret;
  }

  public static int FDwfDigitalInTriggerMatchSet(int hdwf, int iPin, uint fsMask, uint fsValue, int cBitStuffing) {
    int ret = dwfPINVOKE.FDwfDigitalInTriggerMatchSet(hdwf, iPin, fsMask, fsValue, cBitStuffing);
    return ret;
  }

  public static int FDwfDigitalOutReset(int hdwf) {
    int ret = dwfPINVOKE.FDwfDigitalOutReset(hdwf);
    return ret;
  }

  public static int FDwfDigitalOutConfigure(int hdwf, int fStart) {
    int ret = dwfPINVOKE.FDwfDigitalOutConfigure(hdwf, fStart);
    return ret;
  }

  public static int FDwfDigitalOutStatus(int hdwf, ref byte psts) {
    int ret = dwfPINVOKE.FDwfDigitalOutStatus(hdwf, ref psts);
    return ret;
  }

  public static int FDwfDigitalOutInternalClockInfo(int hdwf, ref double phzFreq) {
    int ret = dwfPINVOKE.FDwfDigitalOutInternalClockInfo(hdwf, ref phzFreq);
    return ret;
  }

  public static int FDwfDigitalOutTriggerSourceSet(int hdwf, int trigsrc) {
    int ret = dwfPINVOKE.FDwfDigitalOutTriggerSourceSet(hdwf, trigsrc);
    return ret;
  }

  public static int FDwfDigitalOutTriggerSourceGet(int hdwf, ref int ptrigsrc) {
    int ret = dwfPINVOKE.FDwfDigitalOutTriggerSourceGet(hdwf, ref ptrigsrc);
    return ret;
  }

  public static int FDwfDigitalOutRunInfo(int hdwf, ref double psecMin, ref double psecMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutRunInfo(hdwf, ref psecMin, ref psecMax);
    return ret;
  }

  public static int FDwfDigitalOutRunSet(int hdwf, double secRun) {
    int ret = dwfPINVOKE.FDwfDigitalOutRunSet(hdwf, secRun);
    return ret;
  }

  public static int FDwfDigitalOutRunGet(int hdwf, ref double psecRun) {
    int ret = dwfPINVOKE.FDwfDigitalOutRunGet(hdwf, ref psecRun);
    return ret;
  }

  public static int FDwfDigitalOutRunStatus(int hdwf, ref double psecRun) {
    int ret = dwfPINVOKE.FDwfDigitalOutRunStatus(hdwf, ref psecRun);
    return ret;
  }

  public static int FDwfDigitalOutWaitInfo(int hdwf, ref double psecMin, ref double psecMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutWaitInfo(hdwf, ref psecMin, ref psecMax);
    return ret;
  }

  public static int FDwfDigitalOutWaitSet(int hdwf, double secWait) {
    int ret = dwfPINVOKE.FDwfDigitalOutWaitSet(hdwf, secWait);
    return ret;
  }

  public static int FDwfDigitalOutWaitGet(int hdwf, ref double psecWait) {
    int ret = dwfPINVOKE.FDwfDigitalOutWaitGet(hdwf, ref psecWait);
    return ret;
  }

  public static int FDwfDigitalOutRepeatInfo(int hdwf, ref uint pnMin, ref uint pnMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatInfo(hdwf, ref pnMin, ref pnMax);
    return ret;
  }

  public static int FDwfDigitalOutRepeatSet(int hdwf, uint cRepeat) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatSet(hdwf, cRepeat);
    return ret;
  }

  public static int FDwfDigitalOutRepeatGet(int hdwf, ref uint pcRepeat) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatGet(hdwf, ref pcRepeat);
    return ret;
  }

  public static int FDwfDigitalOutRepeatStatus(int hdwf, ref uint pcRepeat) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatStatus(hdwf, ref pcRepeat);
    return ret;
  }

  public static int FDwfDigitalOutTriggerSlopeSet(int hdwf, int slope) {
    int ret = dwfPINVOKE.FDwfDigitalOutTriggerSlopeSet(hdwf, slope);
    return ret;
  }

  public static int FDwfDigitalOutTriggerSlopeGet(int hdwf, ref int pslope) {
    int ret = dwfPINVOKE.FDwfDigitalOutTriggerSlopeGet(hdwf, ref pslope);
    return ret;
  }

  public static int FDwfDigitalOutRepeatTriggerSet(int hdwf, int fRepeatTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatTriggerSet(hdwf, fRepeatTrigger);
    return ret;
  }

  public static int FDwfDigitalOutRepeatTriggerGet(int hdwf, ref int pfRepeatTrigger) {
    int ret = dwfPINVOKE.FDwfDigitalOutRepeatTriggerGet(hdwf, ref pfRepeatTrigger);
    return ret;
  }

  public static int FDwfDigitalOutCount(int hdwf, ref int pcChannel) {
    int ret = dwfPINVOKE.FDwfDigitalOutCount(hdwf, ref pcChannel);
    return ret;
  }

  public static int FDwfDigitalOutEnableSet(int hdwf, int idxChannel, int fEnable) {
    int ret = dwfPINVOKE.FDwfDigitalOutEnableSet(hdwf, idxChannel, fEnable);
    return ret;
  }

  public static int FDwfDigitalOutEnableGet(int hdwf, int idxChannel, ref int pfEnable) {
    int ret = dwfPINVOKE.FDwfDigitalOutEnableGet(hdwf, idxChannel, ref pfEnable);
    return ret;
  }

  public static int FDwfDigitalOutOutputInfo(int hdwf, int idxChannel, ref int pfsDwfDigitalOutOutput) {
    int ret = dwfPINVOKE.FDwfDigitalOutOutputInfo(hdwf, idxChannel, ref pfsDwfDigitalOutOutput);
    return ret;
  }

  public static int FDwfDigitalOutOutputSet(int hdwf, int idxChannel, int v) {
    int ret = dwfPINVOKE.FDwfDigitalOutOutputSet(hdwf, idxChannel, v);
    return ret;
  }

  public static int FDwfDigitalOutOutputGet(int hdwf, int idxChannel, ref int pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutOutputGet(hdwf, idxChannel, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutTypeInfo(int hdwf, int idxChannel, ref int pfsDwfDigitalOutType) {
    int ret = dwfPINVOKE.FDwfDigitalOutTypeInfo(hdwf, idxChannel, ref pfsDwfDigitalOutType);
    return ret;
  }

  public static int FDwfDigitalOutTypeSet(int hdwf, int idxChannel, int v) {
    int ret = dwfPINVOKE.FDwfDigitalOutTypeSet(hdwf, idxChannel, v);
    return ret;
  }

  public static int FDwfDigitalOutTypeGet(int hdwf, int idxChannel, ref int pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutTypeGet(hdwf, idxChannel, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutIdleInfo(int hdwf, int idxChannel, ref int pfsDwfDigitalOutIdle) {
    int ret = dwfPINVOKE.FDwfDigitalOutIdleInfo(hdwf, idxChannel, ref pfsDwfDigitalOutIdle);
    return ret;
  }

  public static int FDwfDigitalOutIdleSet(int hdwf, int idxChannel, int v) {
    int ret = dwfPINVOKE.FDwfDigitalOutIdleSet(hdwf, idxChannel, v);
    return ret;
  }

  public static int FDwfDigitalOutIdleGet(int hdwf, int idxChannel, ref int pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutIdleGet(hdwf, idxChannel, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutDividerInfo(int hdwf, int idxChannel, ref uint vMin, ref uint vMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutDividerInfo(hdwf, idxChannel, ref vMin, ref vMax);
    return ret;
  }

  public static int FDwfDigitalOutDividerInitSet(int hdwf, int idxChannel, uint v) {
    int ret = dwfPINVOKE.FDwfDigitalOutDividerInitSet(hdwf, idxChannel, v);
    return ret;
  }

  public static int FDwfDigitalOutDividerInitGet(int hdwf, int idxChannel, ref uint pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutDividerInitGet(hdwf, idxChannel, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutDividerSet(int hdwf, int idxChannel, uint v) {
    int ret = dwfPINVOKE.FDwfDigitalOutDividerSet(hdwf, idxChannel, v);
    return ret;
  }

  public static int FDwfDigitalOutDividerGet(int hdwf, int idxChannel, ref uint pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutDividerGet(hdwf, idxChannel, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutCounterInfo(int hdwf, int idxChannel, ref uint vMin, ref uint vMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutCounterInfo(hdwf, idxChannel, ref vMin, ref vMax);
    return ret;
  }

  public static int FDwfDigitalOutCounterInitSet(int hdwf, int idxChannel, int fHigh, uint v) {
    int ret = dwfPINVOKE.FDwfDigitalOutCounterInitSet(hdwf, idxChannel, fHigh, v);
    return ret;
  }

  public static int FDwfDigitalOutCounterInitGet(int hdwf, int idxChannel, ref int pfHigh, ref uint pv) {
    int ret = dwfPINVOKE.FDwfDigitalOutCounterInitGet(hdwf, idxChannel, ref pfHigh, ref pv);
    return ret;
  }

  public static int FDwfDigitalOutCounterSet(int hdwf, int idxChannel, uint vLow, uint vHigh) {
    int ret = dwfPINVOKE.FDwfDigitalOutCounterSet(hdwf, idxChannel, vLow, vHigh);
    return ret;
  }

  public static int FDwfDigitalOutCounterGet(int hdwf, int idxChannel, ref uint pvLow, ref uint pvHigh) {
    int ret = dwfPINVOKE.FDwfDigitalOutCounterGet(hdwf, idxChannel, ref pvLow, ref pvHigh);
    return ret;
  }

  public static int FDwfDigitalOutDataInfo(int hdwf, int idxChannel, ref uint pcountOfBitsMax) {
    int ret = dwfPINVOKE.FDwfDigitalOutDataInfo(hdwf, idxChannel, ref pcountOfBitsMax);
    return ret;
  }

  public static int FDwfDigitalOutDataSet(int hdwf, int idxChannel, byte[] rgBits, uint countOfBits) {
    int ret = dwfPINVOKE.FDwfDigitalOutDataSet(hdwf, idxChannel, rgBits, countOfBits);
    return ret;
  }

}
