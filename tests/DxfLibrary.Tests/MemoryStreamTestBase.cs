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
    public class MemoryStreamTestBase : TestBase, IMemoryStreamTestBase
    {

        /// <summary>
        /// A Stream Writer that is used to write text to
        /// the memory stream. Note that this is not disposed of until
        /// the object is distroyed to keep the base stream alive
        /// </summary>
        private StreamWriter _streamWriter;

        private BinaryWriter _binWriter;

        private bool isBinary;

        public MemoryStream TextMemStream { get; set; }

        public MemoryStream BinMemStream {get; set;}

        public MemoryStreamTestBase(ITestOutputHelper logger) : base(logger)
        {
            TextMemStream = new MemoryStream();
            BinMemStream = new MemoryStream();

            _streamWriter = new StreamWriter(TextMemStream);
            _binWriter = new BinaryWriter(BinMemStream);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
            _binWriter.Dispose();
            BinMemStream.Dispose();
            TextMemStream.Dispose();
        }

        public void WriteMemory(string value)
        {
            _streamWriter.Write(value);
            _streamWriter.Flush();
            TextMemStream.Position = 0;
        }

        public void WriteMemory(byte[] value)
        {
            _binWriter.Write(value);
            _binWriter.Flush();
            BinMemStream.Position = 0;
        }
    }
}