using System.Collections.Generic;
using System.Xml;
using Task.Figures.Interfaces;

namespace Task.FileWork.Interfaces
{
    /// <summary>
    /// An interfaces for working with xml file through XmlWriter and XmlReader
    /// </summary>
    public interface IXmlFileWorker
    {
        /// <summary>
        /// Write figures from box to xml file using XmlWriter
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="figures">Box figures collection</param>
        /// <param name="writer">XmlWriter object</param>
        /// <returns>Success of operation</returns>
        bool WriteFiguresFromBoxToXML(string path, IEnumerable<IFigure> figures, XmlWriter writer);

        /// <summary>
        /// Read figures from xml file using XmlReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="reader">XmlReader object</param>
        /// <returns>Figures collection</returns>
        IEnumerable<IFigure> ReadFiguresFromXML(string path, XmlReader reader);
    }
}