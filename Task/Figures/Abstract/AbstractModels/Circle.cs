using System;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.Figures.Abstract.AbstractModels
{
    public abstract class Circle : CircularFigure
    {
        protected Circle(double radius) : base(radius) { }

        protected Circle(double radius, IFigure cutOutFigure) : base(radius, cutOutFigure) { }

        public override double GetPerimeter() => Math.Round(2 * Math.PI * Radius, 2);

        public override double GetArea() => Math.Round(Math.PI * Radius * Radius, 2);

        public override bool Equals(object obj) => obj is Circle circle && Radius == circle?.Radius;

        public override int GetHashCode() => 598075851 + Radius.GetHashCode();
    }
}