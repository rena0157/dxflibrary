// DxfCommonSpec.cs
// Created By: Adam Renaud
// Created on: 2019-01-01

// System Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

// Internal Using Statements

namespace DxfLibrary.DxfSpec
{
    /// <summary>
    /// The Commmon Specification for the Dxf File Format
    /// </summary>
    /// <typeparam name="object">The type that the propery will be </typeparam>
    public class DxfCommonSpec : IDxfSpec<object>
    {
        /// <summary>
        /// The Spec Name
        /// </summary>
        public string SpecName {get;} = "DxfCommon";

        /// <summary>
        /// The type of the spec 'typeof(this)'
        /// </summary>
        public Type SpecType => typeof(DxfCommonSpec);

        /// <summary>
        /// The list of properties that this type defines
        /// </summary>
        public List<DxfSpecProperty<object>> Properties { get; set; }

        /// <summary>
        /// Gets a property by its name from the properties list
        /// </summary>
        /// <param name="name">The name of the property that is to be returned</param>
        /// <typeparam name="X">The type of the property that is to be returned</typeparam>
        /// <returns>A DxfSpecProperty casted to the type in the name</returns>
        public object GetProperty(string name) 
            => Properties
            .Where(prop => prop.Name == name)
            .FirstOrDefault()
            .Code;
    }
}