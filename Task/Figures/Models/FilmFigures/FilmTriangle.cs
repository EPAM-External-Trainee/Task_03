using System.Collections.Generic;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;

namespace Task.Figures.Models.FilmFigures
{
    public class FilmTriangle : Triangle, IFilmFigure
    {
        public FilmTriangle(IEnumerable<double> sides) : base(sides) { }

        public FilmTriangle(IEnumerable<double> sides, IFilmFigure cutOutFilmFigure) : base(sides, cutOutFilmFigure) { }
    }
}