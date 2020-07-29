using System.Collections.Generic;
using System.Linq;

namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Class that describes a polygon figure
    /// </summary>
    public abstract class PolygonFigure : Figure
    {
        /// <summary>
        /// Polygon figure sides
        /// </summary>
        public List<double> Sides { get; protected set; }

        public override bool Equals(object obj) => obj is PolygonFigure figure && Sides.SequenceEqual(figure?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}