using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Task.Enums;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;
using Task.FileWork.Interfaces;
using Task.MyParsers.Interfaces;
using Task.MyParsers.Models;

namespace Task.FileWork.Models
{
    /// <summary>
    /// Class for working with xml file via read and write through StreamReader and StreamWriter
    /// </summary>
    public class StreamWorker : IStreamFileWorker
    {
        private static readonly IPaperFiguresParser _paperFiguresParser = new XmlPaperFiguresParser();
        private static readonly IPaperXmlElementWriter _paperXmlElementWriter = new XmlPaperFiguresWriter();
        private static readonly IFilmFiguresParser _filmFiguresParser = new XmlFilmFiguresParser();
        private static readonly IFilmXmlElementWriter _filmXmlElementWriter = new XmlFilmFiguresWriter();
        private const string _xmlHeader = "<?xml version =\"1.0\" encoding=\"utf-8\" ?>";

        /// <inheritdoc cref="IStreamFileWorker.ReadFiguresFromXML(string, StreamReader)"/>
        public IEnumerable<IFigure> ReadFiguresFromXML(string path, StreamReader reader)
        {
            using (reader = new StreamReader(path))
            {
                List<IFigure> figures = new List<IFigure>();
                XDocument xDoc = XDocument.Load(reader);
                foreach (XElement item in xDoc.Descendants("Figures").SelectMany(node => node.Elements()))
                {
                    Enum.TryParse(item.Name.ToString(), out FigureTypes currentType);
                    switch (currentType)
                    {
                        case FigureTypes.PaperCircle: figures.Add(_paperFiguresParser.ParseToPaperCircleFromXml(item)); break;
                        case FigureTypes.PaperRectangle: figures.Add(_paperFiguresParser.ParseToPaperRectangleFromXml(item)); break;
                        case FigureTypes.PaperSquare: figures.Add(_paperFiguresParser.ParseToPaperSquareFromXml(item)); break;
                        case FigureTypes.PaperTriangle: figures.Add(_paperFiguresParser.ParseToPaperTriangleFromXml(item)); break;
                        case FigureTypes.FilmCircle: figures.Add(_filmFiguresParser.ParseToFilmCircleFromXml(item)); break;
                        case FigureTypes.FilmRectangle: figures.Add(_filmFiguresParser.ParseToFilmRectangleFromXml(item)); break;
                        case FigureTypes.FilmSquare: figures.Add(_filmFiguresParser.ParseToFilmSquareFromXml(item)); break;
                        case FigureTypes.FilmTriangle: figures.Add(_filmFiguresParser.ParseToFilmTriangleFromXml(item)); break;
                    }
                }
                return figures;
            }
        }

        /// <inheritdoc cref="IStreamFileWorker.WriteFiguresFromBoxToXML(string, IEnumerable{IFigure}, StreamWriter)"/>
        public bool WriteFiguresFromBoxToXML(string path, IEnumerable<IFigure> figures, StreamWriter writer)
        {
            using (writer = new StreamWriter(path))
            {
                writer.WriteLine(_xmlHeader);
                writer.WriteLine("<Figures>");

                foreach (IFigure figure in figures)
                {
                    Enum.TryParse(figure.GetType().Name, out FigureTypes currentType);
                    switch (currentType)
                    {
                        case FigureTypes.PaperCircle: _paperXmlElementWriter.WriteCircularPaperFigure(writer, figure as IPaperFigure); break;
                        case FigureTypes.PaperRectangle:
                        case FigureTypes.PaperSquare:
                        case FigureTypes.PaperTriangle: _paperXmlElementWriter.WritePolygonPaperFigure(writer, figure as IPaperFigure); break;
                        case FigureTypes.FilmCircle: _filmXmlElementWriter.WriteCircularFilmFigure(writer, figure as CircularFigure); break;
                        case FigureTypes.FilmRectangle:
                        case FigureTypes.FilmSquare:
                        case FigureTypes.FilmTriangle: _filmXmlElementWriter.WritePolygonFilmFigure(writer, figure as PolygonFigure); break;
                    }
                }
                writer.WriteLine("</Figures>");
                return true;
            }
        }
    }
}