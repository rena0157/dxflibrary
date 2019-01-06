// HeaderParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

// System Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

// Internat Using Statements
using DxfLibrary.IO;
using DxfLibrary.Parse.Sections;
using DxfLibrary.DxfSpec;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DxfLibrary.Parse
{
    /// <summary>
    /// Class that contains the functions to parse the header 
    /// section and uses the header spec definition to create a header section
    /// using the parse function
    /// </summary>
    public class HeaderParser : IDxfParser<HeaderSection, string, object>
    {
        /// <summary>
        /// Main parsing function that uses the Header spec file to 
        /// fill out the header section class properties
        /// </summary>
        /// <param name="reader">The dxf reader that is passed to this class</param>
        /// <returns>A new header section</returns>
        public HeaderSection Parse(IDxfReader<string, object> reader)
        {
            // Set up variables
            var headerSection = new HeaderSection();
            var headerSectionProperties = headerSection.GetType().GetProperties();

            // Get the relavent specs
            var headerSpec = SpecService.GetSpec<object>(SpecService.HeaderSpec);
            var commonSpec = SpecService.GetSpec<object>(SpecService.DxfCommonSpec);

            // This is end section string
            var endSectionString = commonSpec.Get("Sections.EndString") as string;

            // Read throughout the stream
            while(!reader.EndOfStream)
            {
                // Read data from the stream
                var firstPair = reader.GetNextPair();

                // If we reach the end of this section break out of the loop
                if (firstPair.Value as string == endSectionString)
                    break;
                
                // read a second pair of data to get values
                var secondPair = reader.GetNextPair();

                // Find a property that matches the current specification
                var property = headerSectionProperties
                    .Where(prop => headerSpec.Properties
                    .Any(spec => prop.Name == spec.Name && spec.Code as string == firstPair.Value as string)).FirstOrDefault();

                // If a property is found then set the property to the value
                if (property != null)
                    headerSection.SetProperty(property.Name, secondPair.Value);
            }

            return headerSection;
        }
    }
}