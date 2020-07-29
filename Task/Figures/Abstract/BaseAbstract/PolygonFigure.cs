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
        protected List<double> PolygonFigureSides { get; set; }

        /// <summary>
        /// Property for getting figure sides
        /// </summary>
        public List<double> Sides => PolygonFigureSides;

        public override bool Equals(object obj) => obj is PolygonFigure figure && PolygonFigureSides.SequenceEqual(figure?.PolygonFigureSides);

        public override int GetHashCode() => 1814305551 + PolygonFigureSides.GetHashCode();
    }
}