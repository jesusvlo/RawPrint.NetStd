﻿using System;
using RawPrint;

namespace RP
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Syntax:\n\n    rp <printer name> <file name>\n");
                    return;
                }

                var printer = new Printer();
                printer.PrintRawFile(args[0], args[1], args[1]);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
