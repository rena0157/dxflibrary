// SpecService.cs
// By: Adam Renaud
// Created: 2019-01-01

// System Using Statements
using System;
using System.IO;

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
        /// Get a Spec from the type of spec. Specifications
        /// Area loaded form *.spec.json files and new spec objects
        /// area created that are then returned to the user.
        /// </summary>
        /// <typeparam name="T">The type of spec required</typeparam>
        /// <returns>The spec that was requested</returns>
        public static Spec<T> GetSpec<T>(string specName)
        {
            return JsonConvert
                .DeserializeObject<Spec<T>>(ReadSpecFromFile(GetStandardFileName(specName)));
        }

        public const string DxfCommonSpec = "DxfCommonSpec";

        public const string HeaderSpec = "HeaderSpec";

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