// Program.cs
// Created By: Adam Renaud
// Created On: 2019-01-01

// System Using Statements
using System;
using System.IO;

// Internal Using Statements
using Newtonsoft.Json.Schema;
using DxfLibrary.DxfSpec;

namespace DxfLibrary.SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new JsonSchemaGenerator();

            var test = generator.Generate(typeof(IDxfSpec<object>));
        }
    }
}
