namespace DateParser
{
    /// <summary>
    /// All three components - day, month, year
    /// </summary>
    public class DateComponents
    {
        #region Properties

        /// <summary>
        /// This number represents a current value of day component
        /// </summary>
        private int day;

        /// <summary>
        /// Public property corresponding to day component which has a check of the to-be-assigned
        /// value in the setter without validating date components' correctness as a whole
        /// </summary>
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value >= 1 && value <= SetOfDatesConstants.MaxNumOfDays)
                {
                    day = value;
                }
            }
        }

        /// <summary>
        /// This number represents a current value of month component
        /// </summary>
        private int month;

        /// <summary>
        /// Public property corresponding to month component which has a check of the to-be-assigned
        /// value in the setter. This is the final validation
        /// </summary>
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value >= 1 && value <= SetOfDatesConstants.MaxNumOfMonths)
                {
                    month = value;
                }
            }
        }

        /// <summary>
        /// Public read-only property corresponding to year component
        /// </summary>
        public int Year { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Order by which date components are assigned is important that is why
        /// DateComponent object is used to create an instance
        /// </summary>
        /// <param name="dateComponents">Array of integers containing to-be-validated dateComponents</param>
        /// <param name="dateComponentsOrder">DateComponentsOrder object holds validated data</param>
        public DateComponents(int[] dateComponents, DateComponentsOrder dateComponentsOrder)
        {
            Day = dateComponents[dateComponentsOrder.DayIndex];
            Month = dateComponents[dateComponentsOrder.MonthIndex];
            Year = dateComponents[dateComponentsOrder.YearIndex];
        }

        #endregion
    }
}
