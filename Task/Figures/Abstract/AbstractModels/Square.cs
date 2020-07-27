using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    public abstract class Square : PolygonFigure
    {
        protected Square(IEnumerable<double> sides) : base(sides) { }

        protected Square(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        public override double GetArea() => Math.Round(Sides[0] * Sides[0], 2);

        public override double GetPerimeter() => Math.Round(4 * Sides[0], 2);

        public override bool Equals(object obj) => obj is Square && Sides.SequenceEqual((obj as Square)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}