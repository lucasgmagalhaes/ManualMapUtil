using System;

namespace AppSample
{

    /// <summary>
    /// Exception to handle a map function error.
    /// </summary>
    public class MapFunctionException : Exception
    {
        public MapFunctionException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
