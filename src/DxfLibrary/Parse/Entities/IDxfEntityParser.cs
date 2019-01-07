// IDxfEntityParser.cs
// Created by: Adam Renaud
// Created on: 2018-01-07

using System;
using System.Collections.Generic;
using System.Linq;
using DxfLibrary.DxfSpec;
using DxfLibrary.Entities;
using DxfLibrary.IO;

namespace DxfLibrary.Parse.Entities
{
    /// <summary>
    /// Interface that declares an EntityParser
    /// </summary>
    /// <typeparam name="T">Type of the Entity</typeparam>
    /// <typeparam name="G">Type of the Group Code (Usually string)</typeparam>
    /// <typeparam name="V">Type of the value (TaggedData, usually object)</typeparam>
    /// <typeparam name="S">Type of the specification (Usually Object)</typeparam>
    public interface IDxfEntityParser<T, G, V, S>
    {
        /// <summary>
        /// Parse any non base class entity
        /// </summary>
        /// <param name="entity">The entity that is to be parsed</param>
        /// <param name="reader">The reader for the data in the file</param>
        /// <param name="entitySpec">The specificaiton that the parser will need</param>
        /// <returns>A new Entity</returns>
        T ParseEntity(IEntity entity, IDxfReader<G, V> reader, IDxfSpec<S> entitySpec);


        /// <summary>
        /// Parses the base class entity
        /// </summary>
        /// <param name="entity">The entity that will be parsed</param>
        /// <param name="data">Reader to where the data is</param>
        /// <param name="entitySpec">The entity Specification</param>
        bool BaseParse(IEntity entity, TaggedData<G, V> data, IDxfSpec<S> entitySpec);

    }


}