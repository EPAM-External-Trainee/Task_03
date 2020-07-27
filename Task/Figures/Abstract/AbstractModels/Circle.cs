using System;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a circle
    /// </summary>
    public abstract class Circle : CircularFigure
    {
        /// <summary>
        /// Instance constructor for creating a circle through a radius
        /// </summary>
        /// <param name="radius">Circle radius</param>
        protected Circle(double radius) : base(radius) { }

        /// <summary>
        /// Instance constructor for creating a circle through a radius and another figure
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Circle(double radius, IFigure cutOutFigure) : base(radius, cutOutFigure) { }

        /// <summary>
        /// Сalculation of perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public override double GetPerimeter() => Math.Round(2 * Math.PI * Radius, 2);

        /// <summary>
        /// Сalculation of area
        /// </summary>
        /// <returns>Area</returns>
        public override double GetArea() => Math.Round(Math.PI * Radius * Radius, 2);

        public override bool Equals(object obj) => obj is Circle circle && Radius == circle?.Radius;

        public override int GetHashCode() => 598075851 + Radius.GetHashCode();
    }
}