using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a square
    /// </summary>
    public abstract class Square : PolygonFigure
    {
        /// <summary>
        /// Instance constructor for creating a square figure figure through the sides
        /// </summary>
        /// <param name="sides">Square sides</param>
        protected Square(IEnumerable<double> sides)
        {
            if(sides.Count() != 1 && sides.Count() != 4)
            {
                throw new ArgumentException("To initialize a square, pass either one or four sides");
            }
            PolygonFigureSides = sides.ToList();
        }

        /// <summary>
        /// Instance constructor for creating a square figure through the sides and another figure
        /// </summary>
        /// <param name="sides">Square sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Square(IEnumerable<double> sides, IFigure cutOutFigure) : this(sides)
        {
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea() => Math.Round(PolygonFigureSides[0] * PolygonFigureSides[0], 2);

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round(4 * PolygonFigureSides[0], 2);

        public override bool Equals(object obj) => obj is Square && PolygonFigureSides.SequenceEqual((obj as Square)?.PolygonFigureSides);

        public override int GetHashCode() => 1814305551 + PolygonFigureSides.GetHashCode();
    }
}