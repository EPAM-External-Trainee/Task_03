namespace Task.Figures.Abstract.BaseAbstract
{
    /// <summary>
    /// Class that describes a circular figure
    /// </summary>
    public abstract class CircularFigure : Figure
    {
        /// <summary>
        /// Circular figure radius
        /// </summary>
        /// <param name="radius"></param>
        public double Radius { get; protected set; }

        public override bool Equals(object obj) => obj is CircularFigure figure && Radius == figure?.Radius;

        public override int GetHashCode() => 598075851 + Radius.GetHashCode();
    }
}