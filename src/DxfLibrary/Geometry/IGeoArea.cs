// IGeoArea.cs
// Created By: Adam Renaud
// Created on: 2019-01-09

using System;

namespace DxfLibrary.Geometry
{
    /// <summary>
    /// Interface that declares that a geometric entity has
    /// an Area
    /// </summary>
    public interface IGeoArea
    {
        /// <summary>
        /// Area of the Geometric Enttiy
        /// </summary>
        double Area {get;}
    }
}