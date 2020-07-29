using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    /// <summary>
    /// Class that describes a square made of film
    /// </summary>
    public class FilmSquare : Square, IFilmFigure
    {
        /// <inheritdoc cref="Square(IEnumerable{double})"/>
        public FilmSquare(IEnumerable<double> sides) : base(sides) { }

        /// <inheritdoc cref="Square(IEnumerable{double}, IFigure)"/>
        public FilmSquare(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmSquare square && base.Equals(obj) && PolygonFigureSides.SequenceEqual(square?.PolygonFigureSides);

        public override int GetHashCode()
        {
            int hashCode = 956485645;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PolygonFigureSides.GetHashCode();
            return hashCode;
        }
    }
}