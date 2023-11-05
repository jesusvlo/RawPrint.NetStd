RawNet
===============

Библиотека для отправки файла или двоичного потока непосредственно на принтер, в обход драйвера.

Отправляйте PostScript, PCL, PDF и другие файлы на принтер.

Пример:

    IPrinter printer = new Printer();

    // Print the file
    printer.PrintRawFile(PrinterName, Filepath, Filename);