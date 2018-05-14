using DateParser.Exceptions;
using DateParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DateParser
{
    /// <summary>
    /// Incorporates all the validation needed for Date object creation in terms of Gregorian Calendar format
    /// </summary>
    public class GregorianDateValidator : IDateValidator
    {
        #region Private Properties

        /// <summary>
        /// Temporary DateComponents object which is used to test logic
        /// </summary>
        private DateComponents dateComponents;

        /// <summary>
        /// Temporary DateComponentsOrder object which is used to test logic
        /// </summary>
        private DateComponentsOrder dateComponentsOrder;

        #endregion

        #region Methods

        /// <summary>
        /// Validate month range for a currently tested date components' order
        /// </summary>
        /// <param name="month">Month component which is part of the currently tested
        /// date components' order</param>
        /// <returns>True when month component is valid in currently tested date
        /// components' order, false otherwise</returns>
        public bool IsInMonthRange(int month)
        {
            if (month < 1 || month > SetOfDatesConstants.MaxNumOfMonths)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate day range for a currently tested date components' order. Takes
        /// into account both month and leap year data provided
        /// </summary>
        /// <param name="day">Day component which is part of the currently tested date components' order</param>
        /// <param name="month">Month component which is part of the currently tested date components' order</param>
        /// <param name="isLeapYear">Boolean value to indicate whether the year of the currently
        /// tested date components' order is the leap year</param>
        /// <returns>True when day component is valid in currently tested date components' order,
        /// false otherwise</returns>
        public bool IsInDayRange(int day, int month, bool isLeapYear)
        {
            // Calculate maximum number of days in a specific month based on month and leap year data provided
            int maxNumOfDays;

            if (month == 2)
            {
                maxNumOfDays = (isLeapYear) ? SetOfDatesConstants.LeapYearNumOfDays :
                    SetOfDatesConstants.MinNumOfDays;
            }
            else if (month % 2 != 0)
            {
                maxNumOfDays = SetOfDatesConstants.MaxNumOfDays - 1;
            }
            else
            {
                maxNumOfDays = SetOfDatesConstants.MaxNumOfDays;
            }

            if (day < 1 || day > maxNumOfDays)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Test every possible combination of date components' order
        /// </summary>
        /// <param name="input"></param>
        /// <param name="validationResult"></param>
        /// <returns>True when a proper combination is found, false if any possible date
        /// components order combinatios</returns>
        public void SetUpCorrectDate(int[] input, ref DateValidation validationResult)
        {
            // Auxiliary data structure used to generate permutations
            IEnumerable<int> increasingOrderIndices = new List<int>()
            {
                0, 1, 2
            };

            // Auxiliary data structure holding any possible permutation
            IEnumerable<IEnumerable<int>> twoDimensionalIndices =
                DateComponentsOrder.GetPermutations(increasingOrderIndices,
                increasingOrderIndices.Count());

            // Two dimensional array of integers used for the following calculations
            int[][] arrayOfPermutatedIndices =
                twoDimensionalIndices.Select(i => i.ToArray()).ToArray();
            bool isLeapYear;

            // Test any possible permutation
            for (int index = 0; index < arrayOfPermutatedIndices.Count(); ++index)
            {
                // Assemble temporary object
                dateComponentsOrder = new DateComponentsOrder(arrayOfPermutatedIndices[index]);
                dateComponents = new DateComponents(input, dateComponentsOrder);
                isLeapYear = IsLeapYear(dateComponents.Year);

                // When data order is valid the results will be passed to DateBuilder with validation indicator
                if (IsDateValid(isLeapYear))
                {
                    validationResult.DateComponents = dateComponents;
                    validationResult.IsValid = true;
                    return;
                }
            }

            // Any of the permutations does not meet the assumptions. Exception will be thrown in DateBuilder
            validationResult.IsValid = false;
        }

        /// <summary>
        /// This method is responsible for returning a result of the validation
        /// </summary>
        /// <param name="input"></param>
        /// <returns>It is worth mentioning that DateValidation object will contain null reference
        /// to DateComponents property so it is of DateBuilder responsibility to take care of that
        /// by checking IsValid property</returns>
        public DateValidation GenerateValidationResult(string input)
        {
            // Initialise array of integers using values from splitted input into array of strings
            string[] splittedInput = SplitInput(input);
            int[] arrayOfDateComponents = new int[SetOfDatesConstants.NumOfDateComponents];

            // Exception will be thrown whenever input is not valid in terms of numeric values
            arrayOfDateComponents = splittedInput.Select(int.Parse).ToArray();

            // Assemble temporary object
            DateValidation validationResult = new DateValidation();

            // DateValidation object will be passed to DateBuilder regardless of validation result. Additionally,
            // exception will be thrown in DateBuilder when any of the permutations does not meet the assumptions
            SetUpCorrectDate(arrayOfDateComponents, ref validationResult);
            return validationResult;
        }

        /// <summary>
        /// Perform leap year check based on Gregorian Calendar format. Ordering inside if statement is crucial
        /// </summary>
        /// <param name="year">Currently tested date's year component</param>
        /// <returns>True when year is leap, false otherwise</returns>
        public bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Perform range checks regarding Gregorian Calendar Date Format
        /// </summary>
        /// <param name="isLeapYear">True when year is leap, false otherwise</param>
        /// <returns>True when date is valid regarding Gregorian Calendar Date Format, false otherwise</returns>
        private bool IsDateValid(bool isLeapYear)
        {
            if (!IsInMonthRange(dateComponents.Month)
                || !IsInDayRange(dateComponents.Day, dateComponents.Month, isLeapYear))
            {
                return false;
            }

            return true;
        }

        private string[] SplitInput(string input)
        {
            // Use delimiter characters specified in SetOfDatesConstants class.
            // Different delimiters in a single date input are allowed
            string[] splittedString = input.Split(SetOfDatesConstants.DelimiterChars,
                StringSplitOptions.RemoveEmptyEntries);

            ValidateSplittedStringLength(splittedString.Length);

            return splittedString;
        }

        private void ValidateSplittedStringLength(int length)
        {
            try
            {
                if (length != SetOfDatesConstants.NumOfDateComponents)
                {
                    throw new InvalidNumOfDateComponentsException($"The number of Date Components " +
                        $"should be equal to {SetOfDatesConstants.NumOfDateComponents}.");
                }
            }
            catch (InvalidNumOfDateComponentsException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Terminating program.");
                Environment.Exit(ExitCodes.InvalidNumOfDateComponentsExitCode);
            }
        }

        #endregion
    }
}
