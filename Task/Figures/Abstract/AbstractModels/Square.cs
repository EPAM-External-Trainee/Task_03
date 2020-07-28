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
        /// <inheritdoc cref="PolygonFigure(IEnumerable{double})"/>
        protected Square(IEnumerable<double> sides) : base(sides) { }

        /// <inheritdoc cref="PolygonFigure(IEnumerable{double}, IFigure)"/>
        protected Square(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(Sides[0] * Sides[0], 2);

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(4 * Sides[0], 2);

        public override bool Equals(object obj) => obj is Square && Sides.SequenceEqual((obj as Square)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}