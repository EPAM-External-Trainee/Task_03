using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a square
    /// </summary>
    public abstract class Square : PolygonFigure
    {
        /// <summary>
        /// Instance constructor for creating a square through the sides
        /// </summary>
        /// <param name="sides">Square sides</param>
        protected Square(IEnumerable<double> sides) : base(sides) { }

        /// <summary>
        /// Instance constructor for creating a square through the sides and another figure
        /// </summary>
        /// <param name="sides">Square sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Square(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        /// <summary>
        /// Сalculation of area
        /// </summary>
        /// <returns>Area</returns>
        public override double GetArea() => Math.Round(Sides[0] * Sides[0], 2);

        /// <summary>
        /// Сalculation of perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        public override double GetPerimeter() => Math.Round(4 * Sides[0], 2);

        public override bool Equals(object obj) => obj is Square && Sides.SequenceEqual((obj as Square)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}