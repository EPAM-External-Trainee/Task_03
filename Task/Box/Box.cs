using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Task.Enums;
using Task.Figures.Abstract.AbstractModels;
using Task.Figures.Interfaces;
using Task.FileWork.Interfaces;
using Task.FileWork.Models;

namespace Task.Box
{
    /// <summary>
    /// Class describing the figure box
    /// </summary>
    public static class Box
    {
        /// <summary>
        /// Maximum number of figures allowed for storage in the box
        /// </summary>
        private const byte _maxFiguresCount = 20;

        /// <summary>
        /// Object for working with a file via XmlReader and XmlWriter
        /// </summary>
        private static readonly IXmlFileWorker _xmlFileWorker = new XmlWorker();

        /// <summary>
        /// Object for working with a file via StreamReader and StreamWriter
        /// </summary>
        private static readonly IStreamFileWorker _streamFileWorker = new StreamWorker();

        static Box() => Figures = new List<IFigure>(_maxFiguresCount);

        /// <summary>
        /// List for storing figures
        /// </summary>
        public static List<IFigure> Figures { get; private set; }

        /// <summary>
        /// Calculating the total area of the figures in the box
        /// </summary>
        public static double TotalArea
        {
            get
            {
                if (Figures.Count > 0)
                {
                    double result = 0;
                    Figures.ForEach(f => result += f.GetArea());
                    return Math.Round(result, 2);
                }

                throw new Exception("The box is empty");
            }
        }

        /// <summary>
        /// Calculating the total perimeter of the figures in the box
        /// </summary>
        public static double TotalPerimeter
        {
            get
            {
                if (Figures.Count > 0)
                {
                    double result = 0;
                    Figures.ForEach(f => result += f.GetPerimeter());
                    return Math.Round(result, 2);
                }

                throw new Exception("The box is empty");
            }
        }

        /// <summary>
        /// Current number of figures in box
        /// </summary>
        public static int CurrentFiguresCount => Figures.Count;

        /// <summary>
        /// Initialization figures collection
        /// </summary>
        /// <param name="figures">Figures</param>
        public static void InitializeFigures(IEnumerable<IFigure> figures)
        {
            if (figures.Count() > _maxFiguresCount)
            {
                throw new ArgumentException("Exceeded the allowed number of figures in the box");
            }

            Figures.Clear();
            figures.ToList().ForEach(f => AddFigure(f));
        }

        /// <summary>
        /// Add figure to figures collection
        /// </summary>
        /// <param name="figure">Figure</param>
        public static void AddFigure(IFigure figure)
        {
            if (Figures.Contains(figure))
            {
                throw new ArgumentException("Attempt to add an existing shape");
            }

            Figures.Add(figure);
        }

        /// <summary>
        /// View a figure
        /// </summary>
        /// <param name="number">Figure number</param>
        /// <returns>Figure</returns>
        public static IFigure ViewFigure(int number)
        {
            if (number >= 1 && number <= Figures.Count)
            {
                return Figures[--number];
            }

            throw new IndexOutOfRangeException("The specified index is out of the allowed range");
        }

        /// <summary>
        /// Extract a figure
        /// </summary>
        /// <param name="number">Figure number</param>
        /// <returns></returns>
        public static IFigure ExtractFigure(int number)
        {
            IFigure figure = ViewFigure(number);
            Figures.Remove(figure);
            return figure;
        }

        /// <summary>
        /// Replace a figure
        /// </summary>
        /// <param name="number">Number of the figure to replace</param>
        /// <param name="figure">New figure</param>
        public static void ReplaceFigure(int number, IFigure figure)
        {
            if (number >= 1 && number <= Figures.Count)
            {
                Figures[--number] = figure;
                return;
            }

            throw new IndexOutOfRangeException("The specified index is out of the allowed range");
        }

        /// <summary>
        /// Search for a similar figure in the box
        /// </summary>
        /// <param name="figure">The desired figure</param>
        /// <returns>Figure</returns>
        public static IFigure FindEqualFigure(IFigure figure) => Figures.FirstOrDefault(f => f.Equals(figure));

        /// <summary>
        /// Get all circles from the box
        /// </summary>
        /// <returns>Figures collection</returns>
        public static IEnumerable<IFigure> GetAllCircles()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is Circle);
            }

            throw new Exception("The box is empty");
        }

        /// <summary>
        /// Get all figures made of film in the box
        /// </summary>
        /// <returns>Figures collection</returns>
        public static IEnumerable<IFilmFigure> GetAllFilmFigures()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is IFilmFigure).ConvertAll(f => f as IFilmFigure);
            }

            throw new Exception("The box is empty");
        }

        /// <summary>
        /// Get all figures made of paper in the box
        /// </summary>
        /// <returns>Figures collection</returns>
        public static IEnumerable<IPaperFigure> GetAllPaperFigures()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is IPaperFigure).ConvertAll(f => f as IPaperFigure);
            }

            throw new Exception("The box is empty");
        }

        /// <summary>
        /// Write figures from the box which made of selected material using StreamWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="material">The material that the figure is made of</param>
        /// <param name="writer">StreamWriter object</param>
        public static void WriteFiguresFromBoxToXML(string path, FigureMaterials material, StreamWriter writer) => _streamFileWorker.WriteFiguresFromBoxToXML(path, GetFigruesForSpecifiedMaterial(material), writer);

        /// <summary>
        /// Write figures from the box which made of selected material using XmlWriter
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="material">The material that the figure is made of</param>
        /// <param name="writer">XmlWriter object</param>
        public static void WriteFiguresFromBoxToXML(string path, FigureMaterials material, XmlWriter writer) => _xmlFileWorker.WriteFiguresFromBoxToXML(path, GetFigruesForSpecifiedMaterial(material), writer);

        /// <summary>
        /// Get figures that were made from the selected material
        /// </summary>
        /// <param name="material">The material that figures are made of</param>
        /// <returns>Figures collection</returns>
        private static IEnumerable<IFigure> GetFigruesForSpecifiedMaterial(FigureMaterials material)
        {
            switch (material)
            {
                case FigureMaterials.PaperAndFilm: return Figures;
                case FigureMaterials.Film: return GetAllFilmFigures();
                case FigureMaterials.Paper: return GetAllPaperFigures();
            }

            return null;
        }

        /// <summary>
        /// Read figures from xml file using StreamReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="reader">StreamReader object</param>
        /// <returns>Figures collection</returns>
        public static IEnumerable<IFigure> ReadAllFiguresFromXML(string path, StreamReader reader)
        {
            InitializeFigures(_streamFileWorker.ReadFiguresFromXML(path, reader));
            return Figures;
        }

        /// <summary>
        /// Read figures from xml file using XmlReader
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="reader">XmlReader object</param>
        /// <returns>Figures collection</returns>
        public static IEnumerable<IFigure> ReadAllFiguresFromXML(string path, XmlReader reader)
        {
            InitializeFigures(_xmlFileWorker.ReadFiguresFromXML(path, reader));
            return Figures;
        }
    }
}