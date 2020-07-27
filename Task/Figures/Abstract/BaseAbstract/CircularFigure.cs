using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Class that describes a circular figure
    /// </summary>
    public abstract class CircularFigure : Figure
    {
        /// <summary>
        /// Instance constructor for creating a circular figure through the radius
        /// </summary>
        /// <param name="radius"></param>
        protected CircularFigure(double radius) => Radius = radius;

        /// <summary>
        /// Instance constructor for creating a circular figure through the radius and another figure
        /// </summary>
        /// <param name="radius">Circular figure radius</param>
        /// <param name="cutOutFigure">Cut out the figure</param>
        protected CircularFigure(double radius, IFigure cutOutFigure)
        {
            Radius = radius;
            if (GetArea() > cutOutFigure.GetArea())
            {
                throw new OutOfAreaException("You can't cut a figure because the original shape is smaller", this, cutOutFigure);
            }
        }

        /// <summary>
        /// Circular figure radius
        /// </summary>
        /// <param name="radius"></param>
        public double Radius { get; protected set; }

        public override bool Equals(object obj) => obj is CircularFigure figure && Radius == figure?.Radius;

        public override int GetHashCode() => 598075851 + Radius.GetHashCode();
    }
}