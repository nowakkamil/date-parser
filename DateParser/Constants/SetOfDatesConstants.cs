namespace DateParser
{
    /// <summary>
    /// Set of constants used through the program
    /// </summary>
    public static class SetOfDatesConstants
    {
        /// <summary>
        /// Number of dates allowed according to the assumptions
        /// </summary>
        public const int NumOfDatesAllowed = 2;

        /// <summary>
        /// Number of date components allowed according to the assumptions
        /// </summary>
        public const int NumOfDateComponents = 3;

        /// <summary>
        /// This is the number of days in February in every year but leap year
        /// </summary>
        public const int MinNumOfDays = 28;

        /// <summary>
        /// This is the number of days in February in leap year
        /// </summary>
        public const int LeapYearNumOfDays = 29;

        /// <summary>
        /// Maximum number of days in any given month
        /// </summary>
        public const int MaxNumOfDays = 31;

        /// <summary>
        /// Maximum number of months in a Gregorian Calendar
        /// </summary>
        public const int MaxNumOfMonths = 12;

        /// <summary>
        /// DD/MM/YYYY format
        /// </summary>
        public const int DefaultDateFormatDayIndex = 0;

        /// <summary>
        /// DD/MM/YYYY format
        /// </summary>
        public const int DefaultDateFormatMonthIndex = 1;

        /// <summary>
        /// DD/MM/YYYY format
        /// </summary>
        public const int DefaultDateFormatYearIndex = 2;

        /// <summary>
        /// Delimiter characters allowed to separate components of date in the input
        /// </summary>
        public static readonly char[] DelimiterChars = { '.', ',', ':', '_', '/', '|', '\\', '\t' };
    }
}
