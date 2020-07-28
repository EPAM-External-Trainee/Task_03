using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;
using Task.MyExceptions.Models;

namespace Task.Figures.Models.PaperFigures
{
    /// <summary>
    /// Class that describes a square made of paper
    /// </summary>
    public class PaperSquare : Square, IPaperFigure
    {
        /// <summary>
        /// Instance constructor to initialize a paper square through the sides and color.
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="color"></param>
        public PaperSquare(IEnumerable<double> sides, Colors color) : base(sides)
        {
            Color = color;
            IsPainted = true;
        }

        /// <inheritdoc cref="Square(IEnumerable{double}, IFigure)"/>
        public PaperSquare(IEnumerable<double> sides, IPaperFigure cutOutPaperFigure) : base(sides, cutOutPaperFigure)
        {
            Color = cutOutPaperFigure.Color;
            IsPainted = true;
        }

        /// <inheritdoc cref="IPaperFigure.IsPainted"/>
        public bool IsPainted { get; set; }

        /// <inheritdoc cref="IPaperFigure.Color"/>
        public Colors Color { get; set; }

        /// <inheritdoc cref="IPaperFigure.PaintOverFigure(Colors)"/>
        public void PaintOverFigure(Colors color)
        {
            if (!IsPainted)
            {
                throw new IsPaintedException("You can only paint over a shape once.", Color);
            }

            Color = color;
            IsPainted = false;
        }

        public override bool Equals(object obj) => obj is PaperSquare square && base.Equals(obj) && IsPainted == square?.IsPainted && Color == square?.Color;

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