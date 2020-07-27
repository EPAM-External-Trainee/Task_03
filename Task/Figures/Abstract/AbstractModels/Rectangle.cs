using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a rectangle
    /// </summary>
    public abstract class Rectangle : PolygonFigure
    {
        /// <summary>
        /// Instance constructor for creating a rectangle through the sides
        /// </summary>
        /// <param name="sides">Rectangle sides</param>
        protected Rectangle(IEnumerable<double> sides) : base(sides) { }

        /// <summary>
        /// Instance constructor for creating a rectangle through the sides and another figure
        /// </summary>
        /// <param name="sides">Rectangle sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Rectangle(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        /// <summary>
        /// Сalculation of area
        /// </summary>
        /// <returns>Area</returns>
        public override double GetArea() => Math.Round(Sides[0] * Sides[1], 2);

        /// <summary>
        /// Сalculation of perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public override double GetPerimeter() => Math.Round(2 * (Sides[0] * Sides[1]), 2);

        public override bool Equals(object obj) => obj is Rectangle && Sides.SequenceEqual((obj as Rectangle)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}