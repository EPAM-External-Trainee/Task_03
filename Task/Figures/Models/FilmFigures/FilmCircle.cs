using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    /// <summary>
    /// Class that describes a circle made of film
    /// </summary>
    public class FilmCircle : Circle, IFilmFigure
    {
        /// <inheritdoc cref="Circle(double)"/>
        public FilmCircle(double radius) : base(radius) { }

        /// <inheritdoc cref="Circle(double, IFigure)"/>
        public FilmCircle(double radius, IFilmFigure cutOutFilmFigure) : base(radius, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmCircle circle && base.Equals(obj) && CircularFigureRadius == circle?.CircularFigureRadius;

        public override int GetHashCode()
        {
            int hashCode = 1605559401;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + CircularFigureRadius.GetHashCode();
            return hashCode;
        }
    }
}