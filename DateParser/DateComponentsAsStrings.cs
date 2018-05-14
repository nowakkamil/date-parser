using System;

namespace DateParser
{
    /// <summary>
    /// DateComponents converted to a string
    /// </summary>
    public class DateComponentsAsStrings
    {
        #region Read-only Properties

        public string Day { get; }

        public string Month { get; }

        public string Year { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructs an object by first converting date components to strings
        /// and then assigning result to properties
        /// </summary>
        /// <param name="dateComponents">DateComponents as integers</param>
        public DateComponentsAsStrings(DateComponents dateComponents)
        {
            Day = String.Format("{0:00}", dateComponents.Day);
            Month = String.Format("{0:00}", dateComponents.Month);
            Year = String.Format("{0:####;0:####;0000}", dateComponents.Year);
        }

        #endregion
    }
}
