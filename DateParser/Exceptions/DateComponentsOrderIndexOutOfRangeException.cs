using System;

namespace DateParser.Exceptions
{
    /// <summary>
    /// Thrown whenever index is out of range
    /// </summary>
    public class DateComponentsOrderIndexOutOfRangeException : Exception
    {
        public DateComponentsOrderIndexOutOfRangeException() { }

        public DateComponentsOrderIndexOutOfRangeException(string message) : base(message) { }

        public DateComponentsOrderIndexOutOfRangeException(string message, Exception inner) : base(message, inner) { }
    }
}
