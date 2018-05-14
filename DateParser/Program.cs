using DateParser.Exceptions;
using System;

namespace DateParser
{
    class Program
    {
        public static void IsNumOfArgsValid(string[] args)
        {
            try
            {
                if (args.Length <= 1 || args.Length > SetOfDatesConstants.NumOfDatesAllowed)
                {
                    throw new InvalidNumOfArgsException($"The Number of passed arguments " +
                        $"should be equal to {SetOfDatesConstants.NumOfDatesAllowed}.");
                }
            }
            catch (InvalidNumOfArgsException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Terminating program.");
                Environment.Exit(ExitCodes.InvalidNumOfArgsExitCode);
            }
        }

        public static void Main(string[] args)
        {
            IsNumOfArgsValid(args);

            DateManager dateManager = new DateManager(args);
        }
    }
}
