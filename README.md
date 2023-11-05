RawPrint.NetStd
===============

.Net Standard library to send files or binary stream directly to a Windows printer bypassing the printer driver.

Send PostScript, PCL files or other binary stream directly to a printer.

Usage:

    using RawPrint;

    // Create an instance of the Printer
    IPrinter printer = new Printer();

    // Print the file
    printer.PrintRawFile(PrinterName, Filepath, Filename);