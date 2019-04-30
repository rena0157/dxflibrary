// MemoryStreamTestBase.cs
// By: Adam Renaud
// Created: 2019-04-30

using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests
{
    public class MemoryStreamTestBase : TestBase, IDisposable
    {
        
        /// <summary>
        /// The memory Stream that is used to simulate a file
        /// Stream
        /// </summary>
        protected MemoryStream _memoryStream;

        /// <summary>
        /// A Stream Writer that is used to write text to
        /// the memory stream. Note that this is not disposed of until
        /// the object is distroyed to keep the base stream alive
        /// </summary>
        private StreamWriter _streamWriter;



        public MemoryStreamTestBase(ITestOutputHelper logger) : base(logger)
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}