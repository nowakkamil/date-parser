using System;

namespace DateParser.Exceptions
{
    /// <summary>
    /// Thrown whenever there is a duplicate index inside of DateComponentsOrder object
    /// </summary>
    public class DateComponentsOrderDuplicationException : Exception
    {
        public DateComponentsOrderDuplicationException() { }

        public DateComponentsOrderDuplicationException(string message) : base(message) { }

        public DateComponentsOrderDuplicationException(string message, Exception inner) : base(message, inner) { }
    }
}
