using System.IO;
using System.Xml;
using Task.Figures.Interfaces;

namespace Task.MyParsers.Interfaces
{
    public interface IPaperXmlElementWriter
    {
        void WritePolygonPaperFigure(XmlWriter writer, IPaperFigure polygonFigure);

        void WritePolygonPaperFigure(StreamWriter writer, IPaperFigure polygonFigure);

        void WriteCircularPaperFigure(XmlWriter writer, IPaperFigure circularFigure);

        void WriteCircularPaperFigure(StreamWriter writer, IPaperFigure circularFigure);
    }
}