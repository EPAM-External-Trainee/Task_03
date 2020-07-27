using System.Collections.Generic;
using System.Linq;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.BaseAbstract
{
    public abstract class PolygonFigure : Figure
    {
        protected PolygonFigure(IEnumerable<double> sides) => Sides = sides.ToList();

        protected PolygonFigure(IEnumerable<double> sides, IFigure cutOutFigure)
        {
            Sides = sides.ToList();
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        public List<double> Sides { get; protected set; }

        public override bool Equals(object obj) => obj is PolygonFigure figure && Sides.SequenceEqual(figure?.Sides);

        public override int GetHashCode() => 1814305551 + Sides.GetHashCode();
    }
}