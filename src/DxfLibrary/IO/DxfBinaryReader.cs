// DxfBinaryReader.cs
// By: Adam Renaud
// Created: 2019-04-24

using System;
using System.IO;

namespace DxfLibrary.IO
{
    /// <summary>
    /// Dxf Binary Reader class
    /// </summary>
    /// <typeparam name="byte[]"></typeparam>
    /// <typeparam name="byte[]"></typeparam>
    public class DxfBinaryReader : IDxfReader<byte[], byte[]>
    {

        #region Private Properties

        /// <summary>
        /// The Binary Reader stream
        /// </summary>
        private BinaryReader _reader;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="stream">A base stream passed into the constructor</param>
        public DxfBinaryReader(Stream stream)
        {
            _reader = new BinaryReader(stream);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The Path to the file from the base stream
        /// </summary>
        public string Path => (_reader.BaseStream as FileStream).Name;

        /// <summary>
        /// The Current Position in the stream
        /// </summary>
        public long CurrentPosition {get; protected set;}

        /// <summary>
        /// The end of the stream
        /// </summary>
        public bool EndOfStream => _reader.BaseStream.Position == _reader.BaseStream.Length;

        #endregion

        #region Public Methods

        /// <summary>
        /// Public Dispose method because this class
        /// inherits the IDisposable interface
        /// </summary>
        public void Dispose() => _reader.Dispose();

        /// <summary>
        /// Get the next pair of data from the stream
        /// </summary>
        /// <returns>Returns the data for the next pair</returns>
        public TaggedData<byte[], byte[]> GetNextPair()
        {
            return new TaggedData<byte[], byte[]>(_reader.ReadBytes(2), _reader.ReadBytes(2));
        }

        public TaggedData<byte[], byte[]> PeekNextPair()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}