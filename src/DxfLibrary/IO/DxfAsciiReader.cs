// DxfAsciiReader.cs
// By: Adam Renaud
// Created: 2019-01-01

using System;
using System.IO;
using System.Collections.Generic;

namespace DxfLibrary.IO
{
    /// <summary>
    /// Reader for ASCII dxf files. Note that this class implements
    /// the IDisposable and IDxfReader interfaces
    /// </summary>
    public class DxfAsciiReader : IDxfReader<string, object>
    {
        #region Private Properties

        /// <summary>
        /// This is the base reader stream that will be used in the Ascii Reader
        /// </summary>
        private StreamReader _reader;

        /// <summary>
        /// The peek queue
        /// </summary>
        private Queue<TaggedData<string, object>> _peeks;

        #endregion

        public DxfAsciiReader(Stream stream)
        {
            _reader = new StreamReader(stream);
            _peeks = new Queue<TaggedData<string, object>>();
        }

        #region Public Properties

        /// <summary>
        /// The Path to the file that is being read
        /// </summary>
        public string Path => (_reader.BaseStream as FileStream).Name;

        /// <summary>
        /// The Current Position in the file. This is the current line that is to be read.
        /// </summary>
        public long CurrentPosition {get; protected set;} = 0;

        /// <summary>
        /// Returns true if the end of the stream has been reached
        /// </summary>
        public bool EndOfStream => _reader.EndOfStream;

        #endregion

        #region Public Methods

        /// <summary>
        /// Disposes of managed and unmanaged resources including
        /// the Stream that is used in this class
        /// </summary>
        public void Dispose()
        {
            _reader.Dispose();
        }

        /// <summary>
        /// Increments that Current position by two then 
        /// creates a new <see cref="TaggedData{G, V}"> object reading the group
        /// Code and value into the new object
        /// </summary>
        /// <returns>The created Tagged Data</returns>
        public TaggedData<string, object> GetNextPair()
        {
            // if there is something in the queue then
            // dequeue it
            if (_peeks.Count > 0)
                return _peeks.Dequeue();

            CurrentPosition += 2;
            return new TaggedData<string, object>(_reader.ReadLine(), _reader.ReadLine());
        }

        /// <summary>
        /// Peak the next pair without reading the value of it
        /// </summary>
        public TaggedData<string, object> PeekNextPair()
        {
            var nextPair = new TaggedData<string, object>(_reader.ReadLine(), _reader.ReadLine());
            _peeks.Enqueue(nextPair);
            return nextPair;
        }

        #endregion
    }
}