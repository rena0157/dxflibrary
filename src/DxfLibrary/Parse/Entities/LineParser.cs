// LineParser.cs
// Created by: Adam Renaud
// Created on: 2019-01-06

using System;
using DxfLibrary.Entities;
using DxfLibrary.IO;

namespace DxfLibrary.Parse.Entities
{
    public class LineParser : IDxfParser<Line, string, object>
    {
        public Line Parse(IDxfReader<string, object> reader)
        {
            throw new NotImplementedException();
        }
    }
}