// DxfSpecProperty.cs
// Created By: Adam Renaud
// Created On: 2019-01-01

// System Using Statements

// Internal Using Statements

namespace DxfLibrary.DxfSpec
{
    /// <summary>
    /// A spec property is the lowest level in the specifications
    /// namespace. It is the encapsulation of a group code and
    /// the name of the code or the data that it represents.
    /// </summary>
    /// <typeparam name="T">The type that the code is</typeparam>
    public class DxfSpecProperty<T>
    {
        /// <summary>
        /// The property name that the code defines
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        /// The Code that defines the data. This code is effectively
        /// the group code in the dxf format.
        /// </summary>
        /// <remarks>
        /// Note that the type of the code is generic. In Ascii Files 
        /// the type will typically be a string and in binary files it 
        /// will typically be a byte.
        /// </remarks>
        public T Code {get; set;}
    }
}