// IVectorable.cs
// By: Adam Renaud
// Created on: 2019-01-15

using System;

namespace DxfLibrary.GeoMath
{
    /// <summary>
    /// Interface that declares that an object can be converted to a vector.
    /// </summary>
    public interface IVectorable
    {
        /// <summary>
        /// Convert an object to a vector
        /// </summary>
        /// <returns>A new vector that is created from the object that called the function</returns>
        Vector ToVector();
    }

}