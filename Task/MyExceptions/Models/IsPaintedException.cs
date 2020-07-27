using System;
using Task.Enums;
using Task.MyExceptions.Interfaces;

namespace Task.MyExceptions.Models
{
    public class IsPaintedException : Exception, IMyException
    {
        private Colors _color;

        public IsPaintedException(string message, Colors color)
        {
            ErrorMessage = message;
            _color = color;
        }

        public new string Message => $"{ErrorMessage}. The shape already has {_color} color.";

        public string ErrorMessage { get; set; }
    }
}