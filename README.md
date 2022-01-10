RawPrint.NetStd (Version NetStd 2.0)
===============

.Net Standard library to send files or binary stream directly to a Windows printer bypassing the printer driver.

Send PostScript, PCL files or other binary stream directly to a printer.

Usage:

    using RawPrint;

    // Create an instance of the Printer
    IPrinter printer = new Printer();

    // Print the file
    printer.PrintRawFile(PrinterName, Filepath, Filename);

Installation:

To install Raw Print, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

	PM> Install-Package RawPrint.NetStd

*2021-04-13 Version 0.1.0*

