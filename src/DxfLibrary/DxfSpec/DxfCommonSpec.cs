// DxfCommonSpec.cs
// Created By: Adam Renaud
// Created on: 2019-01-01

// System Using Statements
using System;

// Internal Using Statements
using System.Collections.Generic;

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

    }
}