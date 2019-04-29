// DxfType.cs
// By: Adam Renaud
// Created: 2019-04-29

using System;

namespace DxfLibrary.Utilities
{
    /// <summary>
    /// Basic utility class for holding functions relating to all dxf types
    /// </summary>
    public static class DxfType
    {
        /// <summary>
        /// Return the expect type given a group code. This is the same function
        /// as with an int but it will parse the int before passing it to the function.
        /// </summary>
        /// <param name="code">The group code</param>
        /// <returns>Returns: A type that corresponds with the group code</returns>
        public static Type FromGroupCode(string code)
        {
            // Holding var for the parsed int
            int parsedInt;

            // Try and parse the int, if not then throw an execption
            if (int.TryParse(code, out parsedInt))
                return FromGroupCode(parsedInt);
            else
                throw new ArgumentException("Argument must be a parseable int");
        }

        /// <summary>
        /// Return the expected type given a group code 
        /// </summary>
        /// <param name="code">The Group Code</param>
        /// <returns>Returns: A type</returns>
        public static Type FromGroupCode(int code)
        {

            switch (code)
            {
                // All of the string cases
                case int n when 
                (
                    (n < 10) || 
                    (n == 100) || 
                    (n == 105) ||
                    (n >= 300 && n < 370) ||
                    (n >= 390 && n < 400) ||
                    (n >=410 && n < 420) ||
                    (n >= 430 && n < 440) || 
                    (n >= 470 && n <= 481) || 
                    (n == 999) ||
                    (n >= 1000 && n < 1010)
                ):
                return typeof(string);

                // all of the double cases
                case int n when 
                (
                    (n >= 10 && n < 40) ||
                    (n >= 40 && n < 60) ||
                    (n >= 100 && n < 160) ||
                    (n >= 210 && n <= 239) ||
                    (n >= 460 && n < 470) ||
                    (n >= 1010 && n < 1060)
                ):
                return typeof(double);

                // all of the int16 cases
                case int n when 
                (
                    (n >= 60 && n < 80) ||
                    (n >= 170 && n <= 179) ||
                    (n >= 270 && n < 290) ||
                    (n >= 370 && n < 390) ||
                    (n >= 400 && n < 410) ||
                    (n >= 1060 && n <= 1070)
                ):
                return typeof(Int16);

                // Int32
                case int n when 
                (
                    (n >= 80 && n < 100) ||
                    (n >= 420 && n < 430) || 
                    (n >= 440 && n < 450) ||
                    (n == 1071)
                ):
                return typeof(Int32);

                // Int64
                case int n when 
                (
                    (n >= 160 && n < 170) ||
                    (n >= 450 && n < 460)
                ):
                return typeof(Int64);

                // Bool
                case int n when (n >= 290 && n < 300):
                    return typeof(bool);

                // The default case will throw an exception becuase the type
                // could not be matched
                default:
                    throw new ArgumentException("Argument does not match any predefined group code type");   
            }

        }
    }
}