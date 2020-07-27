using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.BaseAbstract
{
    public abstract class CircularFigure : Figure
    {
        protected CircularFigure(double radius) => Radius = radius;

        protected CircularFigure(double radius, IFigure cutOutFigure)
        {
            Radius = radius;
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        public double Radius { get; protected set; }
    }
}