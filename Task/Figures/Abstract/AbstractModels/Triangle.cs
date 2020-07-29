using System;
using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.AbstractModels
{
    /// <summary>
    /// Class describing a triangle
    /// </summary>
    public abstract class Triangle : PolygonFigure
    {
        /// <summary>
        /// Instance constructor for creating a triangle figure through the sides
        /// </summary>
        /// <param name="sides">Triangle sides</param>
        protected Triangle(IEnumerable<double> sides)
        {
            if(sides.Count() != 3)
            {
                throw new ArgumentException("To initialize a triangle, pass three sides");
            }
            PolygonFigureSides = sides.ToList();
        }

        /// <summary>
        /// Instance constructor for creating a triangle figure figure through the sides and another figure
        /// </summary>
        /// <param name="sides">Triangle sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected Triangle(IEnumerable<double> sides, IFigure cutOutFigure) : this(sides)
        {
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <inheritdoc cref="Figure.GetArea"/>
        public override double GetArea()
        {
            double pmr = Math.Round(GetPerimeter() / 2, 2);
            return Math.Round(Math.Sqrt(pmr * (pmr - PolygonFigureSides[0]) * (pmr - PolygonFigureSides[1]) * (pmr - PolygonFigureSides[2])), 2);
        }

        /// <inheritdoc cref="Figure.GetPerimeter"/>
        public override double GetPerimeter() => Math.Round((PolygonFigureSides[0] + PolygonFigureSides[1] + PolygonFigureSides[2]), 2);

        public override bool Equals(object obj) => obj is Triangle && PolygonFigureSides.SequenceEqual((obj as Triangle)?.PolygonFigureSides);

        public override int GetHashCode() => 1814305551 + PolygonFigureSides.GetHashCode();
    }
}