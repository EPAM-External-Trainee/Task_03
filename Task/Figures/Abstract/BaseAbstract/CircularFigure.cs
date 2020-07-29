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
        //public double Radius { get; protected set; }
        protected double CircularFigureRadius { get; set; }

        /// <summary>
        /// Property for getting figure radius
        /// </summary>
        public double Radius => CircularFigureRadius;

        public override bool Equals(object obj) => obj is CircularFigure figure && CircularFigureRadius == figure?.CircularFigureRadius;

        public override int GetHashCode() => 598075851 + CircularFigureRadius.GetHashCode();
    }
}