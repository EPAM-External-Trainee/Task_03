using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.BaseAbstract
{
    public abstract class Figure : IFigure
    {
        public abstract double GetArea();

        public abstract double GetPerimeter();

        public override string ToString() => $"Figure type: {GetType().Name}; Perimeter: {GetPerimeter()}; Area: {GetArea()};";
    }
}