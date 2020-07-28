using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a triangle
    /// </summary>
    public abstract class Triangle : PolygonFigure
    {
        /// <inheritdoc cref="PolygonFigure(IEnumerable{double})"/>
        protected Triangle(IEnumerable<double> sides) : base(sides) { }

        /// <inheritdoc cref="PolygonFigure(IEnumerable{double}, IFigure)"/>
        protected Triangle(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea()
        {
            double pmr = Math.Round(GetPerimeter() / 2, 2);
            return Math.Round(Math.Sqrt(pmr * (pmr - Sides[0]) * (pmr - Sides[1]) * (pmr - Sides[2])), 2);
        }

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round((Sides[0] + Sides[1] + Sides[2]), 2);

        public override bool Equals(object obj) => obj is Triangle && Sides.SequenceEqual((obj as Triangle)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}