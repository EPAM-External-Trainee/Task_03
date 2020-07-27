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
    public static class Box
    {
        private const byte _maxFiguresCount = 20;
        private static readonly IXmlFileWorker _xmlFileWorker = new XmlWorker();
        private static readonly IStreamFileWorker _streamFileWorker = new StreamWorker();

        static Box() => Figures = new List<IFigure>(_maxFiguresCount);

        public static List<IFigure> Figures { get; private set; }

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

        public static int CurrentFiguresCount => Figures.Count;

        public static void InitializeFigures(IEnumerable<IFigure> figures)
        {
            if (figures.Count() > _maxFiguresCount)
            {
                throw new ArgumentException("Exceeded the allowed number of figures in the box");
            }

            Figures.Clear();
            figures.ToList().ForEach(f => AddFigure(f));
        }

        public static void AddFigure(IFigure figure)
        {
            if (Figures.Contains(figure))
            {
                throw new ArgumentException("Attempt to add an existing shape");
            }

            Figures.Add(figure);
        }

        public static IFigure ViewFigure(int number)
        {
            if (number >= 1 && number <= Figures.Count)
            {
                return Figures[--number];
            }

            throw new IndexOutOfRangeException("The specified index is out of the allowed range");
        }

        public static IFigure ExtractFigure(int number)
        {
            IFigure figure = ViewFigure(number);
            Figures.Remove(figure);
            return figure;
        }

        public static void ReplaceFigure(int number, IFigure figure)
        {
            if (number >= 1 && number <= Figures.Count)
            {
                Figures[--number] = figure;
                return;
            }

            throw new IndexOutOfRangeException("The specified index is out of the allowed range");
        }

        public static IFigure FindEqualFigure(IFigure figure) => Figures.FirstOrDefault(f => f.Equals(figure));

        public static IEnumerable<IFigure> GetAllCircles()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is Circle);
            }

            throw new Exception("The box is empty");
        }

        public static IEnumerable<IFilmFigure> GetAllFilmFigures()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is IFilmFigure).ConvertAll(f => f as IFilmFigure);
            }

            throw new Exception("The box is empty");
        }

        public static IEnumerable<IPaperFigure> GetAllPaperFigures()
        {
            if (Figures.Count > 0)
            {
                return Figures.FindAll(f => f is IPaperFigure).ConvertAll(f => f as IPaperFigure);
            }

            throw new Exception("The box is empty");
        }

        public static void WriteFiguresFromBoxToXML(string path, FigureMaterials material, StreamWriter writer) => _streamFileWorker.WriteFiguresFromBoxToXML(path, GetFigruesForSpecifiedMaterial(material), writer);

        public static void WriteFiguresFromBoxToXML(string path, FigureMaterials material, XmlWriter writer) => _xmlFileWorker.WriteFiguresFromBoxToXML(path, GetFigruesForSpecifiedMaterial(material), writer);

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

        public static IEnumerable<IFigure> ReadAllFiguresFromXML(string path, StreamReader reader)
        {
            InitializeFigures(_streamFileWorker.ReadFiguresFromXML(path, reader));
            return Figures;
        }

        public static IEnumerable<IFigure> ReadAllFiguresFromXML(string path, XmlReader reader)
        {
            InitializeFigures(_xmlFileWorker.ReadFiguresFromXML(path, reader));
            return Figures;
        }
    }
}