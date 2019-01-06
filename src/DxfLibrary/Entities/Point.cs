// Point.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using DxfLibrary.IO;
using DxfLibrary.Parse;
using DxfLibrary.Parse.Sections;

namespace DxfLibrary.Entities
{
    /// <summary>
    /// The Point Entity.
    /// </summary>
    public class Point : Entity, IDxfParsable
    {

        /// <summary>
        /// Set property function
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="value">The value of the property</param>
        public override void SetProperty(string name, object value)
        {

        }
    }
}