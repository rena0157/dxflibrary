// Program.cs for Sandbox
// By: Adam Renaud
// Created: 2019-04-30
// This Sandbox application serves as a Staging Area for
// The tests that are created in the tests folder. This
// code will not always be the same and will often change from time
// to time

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DxfLibrary;
using DxfLibrary.IO;
using DxfLibrary.Entities;

namespace Sandbox
{
    class Program
    {
        /// <summary>
        /// Test Directory
        /// </summary>
        private static string _dirname = @"C:\Dev\dxfTestData\";

        private static DxfFile _file;

        private static string testFile = Path.Join(_dirname, "BinTest.dxf");

        /// <summary>
        /// The Main Function
        /// </summary>
        /// <param name="args">General Arguments</param>
        static void Main(string[] args)
        {
            Log("Starting Sandbox");

            _file = ReadFile(testFile);
            
            using(var watcher = new FileSystemWatcher())
            {
                watcher.NotifyFilter = NotifyFilters.Attributes
                                       | NotifyFilters.LastAccess
                                       | NotifyFilters.LastWrite 
                                       | NotifyFilters.CreationTime
                                       | NotifyFilters.DirectoryName
                                       | NotifyFilters.FileName
                                       | NotifyFilters.Security
                                       | NotifyFilters.Size;

                watcher.Path = _dirname;

                watcher.Changed += FileChangedEvent;

                watcher.Filter = "*.dxf";

                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Press q to Quit");
                while (Console.ReadLine() != "q") ; 
            }

        }

        /// <summary>
        /// Logs a message to the console
        /// </summary>
        /// <param name="message">The message parameter that will be logged to the console</param>
        private static void Log(object message)
        {
            Console.WriteLine($"[{DateTime.Now}] -- {message.ToString()}");
        }

        private static void FileChangedEvent(object sender, FileSystemEventArgs e)
        {
            Log("File Changed...");
            _file = ReadFile(testFile);

            foreach(var entity in _file.Entities)
            {
                Log($"Entity: {entity.GetType()}, Handle: {entity.Handle}");
            }

            var polylines = _file.GetEntities<LwPolyline>().ToList();

            var totalLength = 0.0;
            foreach(var polyline in polylines)
            {
                totalLength += polyline.Length;
            }

            Log($"Total Polyline Length: {totalLength} m");
        }

        private static DxfFile ReadFile(string filename)
        {
            Thread.Sleep(500);
            using(var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                Environment.CurrentDirectory = @"C:\Dev\dxflibrary\artifacts\";
                return new DxfFile(stream, true);
            }
        }
    }
}
