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
        public void WriteCircularPaperFigure(XmlWriter writer, IPaperFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteColor(writer, circularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            writer.WriteEndElement();
        }

        public void WriteCircularPaperFigure(StreamWriter writer, IPaperFigure circularFigure)
        {
            WriteElementName(writer, circularFigure as CircularFigure);
            WriteColor(writer, circularFigure);
            WriteRadius(writer, circularFigure as CircularFigure);
            WriteEndElement(writer, circularFigure as CircularFigure);
        }

        public void WritePolygonPaperFigure(XmlWriter writer, IPaperFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteColor(writer, polygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            writer.WriteEndElement();
        }

        public void WritePolygonPaperFigure(StreamWriter writer, IPaperFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure as PolygonFigure);
            WriteColor(writer, polygonFigure);
            WriteSides(writer, polygonFigure as PolygonFigure);
            WriteEndElement(writer, polygonFigure as PolygonFigure);
        }
    }
}