// DxfReaderService.cs
// Created: 2019-04-24
// By: Adam Renaud

using System;

namespace DxfLibrary.IO
{
    /// <summary>
    /// Service that contains the reader for the dxffile
    /// </summary>
    public static class DxfReaderService
    {
        /// <summary>
        /// The dxf reader for the current file that is being read
        /// </summary>
        private static IDxfReader<string, object> AsciiReader {get; set;}

        /// <summary>
        /// The Binary reader
        /// </summary>
        private static IDxfReader<byte, object> BinaryReader {get; set;}

    }
}