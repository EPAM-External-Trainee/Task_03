using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.Box;
using Task.Enums;
using Task.Figures.Interfaces;
using Task.Figures.Models.FilmFigures;
using Task.Figures.Models.PaperFigures;

namespace TaskUnitTests.BoxTests
{
    /// <summary>
    /// Testing methods of the <see cref="Box"/> class
    /// </summary>
    [TestClass]
    public class BoxTests
    {
        private static readonly List<IFigure> _figures = new List<IFigure>()
        {
            new PaperCircle(10, Colors.White),
            new PaperRectangle(new List<double>{6, 9}, Colors.Green),
            new PaperSquare(new List<double>{4, 4, 4, 4}, Colors.Red),
            new PaperTriangle(new List<double>{6, 7, 8}, Colors.Blue),
            new FilmCircle(5),
            new FilmRectangle(new List<double>{10, 20}),
            new FilmSquare(new List<double>{7, 7, 7, 7}),
            new FilmTriangle(new List<double>{9, 10, 11}),
        };
        private static readonly string pathToXmlFileForAllFigures = @"..\..\Resources\Figures.xml";
        private static readonly string pathToXmlFileForPaperFigures = @"..\..\Resources\PaperFigures.xml";
        private static readonly string pathToXmlFileForFilmFigures = @"..\..\Resources\FilmFigures.xml";

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext testContext)
        {
            Box.InitializeFigures(_figures);
        }

        [TestCleanup]
        public void TearDown()
        {
            Box.InitializeFigures(_figures);
        }

