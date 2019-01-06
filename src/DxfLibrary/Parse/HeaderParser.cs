// HeaderParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

// System Using Statements

// Internat Using Statements
using DxfLibrary.IO;
using DxfLibrary.Parse.Sections;

namespace DxfLibrary.Parse
{
    public class HeaderParser : IDxfParser<HeaderSection, string, object>
    {
        public HeaderSection Parse(IDxfReader<string, object> reader)
        {
            var headerSection = new HeaderSection();

            while(!reader.EndOfStream)
            {
                
            }

            return headerSection;
        }
    }
}