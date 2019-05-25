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
    public class MemoryStreamTestBase<T> : TestBase, IMemoryStreamTestBase<T>
    {

        /// <summary>
        /// A Stream Writer that is used to write text to
        /// the memory stream. Note that this is not disposed of until
        /// the object is distroyed to keep the base stream alive
        /// </summary>
        private StreamWriter _streamWriter;

        private BinaryWriter _binWriter;

        private bool isBinary;

        public MemoryStream MemStream { get; set; }

        public MemoryStreamTestBase(ITestOutputHelper logger) : base(logger)
        {
            MemStream = new MemoryStream();

            if (typeof(T) == typeof(string))
            {
                isBinary = false;
                _streamWriter = new StreamWriter(MemStream);
            }
            else if (typeof(T) == typeof(byte[]))
            {
                isBinary = true;
                _binWriter = new BinaryWriter(MemStream);
            }
            else
                throw new NotSupportedException("The Type Provided is not supported");
        }


        public void Dispose()
        {
            if(!isBinary)
                _streamWriter.Dispose();

            else
                _binWriter.Dispose();
            
            MemStream.Dispose();
        }

        public void WriteMemory(object value)
        {
            if (!isBinary)
            {
                _streamWriter.Write((string)value);
                _streamWriter.Flush();
            }
            else
            {
                _binWriter.Write((byte[])value);
                _binWriter.Flush();
            }

            MemStream.Position = 0;
        }
    }
}