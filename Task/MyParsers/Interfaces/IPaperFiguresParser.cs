using System.Xml;
using System.Xml.Linq;
using Task.Figures.Interfaces;

namespace Task.MyParsers.Interfaces
{
    public interface IPaperFiguresParser
    {
        IPaperFigure ParseToPaperCircleFromXml(XmlReader reader);

        IPaperFigure ParseToPaperCircleFromXml(XElement element);

        IPaperFigure ParseToPaperRectangleFromXml(XmlReader reader);

        IPaperFigure ParseToPaperRectangleFromXml(XElement element);

        IPaperFigure ParseToPaperSquareFromXml(XmlReader reader);

        IPaperFigure ParseToPaperSquareFromXml(XElement element);

        IPaperFigure ParseToPaperTriangleFromXml(XmlReader reader);

        IPaperFigure ParseToPaperTriangleFromXml(XElement element);
    }
}