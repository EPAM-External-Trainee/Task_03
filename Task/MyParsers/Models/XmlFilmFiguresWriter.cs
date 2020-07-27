using System.IO;
using System.Xml;
using Task.Figures.Abstract.BaseAbstract;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlFilmFiguresWriter : XmlOperations, IFilmXmlElementWriter
    {
        public void WriteCircularFilmFigure(XmlWriter writer, CircularFigure circularFigure)
        {
            WriteElementName(writer, circularFigure);
            WriteRadius(writer, circularFigure);
            writer.WriteEndElement();
        }

        public void WriteCircularFilmFigure(StreamWriter writer, CircularFigure circularFigure)
        {
            WriteElementName(writer, circularFigure);
            WriteRadius(writer, circularFigure);
            WriteEndElement(writer, circularFigure);
        }

        public void WritePolygonFilmFigure(XmlWriter writer, PolygonFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure);
            WriteSides(writer, polygonFigure);
            writer.WriteEndElement();
        }

        public void WritePolygonFilmFigure(StreamWriter writer, PolygonFigure polygonFigure)
        {
            WriteElementName(writer, polygonFigure);
            WriteSides(writer, polygonFigure);
            WriteEndElement(writer, polygonFigure);
        }
    }
}