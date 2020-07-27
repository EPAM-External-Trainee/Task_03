using System.Collections.Generic;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    public class FilmSquare : Square, IFilmFigure
    {
        public FilmSquare(IEnumerable<double> sides) : base(sides) { }

        public FilmSquare(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }
    }
}