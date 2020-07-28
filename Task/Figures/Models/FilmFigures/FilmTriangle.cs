using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    /// <summary>
    /// Class that describes a triangle made of film
    /// </summary>
    public class FilmTriangle : Triangle, IFilmFigure
    {
        /// <inheritdoc cref="Triangle(IEnumerable{double})"/>
        public FilmTriangle(IEnumerable<double> sides) : base(sides) { }

        /// <inheritdoc cref="Triangle(IEnumerable{double}, IFigure)"/>
        public FilmTriangle(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmTriangle triangle && base.Equals(obj) && Sides.SequenceEqual(triangle?.Sides);

        public override int GetHashCode()
        {
            int hashCode = 956485645;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Sides.GetHashCode();
            return hashCode;
        }
    }
}