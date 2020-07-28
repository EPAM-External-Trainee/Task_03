using System.IO;
using System.Xml;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlFilmFiguresWriter : XmlOperations, IFilmXmlElementWriter
    {
        /// <inheritdoc cref="IFilmXmlElementWriter.WriteCircularFilmFigure(XmlWriter, IFilmFigure)"/>
        public void WriteCircularFilmFigure(XmlWriter writer, IFilmFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            writer.WriteEndElement();
        }

        /// <inheritdoc cref="IFilmXmlElementWriter.WriteCircularFilmFigure(StreamWriter, IFilmFigure)"/>
        public void WriteCircularFilmFigure(StreamWriter writer, IFilmFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            WriteEndElement(writer, circularFigure as CircularFigure);
        }

        /// <inheritdoc cref="IFilmXmlElementWriter.WritePolygonFilmFigure(XmlWriter, IFilmFigure)"/>
        public void WritePolygonFilmFigure(XmlWriter writer, IFilmFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            writer.WriteEndElement();
        }

        /// <inheritdoc cref="IFilmXmlElementWriter.WritePolygonFilmFigure(StreamWriter, IFilmFigure)"/>
        public void WritePolygonFilmFigure(StreamWriter writer, IFilmFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            WriteEndElement(writer, polygonFigure as PolygonFigure);
        }
    }
}