using System;
using Task.Figures.Interfaces;
using Task.MyExceptions.Interfaces;

namespace Task.MyExceptions.Models
{
    /// <summary>
    /// Class that describes an exception that occurs when it's not possible to cut one figure from another
    /// </summary>
    public class OutOfAreaException : Exception, IMyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutOfAreaException"/> class with the specified error message, original and cut out figure
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="originalFigure">Original figure</param>
        /// <param name="cutOutFigure">Cut out figure</param>
        public OutOfAreaException(string message, IFigure originalFigure, IFigure cutOutFigure)
        {
            OriginalFigure = originalFigure;
            CutOutFigure = cutOutFigure;
            ErrorMessage = message;
        }

        /// <summary>
        /// Field for storing original figure
        /// </summary>
        public IFigure OriginalFigure { get; private set; }

        /// <summary>
        /// Field for storing cut out figure
        /// </summary>
        public IFigure CutOutFigure { get; private set; }

        /// <summary>
        /// <inheritdoc cref="IMyException.ErrorMessage"/>
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <inheritdoc cref="Exception.Message"/>
        public new string Message => $"{ErrorMessage}. Original figure: {OriginalFigure}. Cut out figure: {CutOutFigure}";
    }
}