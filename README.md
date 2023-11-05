# RawNet

Библиотека для отправки файлов и потоков данных на принтер, минуя драйвер.
Форк оригинальной библиотеки, расположенной по адресу

<https://github.com/frogmorecs/RawPrint>

Примеры использования:

1. Стандартный вариант
```csharp
var printer = new PrinterAdapter();
printer.PrintRawFile(printerName, fileFullPath, fileName);
```

2. Перегрузка, использующая FileInfo
```csharp
var file = new FileInfo(pathFile);
var printer = new PrinterAdapter();
printer.PrintRawFile(printerName, file);
```
