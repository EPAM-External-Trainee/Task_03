using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Base class that describes the figure
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <summary>
        /// Сalculation of area
        /// </summary>
        /// <returns>Area</returns>
        public abstract double GetArea();

        /// <summary>
        /// Сalculation of perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public abstract double GetPerimeter();

        public override string ToString() => $"Figure type: {GetType().Name}; Perimeter: {GetPerimeter()}; Area: {GetArea()};";
    }
}