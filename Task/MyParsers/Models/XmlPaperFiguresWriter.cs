using System.IO;
using System.Xml;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlPaperFiguresWriter : XmlOperations, IPaperXmlElementWriter
    {
        /// <inheritdoc cref="IPaperXmlElementWriter.WriteCircularPaperFigure(XmlWriter, IPaperFigure)"/>
        public void WriteCircularPaperFigure(XmlWriter writer, IPaperFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            WriteColor(writer, circularFigure);
            writer.WriteEndElement();
        }

        /// <inheritdoc cref="IPaperXmlElementWriter.WriteCircularPaperFigure(StreamWriter, IPaperFigure)"/>
        public void WriteCircularPaperFigure(StreamWriter writer, IPaperFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            WriteColor(writer, circularFigure);
            WriteEndElement(writer, circularFigure as CircularFigure);
        }

        /// <inheritdoc cref="IPaperXmlElementWriter.WritePolygonPaperFigure(XmlWriter, IPaperFigure)"/>
        public void WritePolygonPaperFigure(XmlWriter writer, IPaperFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            WriteColor(writer, polygonFigure);
            writer.WriteEndElement();
        }

        /// <inheritdoc cref="IPaperXmlElementWriter.WritePolygonPaperFigure(StreamWriter, IPaperFigure)"/>
        public void WritePolygonPaperFigure(StreamWriter writer, IPaperFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            WriteColor(writer, polygonFigure);
            WriteEndElement(writer, polygonFigure as PolygonFigure);
        }
    }
}