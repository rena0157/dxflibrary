// MemoryStreamTestBase.cs
// By: Adam Renaud
// Created: 2019-04-30

using System;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests
{
    /// <summary>
    /// A Base Test class that Uses a Memory Stream to create objects as a virtual file system
    /// </summary>
    public class MemoryStreamTestBase : TestBase, IMemoryStreamTestBase
    {

        /// <summary>
        /// A Stream Writer that is used to write text to
        /// the memory stream. Note that this is not disposed of until
        /// the object is distroyed to keep the base stream alive
        /// </summary>
        private StreamWriter _streamWriter;

        /// <summary>
        /// The Binary Writer
        /// </summary>
        private BinaryWriter _binWriter;

        /// <summary>
        /// The Memory Stream that is used to hold text Data
        /// </summary>
        public MemoryStream TextMemStream { get; set; }

        /// <summary>
        /// Binary Memory stream that is used to hold binary data for the test
        /// </summary>
        public MemoryStream BinMemStream {get; set;}

        /// <summary>
        /// Default Constructor for the class
        /// </summary>
        /// <param name="logger">The logger that is passed by xUnit</param>
        public MemoryStreamTestBase(ITestOutputHelper logger) : base(logger)
        {
            TextMemStream = new MemoryStream();
            BinMemStream = new MemoryStream();
            _streamWriter = new StreamWriter(TextMemStream);
            _binWriter = new BinaryWriter(BinMemStream);
        }

        /// <summary>
        /// Dispose of the streams
        /// </summary>
        public void Dispose()
        {
            _streamWriter.Dispose();
            _binWriter.Dispose();
            BinMemStream.Dispose();
            TextMemStream.Dispose();
        }

        /// <summary>
        /// Write String data to the TextMem Stream
        /// 
        /// Note that the writer flushes and then resets the position of the memory stream to 0
        /// </summary>
        /// <param name="value">The Data that will be written</param>
        public void WriteMemory(string value)
        {
            _streamWriter.Write(value);
            _streamWriter.Flush();
            TextMemStream.Position = 0;
        }

        /// <summary>
        /// Write Binary Data to the BinMem Stream
        /// 
        /// Note that the writer then flushes and resets the position of the memory stream to 0
        /// </summary>
        /// <param name="value">The data that will be written to the stream</param>
        public void WriteMemory(byte[] value)
        {
            _binWriter.Write(value);
            _binWriter.Flush();
            BinMemStream.Position = 0;
        }
    }
}