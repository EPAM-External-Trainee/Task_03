using Task.Enums;

namespace Task.Figures.Interfaces
{
    /// <summary>
    /// An interface declaring methods for figures that made of paper.
    /// </summary>
    public interface IPaperFigure : IFigure
    {
        /// <summary>
        /// Determining whether the figure was painted over
        /// </summary>
        bool IsPainted { get; set; }

        /// <summary>
        /// Paper figure current color
        /// </summary>
        Colors Color { get; set; }

        /// <summary>
        /// Paint over figure
        /// </summary>
        /// <param name="color">Paint color</param>
        void PaintOverFigure(Colors color);
    }
}