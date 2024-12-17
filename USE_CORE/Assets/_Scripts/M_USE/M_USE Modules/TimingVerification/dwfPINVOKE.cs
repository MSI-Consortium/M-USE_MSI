
using System.Runtime.InteropServices;

class dwfPINVOKE {

  [DllImport("dwf.dll", EntryPoint = "FDwfGetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfGetLastError(ref int jarg1);

  [DllImport("dwf.dll", EntryPoint = "FDwfGetLastErrorMsg", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfGetLastErrorMsg([MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg1);

  [DllImport("dwf.dll", EntryPoint = "FDwfGetVersion", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfGetVersion([MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg1);

  [DllImport("dwf.dll", EntryPoint = "FDwfEnum", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfEnum(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfEnumDeviceType", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfEnumDeviceType(int jarg1, ref int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfEnumDeviceIsOpened", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfEnumDeviceIsOpened(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint = "FDwfEnumUserName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfEnumUserName(int jarg1, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg2);

  [DllImport("dwf.dll", EntryPoint = "FDwfEnumDeviceName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfEnumDeviceName(int jarg1, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg2);

  [DllImport("dwf.dll", EntryPoint = "FDwfEnumSN", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfEnumSN(int jarg1, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfEnumConfig", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfEnumConfig(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfEnumConfigInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfEnumConfigInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceOpen", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceOpen(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceConfigOpen", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceConfigOpen(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceClose", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceClose(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceCloseAll", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceCloseAll();

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceAutoConfigureSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceAutoConfigureSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceAutoConfigureGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceAutoConfigureGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceEnableSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceTriggerInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceTriggerInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceTriggerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceTriggerSet(int jarg1, int jarg2, byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceTriggerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceTriggerGet(int jarg1, int jarg2, ref byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceTriggerPC", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceTriggerPC(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDeviceTriggerSlopeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDeviceTriggerSlopeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInConfigure(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatus(int jarg1, int jarg2, ref byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusSamplesLeft", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusSamplesLeft(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusSamplesValid", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusSamplesValid(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusIndexWrite", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusIndexWrite(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusAutoTriggered", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusAutoTriggered(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusData", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusData(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]double[] jarg3, int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusData2", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusData2(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]double[] jarg3, int jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusData16", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusData16(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]short[] jarg3, int jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusNoise", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusNoise(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]double[] jarg3, ref double jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusNoise2", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusNoise2(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]double[] jarg3, ref double jarg4, int jarg5, int jarg6);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusSample", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusSample(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusTime", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusTime(int jarg1, ref uint jarg2, ref uint jarg3, ref uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInStatusRecord", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInStatusRecord(int jarg1, ref int jarg2, ref int jarg3, ref int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInRecordLengthSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInRecordLengthSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInRecordLengthGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInRecordLengthGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInFrequencyInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInFrequencyInfo(int jarg1, ref double jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInFrequencySet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInFrequencySet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInFrequencyGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInFrequencyGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInBitsInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInBitsInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInBufferSizeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInBufferSizeInfo(int jarg1, ref int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInBufferSizeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInBufferSizeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInBufferSizeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInBufferSizeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInNoiseSizeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInNoiseSizeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInNoiseSizeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInNoiseSizeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInNoiseSizeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInNoiseSizeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInAcquisitionModeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInAcquisitionModeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInAcquisitionModeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInAcquisitionModeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInAcquisitionModeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInAcquisitionModeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelCount", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelCount(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelEnableSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelEnableGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelFilterInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelFilterInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelFilterSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelFilterSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelFilterGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelFilterGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelRangeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelRangeInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelRangeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelRangeSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelRangeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelRangeGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelOffsetInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelOffsetInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelOffsetSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelOffsetSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelOffsetGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelOffsetGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelAttenuationSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelAttenuationSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelAttenuationGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelAttenuationGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelCouplingInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelCouplingInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelCouplingSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelCouplingSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInChannelCouplingGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInChannelCouplingGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceEnableSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceEnableGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceReferenceInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceReferenceInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceReferenceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceReferenceSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogImpedanceReferenceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogImpedanceReferenceGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerSourceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerSourceSet(int jarg1, byte jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerSourceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerSourceGet(int jarg1, ref byte jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerPositionInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerPositionInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerPositionSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerPositionSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerPositionGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerPositionGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerPositionStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerPositionStatus(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerAutoTimeoutInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerAutoTimeoutInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerAutoTimeoutSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerAutoTimeoutSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerAutoTimeoutGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerAutoTimeoutGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHoldOffInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHoldOffInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHoldOffSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHoldOffSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHoldOffGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHoldOffGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerTypeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerTypeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerTypeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerTypeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerTypeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerTypeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerChannelInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerChannelInfo(int jarg1, ref int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerChannelSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerChannelSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerChannelGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerChannelGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerFilterInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerFilterInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerFilterSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerFilterSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerFilterGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerFilterGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLevelInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLevelInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLevelSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLevelSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLevelGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLevelGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHysteresisInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHysteresisInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHysteresisSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHysteresisSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerHysteresisGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerHysteresisGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerConditionInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerConditionInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerConditionSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerConditionSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerConditionGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerConditionGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthConditionInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthConditionInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthConditionSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthConditionSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerLengthConditionGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerLengthConditionGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogInTriggerForce", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogInTriggerForce(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutCount", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutCount(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutMasterSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutMasterSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutMasterGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutMasterGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutTriggerSourceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutTriggerSourceSet(int jarg1, int jarg2, byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutTriggerSourceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutTriggerSourceGet(int jarg1, int jarg2, ref byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutTriggerSlopeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutTriggerSlopeSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutTriggerSlopeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutTriggerSlopeGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRunInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRunInfo(int jarg1, int jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRunSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRunSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRunGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRunGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRunStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRunStatus(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutWaitInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutWaitInfo(int jarg1, int jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutWaitSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutWaitSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutWaitGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutWaitGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatInfo(int jarg1, int jarg2, ref int jarg3, ref int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatStatus(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatTriggerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatTriggerSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutRepeatTriggerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutRepeatTriggerGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutLimitationInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutLimitationInfo(int jarg1, int jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutLimitationSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutLimitationSet(int jarg1, int jarg2, double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutLimitationGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutLimitationGet(int jarg1, int jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutModeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutModeSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutModeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutModeGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutIdleInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutIdleInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutIdleSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutIdleSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutIdleGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutIdleGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeEnableSet(int jarg1, int jarg2, int jarg3, int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeEnableGet(int jarg1, int jarg2, int jarg3, ref int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFunctionInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFunctionInfo(int jarg1, int jarg2, int jarg3, ref int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFunctionSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFunctionSet(int jarg1, int jarg2, int jarg3, byte jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFunctionGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFunctionGet(int jarg1, int jarg2, int jarg3, ref byte jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFrequencyInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFrequencyInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFrequencySet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFrequencySet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeFrequencyGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeFrequencyGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeAmplitudeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeAmplitudeInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeAmplitudeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeAmplitudeSet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeAmplitudeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeAmplitudeGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeOffsetInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeOffsetInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeOffsetSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeOffsetSet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeOffsetGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeOffsetGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeSymmetryInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeSymmetryInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeSymmetrySet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeSymmetrySet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeSymmetryGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeSymmetryGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodePhaseInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodePhaseInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodePhaseSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodePhaseSet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodePhaseGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodePhaseGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeDataInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeDataInfo(int jarg1, int jarg2, int jarg3, ref int jarg4, ref int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodeDataSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodeDataSet(int jarg1, int jarg2, int jarg3, [MarshalAs(UnmanagedType.LPArray)]double[] jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutCustomAMFMEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutCustomAMFMEnableSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutCustomAMFMEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutCustomAMFMEnableGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutReset(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutConfigure(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutStatus(int jarg1, int jarg2, ref byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodePlayStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodePlayStatus(int jarg1, int jarg2, int jarg3, ref int jarg4, ref int jarg5, ref int jarg6);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogOutNodePlayData", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogOutNodePlayData(int jarg1, int jarg2, int jarg3, [MarshalAs(UnmanagedType.LPArray)]double[] jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOConfigure(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOStatus(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOEnableInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOEnableInfo(int jarg1, ref int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOEnableSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOEnableGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOEnableStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOEnableStatus(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelCount", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelCount(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint = "FDwfAnalogIOChannelName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfAnalogIOChannelName(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg3, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint = "FDwfAnalogIOChannelNodeName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
  public static extern int FDwfAnalogIOChannelNodeName(int jarg1, int jarg2, int jarg3, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg4, [MarshalAs(UnmanagedType.LPStr)] System.Text.StringBuilder jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeInfo(int jarg1, int jarg2, int jarg3, ref byte jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeSetInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeSetInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5, ref int jarg6);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeSet(int jarg1, int jarg2, int jarg3, double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeGet(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeStatusInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeStatusInfo(int jarg1, int jarg2, int jarg3, ref double jarg4, ref double jarg5, ref int jarg6);

  [DllImport("dwf.dll", EntryPoint="FDwfAnalogIOChannelNodeStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfAnalogIOChannelNodeStatus(int jarg1, int jarg2, int jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOConfigure(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOStatus(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableInfo(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputInfo(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOInputInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOInputInfo(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOInputStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOInputStatus(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableInfo64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableInfo64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableSet64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableSet64(int jarg1, ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputEnableGet64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputEnableGet64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputInfo64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputInfo64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputSet64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputSet64(int jarg1, ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOOutputGet64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOOutputGet64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOInputInfo64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOInputInfo64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalIOInputStatus64", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalIOInputStatus64(int jarg1, ref ulong jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInConfigure(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatus(int jarg1, int jarg2, ref byte jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusSamplesLeft", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusSamplesLeft(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusSamplesValid", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusSamplesValid(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusIndexWrite", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusIndexWrite(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusAutoTriggered", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusAutoTriggered(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusData", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusData(int jarg1, [MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusData2", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusData2(int jarg1, [MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, int jarg3, int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusNoise2", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusNoise2(int jarg1, [MarshalAs(UnmanagedType.LPArray)]byte[] jarg2, int jarg3, int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInStatusRecord", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInStatusRecord(int jarg1, ref int jarg2, ref int jarg3, ref int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInInternalClockInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInInternalClockInfo(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInClockSourceInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInClockSourceInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInClockSourceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInClockSourceSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInClockSourceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInClockSourceGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInDividerInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInDividerInfo(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInDividerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInDividerSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInDividerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInDividerGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInBitsInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInBitsInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInSampleFormatSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInSampleFormatSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInSampleFormatGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInSampleFormatGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInInputOrderSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInInputOrderSet(int jarg1, bool jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInBufferSizeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInBufferSizeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInBufferSizeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInBufferSizeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInBufferSizeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInBufferSizeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInSampleModeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInSampleModeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInSampleModeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInSampleModeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInSampleModeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInSampleModeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInAcquisitionModeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInAcquisitionModeInfo(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInAcquisitionModeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInAcquisitionModeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInAcquisitionModeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInAcquisitionModeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInMixedSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInMixedSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerSourceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerSourceSet(int jarg1, byte jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerSourceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerSourceGet(int jarg1, ref byte jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerSlopeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerSlopeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerSlopeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerSlopeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerPositionInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerPositionInfo(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerPositionSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerPositionSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerPositionGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerPositionGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerPrefillSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerPrefillSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerPrefillGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerPrefillGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerAutoTimeoutInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerAutoTimeoutInfo(int jarg1, ref double jarg2, ref double jarg3, ref double jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerAutoTimeoutSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerAutoTimeoutSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerAutoTimeoutGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerAutoTimeoutGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerInfo(int jarg1, ref uint jarg2, ref uint jarg3, ref uint jarg4, ref uint jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerSet(int jarg1, uint jarg2, uint jarg3, uint jarg4, uint jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerGet(int jarg1, ref uint jarg2, ref uint jarg3, ref uint jarg4, ref uint jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerResetSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerResetSet(int jarg1, uint jarg2, uint jarg3, uint jarg4, uint jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerCountSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerCountSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerLengthSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerLengthSet(int jarg1, double jarg2, double jarg3, int jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalInTriggerMatchSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalInTriggerMatchSet(int jarg1, int jarg2, uint jarg3, uint jarg4, int jarg5);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutReset", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutReset(int jarg1);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutConfigure", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutConfigure(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutStatus(int jarg1, ref byte jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutInternalClockInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutInternalClockInfo(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTriggerSourceSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTriggerSourceSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTriggerSourceGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTriggerSourceGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRunInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRunInfo(int jarg1, ref double jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRunSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRunSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRunGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRunGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRunStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRunStatus(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutWaitInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutWaitInfo(int jarg1, ref double jarg2, ref double jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutWaitSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutWaitSet(int jarg1, double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutWaitGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutWaitGet(int jarg1, ref double jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatInfo(int jarg1, ref uint jarg2, ref uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatSet(int jarg1, uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatGet(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatStatus", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatStatus(int jarg1, ref uint jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTriggerSlopeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTriggerSlopeSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTriggerSlopeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTriggerSlopeGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatTriggerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatTriggerSet(int jarg1, int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutRepeatTriggerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutRepeatTriggerGet(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCount", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCount(int jarg1, ref int jarg2);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutEnableSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutEnableSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutEnableGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutEnableGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutOutputInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutOutputInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutOutputSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutOutputSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutOutputGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutOutputGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTypeInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTypeInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTypeSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTypeSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutTypeGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutTypeGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutIdleInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutIdleInfo(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutIdleSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutIdleSet(int jarg1, int jarg2, int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutIdleGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutIdleGet(int jarg1, int jarg2, ref int jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDividerInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDividerInfo(int jarg1, int jarg2, ref uint jarg3, ref uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDividerInitSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDividerInitSet(int jarg1, int jarg2, uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDividerInitGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDividerInitGet(int jarg1, int jarg2, ref uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDividerSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDividerSet(int jarg1, int jarg2, uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDividerGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDividerGet(int jarg1, int jarg2, ref uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCounterInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCounterInfo(int jarg1, int jarg2, ref uint jarg3, ref uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCounterInitSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCounterInitSet(int jarg1, int jarg2, int jarg3, uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCounterInitGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCounterInitGet(int jarg1, int jarg2, ref int jarg3, ref uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCounterSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCounterSet(int jarg1, int jarg2, uint jarg3, uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutCounterGet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutCounterGet(int jarg1, int jarg2, ref uint jarg3, ref uint jarg4);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDataInfo", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDataInfo(int jarg1, int jarg2, ref uint jarg3);

  [DllImport("dwf.dll", EntryPoint="FDwfDigitalOutDataSet", CallingConvention = CallingConvention.Cdecl)]
  public static extern int FDwfDigitalOutDataSet(int jarg1, int jarg2, [MarshalAs(UnmanagedType.LPArray)]byte[] jarg3, uint jarg4);

}
