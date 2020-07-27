using Task.Enums;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Models.PaperFigures
{
    public class PaperCircle : Circle, IPaperFigure
    {
        public PaperCircle(double radius, Colors color) : base(radius)
        {
            Color = color;
            IsPainted = true;
        }

        public PaperCircle(double radius, IPaperFigure cutOutPaperFigure) : base(radius, cutOutPaperFigure)
        {
            Color = cutOutPaperFigure.Color;
            IsPainted = true;
        }

        public Colors Color { get; set; }

        public bool IsPainted { get; set; }

        public void PaintOverFigure(Colors color)
        {
            if (IsPainted)
            {
                throw new IsPaintedException("You can only paint over a shape once.", Color);
            }

            Color = color;
            IsPainted = true;
        }

        public override bool Equals(object obj) => obj is PaperCircle circle && base.Equals(obj) && Radius == circle?.Radius && Color == circle?.Color && IsPainted == circle?.IsPainted;

        public override int GetHashCode()
        {
            int hashCode = 1204649235;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            hashCode = hashCode * -1521134295 + IsPainted.GetHashCode();
            return hashCode;
        }

        public override string ToString() => base.ToString() + $" Color: {Color};";
    }
}