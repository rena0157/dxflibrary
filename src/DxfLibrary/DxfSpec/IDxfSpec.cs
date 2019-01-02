// IDxfSpec.cs
// Created By: Adam Renaud
// Created on: 2019-01-01

// System Using Statements
using System;
using System.Collections.Generic;

// Internal Using Statements

namespace DxfLibrary.DxfSpec
{
    /// <summary>
    /// And interface that defines the members for the 
    /// IDxfSpec type. This type is the interface between
    /// *.spec.json files and the application code.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the SpecProperty. This is usually just object however it was chosen to 
    /// be a generic type because of the option that it might not always be benifitial to be 
    /// just an object.
    /// </typeparam>
    public interface IDxfSpec<T>
    {
        /// <summary>
        /// The name of the specification
        /// </summary>
        string SpecName {get;}

        /// <summary>
        /// The type of the specification
        /// </summary>
        Type SpecType {get;}

        /// <summary>
        /// A list of properties that the specification 
        /// specifies
        /// </summary>
        List<DxfSpecProperty<T>> Properties {get; set;}

    }
}