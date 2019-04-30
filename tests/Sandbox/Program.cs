// Program.cs for Sandbox
// By: Adam Renaud
// Created: 2019-04-30
// This Sandbox application serves as a Staging Area for
// The tests that are created in the tests folder. This
// code will not always be the same and will often change from time
// to time

using System;
using System.IO;
using DxfLibrary;
using DxfLibrary.IO;

namespace Sandbox
{
    class Program
    {
        private static string _dirname = @"C:\Dev\dxfTestData\";

        static void Main(string[] args)
        {
            Log("Starting Sandbox");

            var testFile = Path.Join(_dirname, "BinTest.dxf");
            Log($"Opening File {testFile}");

            using(var stream = new FileStream(testFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var dxfFile = new DxfFile(stream, true);   
            }

        }

        private static void Log(object message)
        {
            Console.WriteLine($"[{DateTime.Now}] -- {message.ToString()}");
        }
    }
}
