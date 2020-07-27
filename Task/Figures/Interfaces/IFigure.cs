namespace Task.Figures.Interfaces
{
    /// <summary>
    /// An interface declaring methods for figures.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Сalculation of area
        /// </summary>
        /// <returns>Area</returns>
        double GetArea();

        /// <summary>
        /// Сalculation of perimeter
        /// </summary>
        /// <returns>Perimeter</returns>
        double GetPerimeter();
    }
}