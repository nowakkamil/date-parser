using System;

namespace DateParser.Exceptions
{
    /// <summary>
    /// Thrown whenever there is invalid number of date components
    /// </summary>
    public class InvalidNumOfArgsException : Exception
    {
        public InvalidNumOfArgsException() { }

        public InvalidNumOfArgsException(string message) : base(message) { }

        public InvalidNumOfArgsException(string message, Exception inner) : base(message, inner) { }
    }
}
