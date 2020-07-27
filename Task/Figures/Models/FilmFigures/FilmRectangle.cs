using System.Collections.Generic;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    public class FilmRectangle : Rectangle, IFilmFigure
    {
        public FilmRectangle(IEnumerable<double> sides) : base(sides) { }

        public FilmRectangle(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }
    }
}