        [TestMethod, Description("Testing adding a unique figure to a collection")]
        public void AddFigure_UniqFigure_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(5, Colors.Blue);
            Box.AddFigure(paperCircle);
            Assert.AreEqual(paperCircle, Box.ViewFigure(Box.CurrentFiguresCount));
        }

        [TestMethod, Description("Testing adding a non unique figure to the collection")]
        public void AddFigure_NotUniqFigure_ArgumentException()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.ThrowsException<ArgumentException>(() => Box.AddFigure(paperCircle));
        }

        [TestMethod, Description("Testing viewing a figure by the correct number")]
        public void ViewFigure_NumberInRange_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.AreEqual(paperCircle, Box.ViewFigure(1));
        }

        [TestMethod, Description("Testing viewing a figure by an incorrect number")]
        public void ViewFigure_NumberOutOfRange_IndexOutOfRangeException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ViewFigure(21));
        }

        [TestMethod, Description("Testing the figure extraction by the correct number")]
        public void ExtractFigure_NumberInRange_PositiveTestResult()
        {
            int figuresCountBeforeExtract = Box.CurrentFiguresCount;
            Box.ExtractFigure(1);
            Assert.IsTrue(figuresCountBeforeExtract > Box.CurrentFiguresCount);
        }

        [TestMethod, Description("Testing the figure extraction by an incorrect number")]
        public void ExtractFigure_NumberOutOfRange_IndexOutOfRangeException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ExtractFigure(13));
        }

        [TestMethod, Description("Testing the replacement of a figure with the correct number")]
        public void ReplaceFigure__NumberInRange_PositiveTestResult()
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { 6, 9 }, Colors.Green);
            Box.ReplaceFigure(1, paperRectangle);
            Assert.AreEqual(paperRectangle, Box.ViewFigure(1));
        }

        [TestMethod, Description("Testing the replacement of a figure with an incorrect number")]
        public void ReplaceFigure__NumberOutOfRange_IndexOutOfRangeException()
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { 6, 9 }, Colors.Green);
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ReplaceFigure(66, paperRectangle));
        }

        [TestMethod, Description("Testing finding the same figure when there is one in the box")]
        public void FindEqualFigure_DesiredFigureInBox_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.AreEqual(paperCircle, Box.FindEqualFigure(paperCircle));
        }

        [TestMethod, Description("Testing for finding the same figure when it's not in the box")]
        public void FindEqualFigure_DesiredFigureOutOfBox_Null()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.Green);
            Assert.IsNull(Box.FindEqualFigure(paperCircle));
        }

        [TestMethod, Description("Testing finding the current number of figures in a box")]
        public void CurrentFiguresCount_PositiveTestResult()
        {
            Assert.IsTrue(Box.CurrentFiguresCount == 8);
        }

        [TestMethod, Description("Testing finding the total area of all figures in a box")]
        public void TotalArea_PositiveTestResult()
        {
            Assert.IsTrue(774.46d == Box.TotalArea);
        }

        [TestMethod, Description("Testing finding the total perimeter of all figures in a box")]
        public void TotalPerimeter_PositiveTestResult()
        {
            Assert.IsTrue(279.25d == Box.TotalPerimeter);
        }

        [TestMethod, Description("Testing getting all the circles in the box")]
        public void GetAllCircles_CirclesInBox_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new FilmCircle(5)
            };

            CollectionAssert.AreEqual(expectedFigures, Box.GetAllCircles().ToList());
        }

        [TestMethod, Description("Testing getting all the film figures in the box")]
        public void GetAllFilmFigures_FilmFiguresInBox_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new FilmCircle(5),
                new FilmRectangle(new List<double>{10, 20}),
                new FilmSquare(new List<double>{7, 7, 7, 7}),
                new FilmTriangle(new List<double>{9, 10, 11})
            };
            CollectionAssert.AreEqual(expectedFigures, Box.GetAllFilmFigures().ToList());
        }

        [TestMethod, Description("Testing getting all the paper figures in the box")]
        public void GetAllPaperFigures_PaperFiguresInBox_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new PaperRectangle(new List<double>{6, 9}, Colors.Green),
                new PaperSquare(new List<double>{4, 4, 4, 4}, Colors.Red),
                new PaperTriangle(new List<double>{6, 7, 8}, Colors.Blue)
            };

            CollectionAssert.AreEqual(expectedFigures, Box.GetAllPaperFigures().ToList());
        }

        [TestMethod, Description("Testing writing all figures from the box to an xml file using XmlWriter")]
        public void WriteAllFiguresToXml_UsingXmlWriter_PositiveTestResult()
        {
            using (XmlWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForAllFigures, FigureMaterials.PaperAndFilm, writer);
                using (StreamReader reader = null)
                {
                    CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing writing paper figures from the box to an xml file using XmlWriter")]
        public void WritePaperFiguresToXml_UsingXmlWriter_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new PaperRectangle(new List<double>{6, 9}, Colors.Green),
                new PaperSquare(new List<double>{4, 4, 4, 4}, Colors.Red),
                new PaperTriangle(new List<double>{6, 7, 8}, Colors.Blue)
            };

            using (XmlWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForPaperFigures, FigureMaterials.Paper, writer);
                using (StreamReader reader = null)
                {
                    CollectionAssert.AreEqual(expectedFigures, Box.ReadAllFiguresFromXML(pathToXmlFileForPaperFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing writing film figures from the box to an xml file using XmlWriter")]
        public void WriteFilmFiguresToXml_UsingXmlWriter_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new FilmCircle(5),
                new FilmRectangle(new List<double>{10, 20}),
                new FilmSquare(new List<double>{7, 7, 7, 7}),
                new FilmTriangle(new List<double>{9, 10, 11})
            };

            using (XmlWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForFilmFigures, FigureMaterials.Film, writer);
                using (StreamReader reader = null)
                {
                    CollectionAssert.AreEqual(expectedFigures, Box.ReadAllFiguresFromXML(pathToXmlFileForFilmFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing writing all figures from the box to an xml file using StreamWriter")]
        public void WriteAllFiguresToXml_UsingStreamWriter_PositiveTestResult()
        {
            using (StreamWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForAllFigures, FigureMaterials.PaperAndFilm, writer);
                using (XmlReader reader = null)
                {
                    CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing writing film figures from the box to an xml file using StreamWriter")]
        public void WriteFilmFiguresToXml_UsingStreamWriter_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new FilmCircle(5),
                new FilmRectangle(new List<double>{10, 20}),
                new FilmSquare(new List<double>{7, 7, 7, 7}),
                new FilmTriangle(new List<double>{9, 10, 11})
            };

            using (StreamWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForFilmFigures, FigureMaterials.Film, writer);
                using (XmlReader reader = null)
                {
                    CollectionAssert.AreEqual(expectedFigures, Box.ReadAllFiguresFromXML(pathToXmlFileForFilmFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing writing film figures from the box to an xml file using StreamWriter")]
        public void WritePaperFiguresToXml_UsingStreamWriter_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new PaperRectangle(new List<double>{6, 9}, Colors.Green),
                new PaperSquare(new List<double>{4, 4, 4, 4}, Colors.Red),
                new PaperTriangle(new List<double>{6, 7, 8}, Colors.Blue)
            };

            using (StreamWriter writer = null)
            {
                Box.WriteFiguresFromBoxToXML(pathToXmlFileForPaperFigures, FigureMaterials.Paper, writer);
                using (XmlReader reader = null)
                {
                    CollectionAssert.AreEqual(expectedFigures, Box.ReadAllFiguresFromXML(pathToXmlFileForPaperFigures, reader).ToList());
                }
            }
        }

        [TestMethod, Description("Testing reading figures from an xml file to a collection of shapes in a box using XmlReader")]
        public void ReadAllFiguresFromXML_UsingXmlReader_PositiveTestResult()
        {
            using (XmlReader reader = null)
            {
                var tmp = Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList();
                CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
            }
        }

        [TestMethod, Description("Testing reading figures from an xml file to a collection of shapes in a box using StreamReader")]
        public void ReadAllFiguresFromXML_UsingStreamReader_PositiveTestResult()
        {
            using (StreamReader reader = null)
            {
                CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
            }
        }
    }
}