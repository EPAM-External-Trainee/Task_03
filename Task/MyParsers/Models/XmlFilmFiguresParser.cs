using System.Xml;
using System.Xml.Linq;
using Task.Figures.Models.FilmFigures;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlFilmFiguresParser : XmlOperations, IFilmFiguresParser
    {
        public FilmCircle ParseToFilmCircleFromXml(XmlReader reader) => new FilmCircle(GetRadiusFromXml(reader));

        public FilmCircle ParseToFilmCircleFromXml(XElement element) => new FilmCircle(GetRadiusFromXml(element));

        public FilmRectangle ParseToFilmRectangleFromXml(XmlReader reader) => new FilmRectangle(GetSidesFromXml(reader));

        public FilmRectangle ParseToFilmRectangleFromXml(XElement element) => new FilmRectangle(GetSidesFromXml(element));

        public FilmSquare ParseToFilmSquareFromXml(XmlReader reader) => new FilmSquare(GetSidesFromXml(reader));

        public FilmSquare ParseToFilmSquareFromXml(XElement element) => new FilmSquare(GetSidesFromXml(element));

        public FilmTriangle ParseToFilmTriangleFromXml(XmlReader reader) => new FilmTriangle(GetSidesFromXml(reader));

        public FilmTriangle ParseToFilmTriangleFromXml(XElement element) => new FilmTriangle(GetSidesFromXml(element));
    }
}