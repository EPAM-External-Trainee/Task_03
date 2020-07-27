using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    public class FilmCircle : Circle, IFilmFigure
    {
        public FilmCircle(double radius) : base(radius) { }

        public FilmCircle(double radius, IFilmFigure cutOutFilmFigure) : base(radius, cutOutFilmFigure) { }

        public override bool Equals(object obj) => obj is FilmCircle circle && base.Equals(obj) && Radius == circle?.Radius;

        public override int GetHashCode()
        {
            int hashCode = 1605559401;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }
    }
}