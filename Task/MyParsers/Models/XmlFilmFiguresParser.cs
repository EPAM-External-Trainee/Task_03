using System.Xml;
using System.Xml.Linq;
using Task.Figures.Models.FilmFigures;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlFilmFiguresParser : XmlOperations, IFilmFiguresParser
    {
        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmCircleFromXml(XmlReader)"/>
        public FilmCircle ParseToFilmCircleFromXml(XmlReader reader) => new FilmCircle(GetRadiusFromXml(reader));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmCircleFromXml(XElement)"/>
        public FilmCircle ParseToFilmCircleFromXml(XElement element) => new FilmCircle(GetRadiusFromXml(element));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmRectangleFromXml(XmlReader)"/>
        public FilmRectangle ParseToFilmRectangleFromXml(XmlReader reader) => new FilmRectangle(GetSidesFromXml(reader));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmRectangleFromXml(XElement)"/>
        public FilmRectangle ParseToFilmRectangleFromXml(XElement element) => new FilmRectangle(GetSidesFromXml(element));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmSquareFromXml(XmlReader)"/>
        public FilmSquare ParseToFilmSquareFromXml(XmlReader reader) => new FilmSquare(GetSidesFromXml(reader));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmSquareFromXml(XElement)"/>
        public FilmSquare ParseToFilmSquareFromXml(XElement element) => new FilmSquare(GetSidesFromXml(element));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmTriangleFromXml(XmlReader)"/>
        public FilmTriangle ParseToFilmTriangleFromXml(XmlReader reader) => new FilmTriangle(GetSidesFromXml(reader));

        /// <inheritdoc cref="IFilmFiguresParser.ParseToFilmTriangleFromXml(XElement)"/>
        public FilmTriangle ParseToFilmTriangleFromXml(XElement element) => new FilmTriangle(GetSidesFromXml(element));
    }
}