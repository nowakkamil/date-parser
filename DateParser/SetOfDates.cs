using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateParser
{
    /// <summary>
    /// This class is capable of holding both of the expected dates
    /// </summary>
    public class SetOfDates
    {
        #region Properties

        /// <summary>
        /// This number represents a current number of sets already initialised
        /// </summary>
        private static int numOfDates;

        /// <summary>
        /// Public property which has a check of the to-be-assigned value in the setter
        /// </summary>
        public static int NumOfDates
        {
            get
            {
                return numOfDates;
            }
            set
            {
                if (value >= 0 && value <= SetOfDatesConstants.NumOfDatesAllowed)
                {
                    numOfDates = value;
                }
            }
        }

        /// <summary>
        /// Public property of the list of set of dates
        /// </summary>
        public List<Date> ListOfSetOfDates { get; set; }

        /// <summary>
        /// Holds true when both dates share the same year value
        /// </summary>
        public bool IsYearTheSame { get; set; }

        /// <summary>
        /// Holds true when both dates share the same month value
        /// </summary>
        public bool IsMonthTheSame { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Add a single Date object to the list
        /// </summary>
        /// <param name="date">Date object which was previously validated</param>
        public void Add(Date date)
        {
            ListOfSetOfDates.Add(date);
        }

        /// <summary>
        /// Check whether dates have the same value of both year and month
        /// </summary>
        private void PerformIdentityChecks()
        {
            int year = ListOfSetOfDates.First().DateComponents.Year;
            int month = ListOfSetOfDates.First().DateComponents.Month;

            IsYearTheSame = ListOfSetOfDates.All(date => date.DateComponents.Year == year);
            IsMonthTheSame = ListOfSetOfDates.All(date => date.DateComponents.Month == month);
        }

        /// <summary>
        /// Change order of the dates in the list when needed. Ordering will be
        /// performed by only one component of the date
        /// </summary>
        public void OrderDates()
        {
            PerformIdentityChecks();

            // Order by year when year is not the same in both of the dates
            if (!IsYearTheSame)
            {
                ListOfSetOfDates = ListOfSetOfDates.OrderBy(date => date.DateComponents.Year).ToList();
                return;
            }

            // Order by month when month is not the same in both of the dates
            if (!IsMonthTheSame)
            {
                ListOfSetOfDates = ListOfSetOfDates.OrderBy(date => date.DateComponents.Month).ToList();
                return;
            }

            // Order by day when day is not the same in both of the dates
            ListOfSetOfDates = ListOfSetOfDates.OrderBy(date => date.DateComponents.Day).ToList();
        }

        /// <summary>
        /// Display dates on a screen. There are three possibilties of data formatting.
        /// </summary>
        public void DisplayDates()
        {
            StringBuilder output = new StringBuilder();
            DisplayPermissions displayPermissions;

            if (!IsYearTheSame)
            {
                displayPermissions = DisplayPermissions.Day |
                    DisplayPermissions.Month | DisplayPermissions.Year;
                output.Append(ReturnFirstDate(displayPermissions));
                output.Append(DisplaySecondPart());
                Console.WriteLine(output);
                return;
            }

            if (!IsMonthTheSame)
            {
                displayPermissions = DisplayPermissions.Day |
                    DisplayPermissions.Month;
                output.Append(ReturnFirstDate(displayPermissions));
                output.Append(DisplaySecondPart());
                Console.WriteLine(output);
                return;
            }

            displayPermissions = DisplayPermissions.Day;
            output.Append(ReturnFirstDate(displayPermissions));
            output.Append(DisplaySecondPart());
            Console.WriteLine(output);
        }

        /// <summary>
        /// Displaying first date is the tricky part. There are three possibilties
        /// of displaying this date depending on the range between two dates
        /// </summary>
        /// <param name="displayPermissions">DisplayPermissions object holds
        /// all the necessary data to return proper string</param>
        /// <returns>Properly formatted string when DisplayPermissions object cointains
        /// correct data, empty otherwise</returns>
        private string ReturnFirstDate(DisplayPermissions displayPermissions)
        {
            if (displayPermissions == DisplayPermissions.Day)
            {
                return ListOfSetOfDates.First().DateComponentsAsStrings.Day;
            }

            if (displayPermissions == (DisplayPermissions.Day | DisplayPermissions.Month))
            {
                return ListOfSetOfDates.First().DateComponentsAsStrings.Day + "."
                    + ListOfSetOfDates.First().DateComponentsAsStrings.Month;
            }

            if (displayPermissions == (DisplayPermissions.Day
                | DisplayPermissions.Month | DisplayPermissions.Year))
            {
                return ListOfSetOfDates.First().DateComponentsAsStrings.Day + "."
                    + ListOfSetOfDates.First().DateComponentsAsStrings.Month + "."
                    + ListOfSetOfDates.First().DateComponentsAsStrings.Year;
            }

            return String.Empty;
        }

        /// <summary>
        /// Return string containing a hyphen and a second date. There is only
        /// one possibility of displaying this date. "BC" is added when the latter date is in previous era
        /// </summary>
        /// <returns>String containing a hyphen and a second date also "BC" is added when needed</returns>
        private string DisplaySecondPart()
        {
            if (ListOfSetOfDates.Last().DateComponents.Year < 0)
            {
                return " - " + ListOfSetOfDates.Last().DateComponentsAsStrings.Day + "."
                    + ListOfSetOfDates.Last().DateComponentsAsStrings.Month + "."
                    + ListOfSetOfDates.Last().DateComponentsAsStrings.Year + " BC";
            }
            else
            {
                return " - " + ListOfSetOfDates.Last().DateComponentsAsStrings.Day + "."
                    + ListOfSetOfDates.Last().DateComponentsAsStrings.Month + "."
                    + ListOfSetOfDates.Last().DateComponentsAsStrings.Year;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Assign proper value of 0 to ensure proper iteration
        /// </summary>
        static SetOfDates()
        {
            NumOfDates = 0;
        }

        /// <summary>
        /// Default constructor. Assigns empty list of Date objects
        /// </summary>
        public SetOfDates()
        {
            ListOfSetOfDates = new List<Date>();
        }

        #endregion
    }
}
