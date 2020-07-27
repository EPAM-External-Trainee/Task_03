using System;
using Task.Figures.Interfaces;
using Task.MyExceptions.Interfaces;

namespace Task.MyExceptions.Models
{
    public class OutOfAreaException : Exception, IMyException
    {
        public OutOfAreaException(string message, IFigure originalFigure, IFigure cutOutFigure)
        {
            OriginalFigure = originalFigure;
            CutOutFigure = cutOutFigure;
            ErrorMessage = message;
        }

        public IFigure OriginalFigure { get; private set; }

        public IFigure CutOutFigure { get; private set; }

        public string ErrorMessage { get; set; }

        public new string Message => $"{ErrorMessage}. Original figure: {OriginalFigure}. Cut out figure: {CutOutFigure}";
    }
}