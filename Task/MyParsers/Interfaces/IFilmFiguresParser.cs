using System.Xml;
using System.Xml.Linq;
using Task.Figures.Models.FilmFigures;

namespace Task.MyParsers.Interfaces
{
    /// <summary>
    /// Interface that describes the basic operations of the film figures parser
    /// </summary>
    public interface IFilmFiguresParser
    {
        /// <summary>
        /// Parse from XmlReader object to FilmCircle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>FilmCircle</returns>
        FilmCircle ParseToFilmCircleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to FilmCircle object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>FilmCircle</returns>
        FilmCircle ParseToFilmCircleFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to FilmRectangle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>FilmRectangle</returns>
        FilmRectangle ParseToFilmRectangleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to FilmRectangle object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>FilmRectangle</returns>
        FilmRectangle ParseToFilmRectangleFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to FilmSquare object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>FilmSquare</returns>
        FilmSquare ParseToFilmSquareFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to FilmSquare object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>FilmSquare</returns>
        FilmSquare ParseToFilmSquareFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to FilmTriangle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>FilmTriangle</returns>
        FilmTriangle ParseToFilmTriangleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to FilmTriangle object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>FilmTriangle </returns>
        FilmTriangle ParseToFilmTriangleFromXml(XElement element);
    }
}