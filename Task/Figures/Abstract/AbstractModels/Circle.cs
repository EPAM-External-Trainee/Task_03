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
        /// <inheritdoc cref="CircularFigure(double)"/>
        protected Circle(double radius) : base(radius) { }

        /// <inheritdoc cref="CircularFigure(double, IFigure)"/>
        protected Circle(double radius, IFigure cutOutFigure) : base(radius, cutOutFigure) { }

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(2 * Math.PI * Radius, 2);

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(Math.PI * Radius * Radius, 2);

        public override bool Equals(object obj) => obj is Circle circle && Radius == circle?.Radius;

        public override int GetHashCode() => 598075851 + Radius.GetHashCode();
    }
}