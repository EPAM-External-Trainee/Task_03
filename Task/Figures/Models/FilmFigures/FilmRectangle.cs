using System.Collections.Generic;
using System.Linq;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    /// <summary>
    /// Class that describes a rectangle made of film
    /// </summary>
    public class FilmRectangle : Rectangle, IFilmFigure
    {
        /// <summary>
        /// Instance constructor to initialize a film rectangle through the sides.
        /// </summary>
        /// <param name="sides">Film rectangle sides</param>
        public FilmRectangle(IEnumerable<double> sides) : base(sides) { }

        /// <summary>
        /// Instance constructor to initialize a film rectangle through the sides and another figure
        /// </summary>
        /// <param name="sides">Film rectangle sides</param>
        /// <param name="cutOutFilmFigure">Cut out the figure</param>
        public FilmRectangle(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmRectangle rectangle && base.Equals(obj) && Sides.SequenceEqual(rectangle?.Sides);

        public override int GetHashCode()
        {
            int hashCode = 956485645;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Sides.GetHashCode();
            return hashCode;
        }
    }
}