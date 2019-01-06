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
        /// A list of properties that the specification 
        /// specifies
        /// </summary>
        List<DxfSpecProperty<T>> Properties {get; set;}

        /// <summary>
        /// Gets a property from the Properties list using the name 
        /// provided
        /// </summary>
        /// <param name="name">The name of the property that is to be retrieved</param>
        /// <typeparam name="X">The type that the property will be casted to</typeparam>
        /// <returns>A property</returns>
        T Get(string name);

    }
}