using RawNet.Extensions;

namespace RawNet.Printer;

public interface IPrinterAdapter
{
    public void PrintRawFile(string printer, string path, string documentName, bool paused = false);

    public void PrintRawFile(string printer, string path, bool paused = false);

    public void PrintRawFile(string printer, FileInfo file, bool paused = false);

    public void PrintRawStream(string printer, Stream stream, string documentName, bool paused = false);

    public void PrintRawStream(string printer, Stream stream, string documentName, bool paused, int pagecount);

    public event EventHandler<JobCreatedEventArgs> OnJobCreated;
}