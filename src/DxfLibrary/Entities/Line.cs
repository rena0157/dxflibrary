// Line.cs
// Created By: Adam Renaud
// Created on: 2019-01-07

using System;
using System.Collections.Generic;

namespace DxfLibrary.Entities
{
    public class Line : Entity
    {   

        #region Constructors
        internal Line(LineStructure structure)
        {

        }

        public Line()
        {

        }
        #endregion
    }

    internal class LineStructure : Entity
    {
        public double X1 {get; set;}

        public double Y1 {get; set;}

        public double X2 {get; set;}

        public double Y2 {get; set;}

        public override void SetProperty(string name, object value)
        {
            var property = this.GetType().GetProperty(name);
            var type = property.PropertyType;
            var settingValue = Convert.ChangeType(value, type);

            this.GetType().GetProperty(name).SetValue(this, settingValue);
        }

    }
}