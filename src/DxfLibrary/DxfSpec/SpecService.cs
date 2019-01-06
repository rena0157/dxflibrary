// SpecService.cs
// By: Adam Renaud
// Created: 2019-01-01

// System Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

// Internal Using Statements
using Newtonsoft.Json;

namespace DxfLibrary.DxfSpec
{
    /// <summary>
    /// SpecService reads and provides the JSON specifications
    /// as a service that can be passed to any class
    /// </summary>
    public static class SpecService
    {
        /// <summary>
        /// Collection of preloaded specs
        /// </summary>
        private static List<Spec<object>> _specs = new List<Spec<object>>();


        /// <summary>
        /// Get a Spec from the type of spec. Specifications
        /// Area loaded form *.spec.json files and new spec objects
        /// area created that are then returned to the user.
        /// </summary>
        /// <typeparam name="T">The type of spec required</typeparam>
        /// <returns>The spec that was requested</returns>
        public static Spec<T> GetSpec<T>(string specName)
        {
            // First see if the spec is in the collection
            if (_specs.Count > 0)
            {
                // Search the collection
                var result = _specs.Where(s => s.SpecName == specName).FirstOrDefault();

                if (result != null)
                    return result as Spec<T>;
            }

            // Get the spec from the file
            var spec =  JsonConvert
                .DeserializeObject<Spec<T>>(ReadSpecFromFile(GetStandardFileName(specName)));

            // Add the spec to the collection
            _specs.Add(spec as Spec<object>);

            return spec;
        }

        public const string DxfCommonSpec = "DxfCommonSpec";

        public const string HeaderSpec = "HeaderSpec";

        public const string EntitySpec = "EntitySpec";
        

        /// <summary>
        /// Return the standard file name for the type
        /// </summary>
        /// <param name="specType">The spec type</param>
        /// <returns>A relative path to the type spec</returns>
        private static string GetStandardFileName(string specName)
        {
            return $"./DxfSpec/Specs/{specName}.json";
        }

        /// <summary>
        /// Read a file from the file system
        /// </summary>
        /// <param name="path">The path to the file</param>
        /// <returns>The contents of the file</returns>
        private static string ReadSpecFromFile(string path)
        {
            // If the file is not found then throw an execption
            if (!File.Exists(path))
                throw new FileNotFoundException();
            
            return File.ReadAllText(path);
        }

    }
}