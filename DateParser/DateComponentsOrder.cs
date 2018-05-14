using DateParser.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateParser
{
    /// <summary>
    /// Contains all necessary data about order of date components. Used for validation purposes
    /// </summary>
    public class DateComponentsOrder
    {
        #region Read-only Properties

        public int DayIndex { get; }

        public int MonthIndex { get; }

        public int YearIndex { get; }

        #endregion

        #region Methods

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        /// <summary>
        /// Perform validation
        /// </summary>
        /// <param name="indices"></param>
        private void ValidateIndices(int[] indices)
        {
            PerformRangeChecks(indices);
            PerformIdentityChecks(indices);
        }

        /// <summary>
        /// Check if index is out of range
        /// </summary>
        /// <param name="indices">Each index must be of different value</param>
        private void PerformRangeChecks(int[] indices)
        {
            try
            {
                for (int index = 0; index < indices.Length; ++index)
                {
                    if (indices[index] < 0 || indices[index] > SetOfDatesConstants.NumOfDateComponents)
                    {
                        throw new DateComponentsOrderIndexOutOfRangeException();
                    }
                }
            }
            catch (DateComponentsOrderIndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Terminating program.");
                Environment.Exit(ExitCodes.DateComponentsOrderIndexOutOfRangeExitCode);
            }
        }

        /// <summary>
        /// Check if there are duplicates among date components
        /// </summary>
        /// <param name="indices">Each index must be of different value</param>
        private void PerformIdentityChecks(int[] indices)
        {
            int auxiliaryIndex = 0;

            try
            {
                // If there were more than three components, generic approach would be more suitable.
                // Proper LINQ usage on a newly-created data structure would be advised in that case
                if (indices[auxiliaryIndex] == indices[auxiliaryIndex + 1]
                    || indices[auxiliaryIndex] == indices[auxiliaryIndex + 2]
                    || indices[auxiliaryIndex + 1] == indices[auxiliaryIndex + 2])
                {
                    throw new DateComponentsOrderDuplicationException();
                }
            }
            catch (DateComponentsOrderDuplicationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Terminating program.");
                Environment.Exit(ExitCodes.DateComponentsOrderDuplicationExitCode);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default format - DD/MM/YYYY is used
        /// </summary>
        public DateComponentsOrder()
        {
            DayIndex = SetOfDatesConstants.DefaultDateFormatDayIndex;
            MonthIndex = SetOfDatesConstants.DefaultDateFormatMonthIndex;
            YearIndex = SetOfDatesConstants.DefaultDateFormatYearIndex;
        }

        /// <summary>
        /// Custom format. Usage with GetPermutations() is advised. Throws an exception
        /// whenever a duplicate is found
        /// </summary>
        /// <param name="indices">Each index must be of different value</param>
        public DateComponentsOrder(int[] indices)
        {
            ValidateIndices(indices);

            int auxiliaryIndex = 0;
            DayIndex = indices[auxiliaryIndex];
            MonthIndex = indices[++auxiliaryIndex];
            YearIndex = indices[++auxiliaryIndex];
        }

        #endregion
    }
}
