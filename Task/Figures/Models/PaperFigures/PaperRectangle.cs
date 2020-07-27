using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Models.PaperFigures
{
    public class PaperRectangle : Rectangle, IPaperFigure
    {
        public PaperRectangle(IEnumerable<double> sides, Colors color) : base(sides)
        {
            Color = color;
            IsPainted = true;
        }

        public PaperRectangle(IEnumerable<double> sides, IPaperFigure cutOutPaperFigure) : base(sides, cutOutPaperFigure)
        {
            Color = cutOutPaperFigure.Color;
            IsPainted = true;
        }

        public bool IsPainted { get; set; }

        public Colors Color { get; set; }

        public void PaintOverFigure(Colors color)
        {
            if (!IsPainted)
            {
                throw new IsPaintedException("You can only paint over a shape once.", Color);
            }

            Color = color;
            IsPainted = false;
        }

        public override bool Equals(object obj) => obj is PaperRectangle rectangle && base.Equals(obj) && IsPainted == rectangle?.IsPainted && Color == rectangle?.Color;

        public override int GetHashCode()
        {
            int hashCode = 715578416;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + IsPainted.GetHashCode();
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            return hashCode;
        }

        public override string ToString() => base.ToString() + $" Color: {Color};";
    }
}