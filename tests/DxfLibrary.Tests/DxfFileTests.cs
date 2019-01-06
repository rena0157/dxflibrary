// DxfFileTest.cs
// Created by: Adam Renaud
// Created on: 2019-01-05

// System using statements
using System;
using System.IO;

// Internal Using Statements
using Xunit;
using Xunit.Abstractions;
using DxfLibrary;


namespace DxfLibrary.Tests
{
    /// <summary>
    /// The Testing class for the <see cref="DxfFile"> class
    /// </summary>
    public class DxfFileTests : TestBase
    {
        public DxfFileTests(ITestOutputHelper logger) : base(logger)
        {
        }

        [Fact]
        public void ReadFile()
        {
            using (FileStream fileStream = new FileStream(@"C:\Dev\drawing1.dxf", FileMode.Open))
            {
                DxfFile dxfFile = new DxfFile(fileStream);
            }
        }
    }
}