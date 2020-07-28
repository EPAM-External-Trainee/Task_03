using System.Xml;
using System.Xml.Linq;
using Task.Figures.Models.PaperFigures;
using Task.MyParsers.Abstract;
using Task.MyParsers.Interfaces;

namespace Task.MyParsers.Models
{
    public class XmlPaperFiguresParser : XmlOperations, IPaperFiguresParser
    {
        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperCircleFromXml(XmlReader)"/>
        public PaperCircle ParseToPaperCircleFromXml(XmlReader reader) => new PaperCircle(GetRadiusFromXml(reader), GetColorFromXml(reader));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperCircleFromXml(XElement)"/>
        public PaperCircle ParseToPaperCircleFromXml(XElement element) => new PaperCircle(GetRadiusFromXml(element), GetColorFromXml(element));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperRectangleFromXml(XmlReader)"/>
        public PaperRectangle ParseToPaperRectangleFromXml(XmlReader reader) => new PaperRectangle(GetSidesFromXml(reader), GetColorFromXml(reader));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperRectangleFromXml(XElement)"/>
        public PaperRectangle ParseToPaperRectangleFromXml(XElement element) => new PaperRectangle(GetSidesFromXml(element), GetColorFromXml(element));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperSquareFromXml(XmlReader)"/>
        public PaperSquare ParseToPaperSquareFromXml(XmlReader reader) => new PaperSquare(GetSidesFromXml(reader), GetColorFromXml(reader));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperSquareFromXml(XElement)"/>
        public PaperSquare ParseToPaperSquareFromXml(XElement element) => new PaperSquare(GetSidesFromXml(element), GetColorFromXml(element));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperTriangleFromXml(XmlReader)"/>
        public PaperTriangle ParseToPaperTriangleFromXml(XmlReader reader) => new PaperTriangle(GetSidesFromXml(reader), GetColorFromXml(reader));

        /// <inheritdoc cref="IPaperFiguresParser.ParseToPaperTriangleFromXml(XElement)"/>
        public PaperTriangle ParseToPaperTriangleFromXml(XElement element) => new PaperTriangle(GetSidesFromXml(element), GetColorFromXml(element));
    }
}