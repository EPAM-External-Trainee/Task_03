using System.Collections.Generic;
using System.Xml;
using Task.Figures.Interfaces;

namespace Task.FileWork.Interfaces
{
    public interface IXmlFileWorker
    {
        bool WriteFiguresFromBoxToXML(string path, IEnumerable<IFigure> figures, XmlWriter writer);

        IEnumerable<IFigure> ReadFiguresFromXML(string path, XmlReader reader);
    }
}