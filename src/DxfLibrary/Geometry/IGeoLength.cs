// IGeoLength.cs
// Created By: Adam Renaud
// Created On: 2019-01-09

using System;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// IGeoLength declares that a geometric entity has a length
    /// </summary>
    public interface IGeoLength
    {
        /// <summary>
        /// Length of the entity
        /// </summary>
        double Length {get;}
    }
}