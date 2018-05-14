using System;

namespace DateParser.Exceptions
{
    /// <summary>
    /// Thrown whenever there is invalid number of input arguments
    /// </summary>
    public class InvalidNumOfDateComponentsException : Exception
    {
        public InvalidNumOfDateComponentsException() { }

        public InvalidNumOfDateComponentsException(string message) : base(message) { }

        public InvalidNumOfDateComponentsException(string message, Exception inner) : base(message, inner) { }
    }
}
