using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Base class that describes the figure
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <inheritdoc cref="IFigure.GetArea"/>
        public abstract double GetArea();

        /// <inheritdoc cref="IFigure.GetPerimeter"/>
        public abstract double GetPerimeter();

        public override string ToString() => $"Figure type: {GetType().Name}; Perimeter: {GetPerimeter()}; Area: {GetArea()};";
    }
}