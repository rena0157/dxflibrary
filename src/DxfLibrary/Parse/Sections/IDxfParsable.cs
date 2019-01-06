// IDxfParsable.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;

namespace DxfLibrary.Parse.Sections
{
    /// <summary>
    /// Interface for Dxf sections
    /// </summary>
    public interface IDxfParsable
    {
        /// <summary>
        /// Set a property of the class
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        void SetProperty(string name, object value);
    }
}