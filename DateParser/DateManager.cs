namespace DateParser
{
    /// <summary>
    /// Contains all of the logic specified in a task description
    /// </summary>
    public class DateManager
    {
        public DateManager(string[] input)
        {
            SetOfDates setOfDates = new SetOfDates();
            DateBuilder dateBuilder = new DateBuilder(new GregorianDateValidator());
            Date date;

            for (int index = 0; index < SetOfDatesConstants.NumOfDatesAllowed; ++index)
            {
                date = dateBuilder.Build(input[index]);
                setOfDates.Add(date);
            }

            setOfDates.OrderDates();
            setOfDates.DisplayDates();
        }
    }
}

