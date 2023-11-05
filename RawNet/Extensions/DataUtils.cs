using System.Runtime.InteropServices;

namespace RawNet.Extensions;

public enum JobControl
{
    Pause = 0x01,

    Resume = 0x02,

    Cancel = 0x03,

    Restart = 0x04,

    Delete = 0x05,

    Retain = 0x08,

    Release = 0x09,
}

[Flags]
internal enum PRINTER_ACCESS_MASK : uint
{
    PRINTER_ACCESS_ADMINISTER = 0x00000004,

    PRINTER_ACCESS_USE = 0x00000008,

    PRINTER_ACCESS_MANAGE_LIMITED = 0x00000040,

    PRINTER_ALL_ACCESS = 0x000F000C,
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct PRINTER_DEFAULTS
{
    private IntPtr pDevMode;

    public string pDatatype;

    public PRINTER_ACCESS_MASK DesiredPrinterAccess;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DOC_INFO_1
{
    public string pDocName;

    public string pOutputFile;

    public string pDataType;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DRIVER_INFO_3
{
    public uint cVersion;

    public string pName;

    public string pEnvironment;

    public string pDriverPath;

    public string pDataFile;

    public string pConfigFile;

    public string pHelpFile;

    public IntPtr pDependentFiles;

    public string pMonitorName;

    public string pDefaultDataType;
}