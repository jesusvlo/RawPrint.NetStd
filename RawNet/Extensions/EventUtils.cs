namespace RawNet.Extensions;

public sealed class JobCreatedEventArgs : EventArgs
{
    public uint Id { get; set; }

    public string PrinterName { get; set; } = null!;
}