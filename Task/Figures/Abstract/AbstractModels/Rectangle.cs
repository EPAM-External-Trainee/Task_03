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
        /// <inheritdoc cref="PolygonFigure(IEnumerable{double})"/>
        protected Rectangle(IEnumerable<double> sides) : base(sides) { }

        /// <inheritdoc cref="PolygonFigure(IEnumerable{double}, IFigure)"/>
        protected Rectangle(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(Sides[0] * Sides[1], 2);

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(2 * (Sides[0] + Sides[1]), 2);

        public override bool Equals(object obj) => obj is Rectangle && Sides.SequenceEqual((obj as Rectangle)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}