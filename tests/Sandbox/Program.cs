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
