using System.Collections.Generic;
using System.Linq;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Class that describes a polygon figure
    /// </summary>
    public abstract class PolygonFigure : Figure
    {
        /// <summary>
        /// Instance constructor for creating a polygon figure figure through the sides
        /// </summary>
        /// <param name="sides">Polygon figure sides</param>
        protected PolygonFigure(IEnumerable<double> sides) => Sides = sides.ToList();

        /// <summary>
        /// Instance constructor for creating a polygon figure figure through the sides and another figure
        /// </summary>
        /// <param name="sides">Polygon figure sides</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected PolygonFigure(IEnumerable<double> sides, IFigure cutOutFigure)
        {
            Sides = sides.ToList();
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <summary>
        /// Polygon figure sides
        /// </summary>
        public List<double> Sides { get; protected set; }

        public override bool Equals(object obj) => obj is PolygonFigure figure && Sides.SequenceEqual(figure?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}