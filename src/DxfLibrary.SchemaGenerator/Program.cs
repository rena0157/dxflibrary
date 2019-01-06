// Program.cs
// Created By: Adam Renaud
// Created On: 2019-01-01

// System Using Statements
using System;
using System.IO;

// Internal Using Statements
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

using DxfLibrary.DxfSpec;

namespace DxfLibrary.SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("The save directory is required");
                return;
            }
            
            string schemaDir = args[0];

            if (!Directory.Exists(schemaDir))
            {
                Console.WriteLine($"The directory '{schemaDir}' provided does not exist");
                return;
            }

            var generator = new JSchemaGenerator();
            var dxfspecSchema = generator.Generate(typeof(IDxfSpec<object>));
            File.WriteAllText(Path.Join(schemaDir, "IDxfSpec.schema.json"), dxfspecSchema.ToString());

        }
    }
}
