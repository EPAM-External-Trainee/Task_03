using System.IO;
using System.Xml;
using Task.Figures.Interfaces;

namespace Task.MyParsers.Interfaces
{
    /// <summary>
    /// Interface that describes the basic operations of the film figures writer
    /// </summary>
    public interface IFilmXmlElementWriter
    {
        /// <summary>
        /// Write film PolygonFigure object to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="polygonFigure">PolygonFigure object</param>
        void WritePolygonFilmFigure(XmlWriter writer, IFilmFigure polygonFigure);

        /// <summary>
        /// Write film PolygonFigure object to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="polygonFigure">PolygonFigure object</param>
        void WritePolygonFilmFigure(StreamWriter writer, IFilmFigure polygonFigure);

        /// <summary>
        /// Write film CircularFigure object to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="polygonFigure">CircularFigure object</param>
        void WriteCircularFilmFigure(XmlWriter writer, IFilmFigure circularFigure);

        /// <summary>
        /// Write film CircularFigure object to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="polygonFigure">CircularFigure object</param>
        void WriteCircularFilmFigure(StreamWriter writer, IFilmFigure circularFigure);
    }
}