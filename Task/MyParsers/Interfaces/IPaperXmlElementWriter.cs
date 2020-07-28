using System.IO;
using System.Xml;
using Task.Figures.Interfaces;

namespace Task.MyParsers.Interfaces
{
    /// <summary>
    /// Interface that describes the basic operations of the paper figures writer
    /// </summary>
    public interface IPaperXmlElementWriter
    {
        /// <summary>
        /// Write paper PolygonFigure object to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="polygonFigure">PolygonFigure object</param>
        void WritePolygonPaperFigure(XmlWriter writer, IPaperFigure polygonFigure);

        /// <summary>
        /// Write paper PolygonFigure object to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="polygonFigure">PolygonFigure object</param>
        void WritePolygonPaperFigure(StreamWriter writer, IPaperFigure polygonFigure);

        /// <summary>
        /// Write paper CircularFigure object to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="circularFigure">CircularFigure object</param>
        void WriteCircularPaperFigure(XmlWriter writer, IPaperFigure circularFigure);

        /// <summary>
        /// Write paper CircularFigure object to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="circularFigure">CircularFigure object</param>
        void WriteCircularPaperFigure(StreamWriter writer, IPaperFigure circularFigure);
    }
}