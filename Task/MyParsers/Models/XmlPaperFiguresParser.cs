using System.Xml;
using System.Xml.Linq;
using Task.Figures.Interfaces;
using Task.Figures.Models.PaperFigures;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlPaperFiguresParser : XmlOperations, IPaperFiguresParser
    {
        public IPaperFigure ParseToPaperCircleFromXml(XmlReader reader) => new PaperCircle(GetRadiusFromXml(reader), GetColorFromXml(reader));

        public IPaperFigure ParseToPaperCircleFromXml(XElement element) => new PaperCircle(GetRadiusFromXml(element), GetColorFromXml(element));

        public IPaperFigure ParseToPaperRectangleFromXml(XmlReader reader) => new PaperRectangle(GetSidesFromXml(reader), GetColorFromXml(reader));

        public IPaperFigure ParseToPaperRectangleFromXml(XElement element) => new PaperRectangle(GetSidesFromXml(element), GetColorFromXml(element));

        public IPaperFigure ParseToPaperSquareFromXml(XmlReader reader) => new PaperSquare(GetSidesFromXml(reader), GetColorFromXml(reader));

        public IPaperFigure ParseToPaperSquareFromXml(XElement element) => new PaperSquare(GetSidesFromXml(element), GetColorFromXml(element));

        public IPaperFigure ParseToPaperTriangleFromXml(XmlReader reader) => new PaperTriangle(GetSidesFromXml(reader), GetColorFromXml(reader));

        public IPaperFigure ParseToPaperTriangleFromXml(XElement element) => new PaperTriangle(GetSidesFromXml(element), GetColorFromXml(element));
    }
}