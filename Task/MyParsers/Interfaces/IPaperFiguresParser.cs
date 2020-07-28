using System.Xml;
using System.Xml.Linq;
using Task.Figures.Interfaces;
using Task.Figures.Models.PaperFigures;

namespace Task.MyParsers.Interfaces
{
    /// <summary>
    /// Interface that describes the basic operations of the paper figures writer
    /// </summary>
    public interface IPaperFiguresParser
    {
        /// <summary>
        /// Parse from XmlReader object to PaperCircle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>PaperCircle</returns>
        PaperCircle ParseToPaperCircleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to PaperCircle object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>PaperCircle</returns>
        PaperCircle ParseToPaperCircleFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to PaperRectangle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>PaperRectangle</returns>
        PaperRectangle ParseToPaperRectangleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to PaperRectangle object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>PaperRectangle</returns>
        PaperRectangle ParseToPaperRectangleFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to PaperSquare object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>PaperSquare</returns>
        PaperSquare ParseToPaperSquareFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to PaperSquare object
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>PaperSquare</returns>
        PaperSquare ParseToPaperSquareFromXml(XElement element);

        /// <summary>
        /// Parse from XmlReader object to PaperTriangle object
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>PaperTriangle</returns>
        PaperTriangle ParseToPaperTriangleFromXml(XmlReader reader);

        /// <summary>
        /// Parse from XElement object to PaperTriangle object
        /// </summary>
        /// <param name="element"></param>
        /// <returns>PaperTriangle</returns>
        PaperTriangle ParseToPaperTriangleFromXml(XElement element);
    }
}