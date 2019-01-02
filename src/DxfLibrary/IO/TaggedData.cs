// TaggedData.cs
// By: Adam Renaud
// Created: 2019-01-01

using System;
using System.IO;

namespace DxfLibrary.IO
{
    /// <summary>
    /// Tagged Data represents data that is tagged with an identifer or 
    /// group code. This is used with the Dxf File format as there is always
    /// a identifying code before a piece of data.
    /// </summary>
    /// <typeparam name="G">Type of the group code</typeparam>
    /// <typeparam name="V">Type of the value</typeparam>
    public class TaggedData<G, V>
    {
        #region Public Properties
        /// <summary>
        /// The Group Code is the tag part of the data. Using a specification
        /// it identifies the purpose and type of the data that follows it.
        /// </summary>
        public G GroupCode {get;}

        /// <summary>
        /// The value, note that the value type V is the type that is read from the file
        /// and for Ascii Files this should be a string. For Binary files this should be a
        /// byte[]. Use the <see cref="GetValue{T}"> function to cast this to a suitabe type T.
        /// </summary>
        public V Value {get;}

        #endregion

        #region Constructors

        /// <summary>
        /// The default Constructor that sets the public properties
        /// </summary>
        /// <param name="groupCode">The group Code</param>
        /// <param name="value">The value</param>
        public TaggedData(G groupCode, V value)
        {
            GroupCode = groupCode;
            Value = value;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The <see cref="Value"> casted to the type <typeparam name="T">.
        /// </summary>
        /// <typeparam name="T">The type that the value will be casted to</typeparam>
        /// <returns>The value casted to the type T</returns>
        public T GetValue<T>()
        {
            try
            {
                return (T)Convert.ChangeType(Value, typeof(T));
            }
            catch(FormatException)
            {
                return default(T);
            }
        }

        #endregion
    }
}