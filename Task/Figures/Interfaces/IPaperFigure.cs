using Task.Enums;

namespace Task.Figures.Interfaces
{
    public interface IPaperFigure : IFigure
    {
        bool IsPainted { get; set; }

        Colors Color { get; set; }

        void PaintOverFigure(Colors color);
    }
}