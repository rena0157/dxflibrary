// SpecBase.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

// System Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

// Internal Using Statements

namespace DxfLibrary.DxfSpec
{
    /// <summary>
    /// Spec base class that implements the basic common functions of the DxfSpec
    /// </summary>
    /// <typeparam name="T">The type of the DxfSpecProperty</typeparam>
    public class SpecBase<T>
    {
        /// <summary>
        /// The Properties list that containes all of the properties relating to 
        /// this specificaiton
        /// </summary>
        public List<DxfSpecProperty<T>> Properties { get; set; }

        /// <summary>
        /// Gets a property by its name from the properties list
        /// </summary>
        /// <param name="name">The name of the property that is to be returned</param>
        /// <typeparam name="X">The type of the property that is to be returned</typeparam>
        /// <returns>A DxfSpecProperty casted to the type in the name</returns>
        public virtual T GetProperty(string name) 
            => Properties
            .Where(prop => prop.Name == name)
            .FirstOrDefault()
            .Code;
    }
}