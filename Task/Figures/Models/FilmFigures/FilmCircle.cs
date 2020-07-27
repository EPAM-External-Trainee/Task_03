using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    public class FilmCircle : Circle, IFilmFigure
    {
        public FilmCircle(double radius) : base(radius) { }

        public FilmCircle(double radius, IFilmFigure cutOutFilmFigure) : base(radius, cutOutFilmFigure) { }
    }
}