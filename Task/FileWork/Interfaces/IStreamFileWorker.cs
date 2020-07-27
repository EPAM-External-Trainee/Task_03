using System.Collections.Generic;
using System.IO;
using Task.Figures.Interfaces;

namespace Task.FileWork.Interfaces
{
    /// <summary>
    /// An interfaces for working with xml file through StreamWriter and StreamReader
    /// </summary>
    public interface IStreamFileWorker
    {
        /// <summary>
        /// Write figures from box to xml file using StreamWriter
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="figures">Box figures collection</param>
        /// <param name="writer">StreamWriter object</param>
        /// <returns>Success of operation</returns>
        bool WriteFiguresFromBoxToXML(string path, IEnumerable<IFigure> figures, StreamWriter writer);

        /// <summary>
        /// Read figures from xml file using StreamReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="reader">StreamReader object</param>
        /// <returns>Figures collection</returns>
        IEnumerable<IFigure> ReadFiguresFromXML(string path, StreamReader reader);
    }
}