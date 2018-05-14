namespace DateParser.Interfaces
{
    public interface IDateValidator
    {
        bool IsInMonthRange(int month);

        bool IsInDayRange(int day, int month, bool isLeapYear);

        void SetUpCorrectDate(int[] input, ref DateValidation validationResult);

        DateValidation GenerateValidationResult(string input);
    }
}
