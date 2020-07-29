using System;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a circle
    /// </summary>
    public abstract class Circle : CircularFigure
    {
        /// <summary>
        /// Instance constructor for creating a circle figure through the radius
        /// </summary>
        /// <param name="radius">Circle radius</param>
        protected Circle(double radius)
        {
            if(radius <= 0d)
            {
                throw new ArgumentException("Radius can't be equal or less than zero");
            }
            CircularFigureRadius = radius;
        }

        /// <summary>
        /// Instance constructor for creating a circle figure through the radius and another figure
        /// </summary>
        /// <param name="radius">Circle radius</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Circle(double radius, IFigure cutOutFigure) : this(radius)
        {
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(2 * Math.PI * CircularFigureRadius, 2);

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(Math.PI * CircularFigureRadius * CircularFigureRadius, 2);

        public override bool Equals(object obj) => obj is Circle circle && CircularFigureRadius == circle?.CircularFigureRadius;

        public override int GetHashCode() => 598075851 + CircularFigureRadius.GetHashCode();
    }
}