using System.Collections.Generic;
using System.IO;
using Task.Figures.Interfaces;

namespace Task.FileWork.Interfaces
{
    public interface IStreamFileWorker
    {
        bool WriteFiguresFromBoxToXML(string path, IEnumerable<IFigure> figures, StreamWriter writer);

        IEnumerable<IFigure> ReadFiguresFromXML(string path, StreamReader reader);
    }
}