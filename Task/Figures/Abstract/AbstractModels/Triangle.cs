using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    public abstract class Triangle : PolygonFigure
    {
        protected Triangle(IEnumerable<double> sides) : base(sides) { }

        protected Triangle(IEnumerable<double> sides, IFigure cutOutFigure) : base(sides, cutOutFigure) { }

        public override double GetArea()
        {
            double pmr = GetPerimeter();
            return Math.Round(Math.Sqrt(pmr * (pmr - Sides[0]) * (pmr - Sides[1]) * (pmr - Sides[2])), 2);
        }

        public override double GetPerimeter() => Math.Round((Sides[0] + Sides[1] + Sides[2]) / 2, 2);

        public override bool Equals(object obj) => obj is Triangle && Sides.SequenceEqual((obj as Triangle)?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}