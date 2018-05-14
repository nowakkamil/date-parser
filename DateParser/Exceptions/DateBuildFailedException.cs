using System;

namespace DateParser.Exceptions
{
    /// <summary>
    /// Thrown whenever DateBuilder failed to create a proper Date object
    /// </summary>
    public class DateBuildFailedException : Exception
    {
        public DateBuildFailedException() { }

        public DateBuildFailedException(string message) : base(message) { }

        public DateBuildFailedException(string message, Exception inner) : base(message, inner) { }
    }
}
