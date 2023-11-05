using Microsoft.Win32.SafeHandles;
using RawNet.Extensions;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace RawNet.Printer.Safe;

internal sealed class SafePrinter : SafeHandleZeroOrMinusOneIsInvalid
{
    private SafePrinter(IntPtr hPrinter) : base(true)
    {
        handle = hPrinter;
    }

    protected override bool ReleaseHandle()
    {
        if (IsInvalid)
            return false;

        var result = NativeUtils.ClosePrinter(handle) != 0;
        handle = IntPtr.Zero;

        return result;
    }

    private static IEnumerable<string> ReadMultiSz(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
            yield break;

        var builder = new StringBuilder();
        var pos = ptr;

        while (true)
        {
            var c = (char)Marshal.ReadInt16(pos);

            if (c == '\0')
            {
                if (builder.Length == 0)
                    break;

                yield return builder.ToString();
                builder = new StringBuilder();
            }
            else
            {
                builder.Append(c);
            }

            pos += 2;
        }
    }

    public static SafePrinter OpenPrinter(string printerName, ref PRINTER_DEFAULTS defaults)
    {
        if (NativeUtils.OpenPrinterW(printerName, out IntPtr hPrinter, ref defaults) == 0)
            throw new Win32Exception();

        return new SafePrinter(hPrinter);
    }

    public uint StartDocPrinter(DOC_INFO_1 di1)
    {
        var id = NativeUtils.StartDocPrinterW(handle, 1, ref di1);
        if (id == 0)
        {
            if (Marshal.GetLastWin32Error() == 1804)
                throw new Win32Exception("The specified datatype is invalid, try setting 'Enable advanced printing features' in printer properties.");

            throw new Win32Exception();
        }

        return id;
    }

    public void EndDocPrinter()
    {
        if (NativeUtils.EndDocPrinter(handle) == 0)
            throw new Win32Exception();
    }

    public void StartPagePrinter()
    {
        if (NativeUtils.StartPagePrinter(handle) == 0)
            throw new Win32Exception();
    }

    public void EndPagePrinter()
    {
        if (NativeUtils.EndPagePrinter(handle) == 0)
            throw new Win32Exception();
    }

    public void WritePrinter(byte[] buffer, int size)
    {
        int written = 0;
        if (NativeUtils.WritePrinter(handle, buffer, size, ref written) == 0)
            throw new Win32Exception(Marshal.GetLastWin32Error());
    }

    public IEnumerable<string> GetPrinterDriverDependentFiles()
    {
        int bufferSize = 0;

        if (NativeUtils.GetPrinterDriver(handle, null!, 3, IntPtr.Zero, 0, ref bufferSize) != 0 || Marshal.GetLastWin32Error() != 122)
            throw new Win32Exception();

        var ptr = Marshal.AllocHGlobal(bufferSize);

        try
        {
            if (NativeUtils.GetPrinterDriver(handle, null!, 3, ptr, bufferSize, ref bufferSize) == 0)
                throw new Win32Exception();

            var di3 = (DRIVER_INFO_3)Marshal.PtrToStructure(ptr, typeof(DRIVER_INFO_3))!;

            return ReadMultiSz(di3.pDependentFiles).ToList();
        }
        finally
        {
            Marshal.FreeHGlobal(ptr);
        }
    }
}