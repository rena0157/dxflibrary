// DxfBinaryReader.cs
// By: Adam Renaud
// Created: 2019-04-24

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DxfLibrary.Utilities;

namespace DxfLibrary.IO
{
    /// <summary>
    /// Dxf Binary Reader class
    /// </summary>
    /// <typeparam name="byte[]"></typeparam>
    /// <typeparam name="byte[]"></typeparam>
    public class DxfBinaryReader : IDxfReader<string, object>
    {

        #region Private Properties

        /// <summary>
        /// The Binary Reader stream
        /// </summary>
        private BinaryReader _reader;

        /// <summary>
        /// The peeks queue
        /// </summary>
        private Queue<TaggedData<string, object>> _peeks;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="stream">A base stream passed into the constructor</param>
        public DxfBinaryReader(Stream stream)
        {
            // Create the binary reader
            _reader = new BinaryReader(stream);

            // Create the Queue for peeking data
            _peeks = new Queue<TaggedData<string, object>>();

            // Read the sentenial to make sure that it is a 
            // Dxf binary file
            var sentenial = ReadNullTerminatedString();

            // If the file is not a valid file then throw an exception
            if (sentenial != "AutoCAD Binary DXF\r\n\u001a")
                throw new FileLoadException("File is not a valid Binary DxfFile");
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
        public TaggedData<string, object> GetNextPair()
        {
            // First read the group code and then get the type
            // that the value is anticipated to be.
            var groupCode = _reader.ReadInt16().ToString();
            var valueType = DxfType.FromGroupCode(groupCode);
            object value = new object();

            // Type switch dictionary, a dictionary that holds the types and 
            // coresponding actions for each type.
            var typeSwitch = new Dictionary<Type, Action> 
            {
                { typeof(string), () => value = ReadNullTerminatedString() },
                { typeof(double), () => value = _reader.ReadDouble() },
                { typeof(Int16), () => value = _reader.ReadInt16() },
                { typeof(Int32), () => value = _reader.ReadInt32() },
                { typeof(Int64), () => value = _reader.ReadInt64() },
                { typeof(bool), () => value = _reader.ReadBoolean() },

                // Reading Binary Data, the first byte is the length
                // of the data and the remaining bytes is the actual data
                { typeof(byte[]), () => {
                    var length = _reader.ReadSByte();
                    value = _reader.ReadBytes(length);
                } }
            };

            // Run the switch dictionary action
            typeSwitch[valueType]();

            // If there are any avalible data to be 
            // read in the queue read it
            if (_peeks.Count > 0)
                return _peeks.Dequeue();

            return new TaggedData<string, object>(groupCode, value);
        }

        /// <summary>
        /// Peeks the next pair of data without moving the reader's position
        /// </summary>
        /// <returns>Returns the next pair of data</returns>
        public TaggedData<string, object> PeekNextPair()
        {
            var nextPair = GetNextPair();
            _peeks.Enqueue(nextPair);
            return nextPair;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Function that Reads Null Terminated Strings from reader of bytes
        /// </summary>
        /// <returns>Returns: The string</returns>
        private string ReadNullTerminatedString()
        {
            byte currentByte = _reader.ReadByte();
            var bytes = new List<byte>();

            while(currentByte != 0 && bytes.Count < 250)
            {
                bytes.Add(currentByte);
                currentByte = _reader.ReadByte();
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        #endregion
    }
}