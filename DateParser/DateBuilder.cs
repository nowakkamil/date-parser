using DateParser.Exceptions;
using DateParser.Interfaces;

namespace DateParser
{
    /// <summary>
    /// Builds a proper Date object by first validating the input
    /// </summary>
    public class DateBuilder
    {
        /// <summary>
        /// Validator object which incorporates an appropriate logic needed
        /// for date object creation
        /// </summary>
        IDateValidator validator;

        /// <summary>
        /// Constructor which works with objects implementing IDateValidator interface
        /// </summary>
        /// <param name="validator">IDateValidator object</param>
        public DateBuilder(IDateValidator validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Method which creates the date object only with valid data
        /// </summary>
        /// <param name="input">Input used in date object creation</param>
        /// <returns>Date object after positively passing validation,
        /// exception will be thrown otherwise</returns>
        public Date Build(string input)
        {
            DateValidation validationResult = new DateValidation();
            validationResult = validator.GenerateValidationResult(input);

            if (validationResult.IsValid)
            {
                return new Date(validationResult.DateComponents);
            }
            else
            {
                throw new DateBuildFailedException("DateBuilder could not " +
                    "create an object. Terminating program.");
            }
        }
    }
}
