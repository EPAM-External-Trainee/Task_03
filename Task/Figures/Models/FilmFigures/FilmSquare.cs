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
        /// <summary>
        /// Instance constructor to initialize a film square through the sides.
        /// </summary>
        /// <param name="sides"></param>
        public FilmSquare(IEnumerable<double> sides) : base(sides) { }

        /// <summary>
        /// Instance constructor to initialize a film square through the sides and another figure
        /// </summary>
        /// <param name="sides">Film square sides</param>
        /// <param name="cutOutFilmFigure">Cut out the figure</param>
        public FilmSquare(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmSquare square && base.Equals(obj) && Sides.SequenceEqual(square?.Sides);

        public override int GetHashCode()
        {
            int hashCode = 956485645;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Sides.GetHashCode();
            return hashCode;
        }
    }
}