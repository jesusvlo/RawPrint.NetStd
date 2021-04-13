RawPrint.Stream
===============

.Net Core library to send stream directly to a Windows printer bypassing the printer driver.

Send PostScript, PCL or other binary stream directly to a printer.

Requires .Net Core runtime.

Usage:

        using RawPrint;
	
        // Create an instance of the Printer
        IPrinter printer = new Printer();
    
        // Print the file
        printer.PrintRawStream(PrinterName, Stream, JobName);

Installation:

To install Raw Print, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

	PM> Install-Package RawPrint.Stream

*2021-04-13 Version 0.0.1*
