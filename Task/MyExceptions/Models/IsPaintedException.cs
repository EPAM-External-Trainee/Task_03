using System;
using Task.Enums;
using Task.MyExceptions.Interfaces;

namespace Task.MyExceptions.Models
{
    /// <summary>
    /// Class that describes an exception that occurs when you can't paint over a figure
    /// </summary>
    public class IsPaintedException : Exception, IMyException
    {
        /// <summary>
        /// Field for storing original color
        /// </summary>
        private Colors _color;

        /// <summary>
        /// Initializes a new instance of the <see cref="IsPaintedException"/> class with the specified error message and the color of the original shape
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="color">Color of original figure</param>
        public IsPaintedException(string message, Colors color)
        {
            ErrorMessage = message;
            _color = color;
        }

        /// <inheritdoc cref="Exception.Message"/>
        public new string Message => $"{ErrorMessage}. The shape already has {_color} color.";

        /// <summary>
        /// <inheritdoc cref="IMyException.ErrorMessage"/>
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}