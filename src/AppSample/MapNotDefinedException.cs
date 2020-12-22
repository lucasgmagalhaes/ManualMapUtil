using System;

namespace AppSample
{
    /// <summary>
    /// Exception for a entity witch has no map.
    /// </summary>
    public class MapNotDefinedException : Exception
    {
        public MapNotDefinedException() : base()
        {

        }

        public MapNotDefinedException(string? message) : base(message)
        {

        }

        public MapNotDefinedException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
