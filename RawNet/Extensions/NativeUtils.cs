using System.Runtime.InteropServices;

namespace RawNet.Extensions;

internal static class NativeUtils
{
    [DllImport("winspool.drv", SetLastError = true)]
    public static extern int ClosePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int GetPrinterDriver(IntPtr hPrinter, string pEnvironment, int Level, IntPtr pDriverInfo, int cbBuf, ref int pcbNeeded);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern uint StartDocPrinterW(IntPtr hPrinter, uint level, [MarshalAs(UnmanagedType.Struct)] ref DOC_INFO_1 di1);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int EndDocPrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int StartPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int EndPagePrinter(IntPtr hPrinter);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int WritePrinter(IntPtr hPrinter, [In, Out] byte[] pBuf, int cbBuf, ref int pcWritten);

    [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int OpenPrinterW(string pPrinterName, out IntPtr phPrinter, ref PRINTER_DEFAULTS pDefault);

    [DllImport("winspool.drv", EntryPoint = "SetJobA", SetLastError = true)]
    public static extern int SetJob(IntPtr hPrinter, uint JobId, uint Level, IntPtr pJob, uint Command_Renamed);
}