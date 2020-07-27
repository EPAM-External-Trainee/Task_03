using System.Xml;
using System.Xml.Linq;
using Task.Figures.Models.FilmFigures;

namespace Task.MyParsers.Interfaces
{
    public interface IFilmFiguresParser
    {
        FilmCircle ParseToFilmCircleFromXml(XmlReader reader);

        FilmCircle ParseToFilmCircleFromXml(XElement element);

        FilmRectangle ParseToFilmRectangleFromXml(XmlReader reader);

        FilmRectangle ParseToFilmRectangleFromXml(XElement element);

        FilmSquare ParseToFilmSquareFromXml(XmlReader reader);

        FilmSquare ParseToFilmSquareFromXml(XElement element);

        FilmTriangle ParseToFilmTriangleFromXml(XmlReader reader);

        FilmTriangle ParseToFilmTriangleFromXml(XElement element);
    }
}