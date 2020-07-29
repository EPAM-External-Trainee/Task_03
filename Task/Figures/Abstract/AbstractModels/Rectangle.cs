using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a rectangle
    /// </summary>
    public abstract class Rectangle : PolygonFigure
    {
        /// <summary>
        /// Instance constructor for creating a rectangle figure through the radius
        /// </summary>
        /// <param name="radius">Rectangle radius</param>
        protected Rectangle(IEnumerable<double> sides)
        {
            if(sides.Count() != 2 && sides.Count() != 4)
            {
                throw new ArgumentException("To initialize a rectangle, pass either two or four sides");
            }
            PolygonFigureSides = sides.ToList();
        }

        /// <summary>
        /// Instance constructor for creating a rectangle figure through the sides and another figure
        /// </summary>
        /// <param name="sides">Rectangle sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Rectangle(IEnumerable<double> sides, IFigure cutOutFigure) : this(sides)
        {
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(PolygonFigureSides[0] * PolygonFigureSides[1], 2);

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(2 * (PolygonFigureSides[0] + PolygonFigureSides[1]), 2);

        public override bool Equals(object obj) => obj is Rectangle && PolygonFigureSides.SequenceEqual((obj as Rectangle)?.PolygonFigureSides);

        public override int GetHashCode() => 1814305551 + PolygonFigureSides.GetHashCode();
    }
}