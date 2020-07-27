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
        /// <summary>
        /// Instance constructor to initialize a film triangle through the sides.
        /// </summary>
        /// <param name="sides">Film triangle sides</param>
        public FilmTriangle(IEnumerable<double> sides) : base(sides) { }

        /// <summary>
        /// Instance constructor to initialize a film triangle through the sides and another figure.
        /// </summary>
        /// <param name="sides">Film triangle sides</param>
        /// <param name="cutOutFilmFigure">Cut out the figure</param>
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