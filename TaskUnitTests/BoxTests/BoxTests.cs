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

        [TestMethod]
        public void AddFigure_UniqFigure_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(5, Colors.Blue);
            Box.AddFigure(paperCircle);
            Assert.AreEqual(paperCircle, Box.ViewFigure(Box.CurrentFiguresCount));
        }

        [TestMethod]
        public void AddFigure_NotUniqFigure_ArgumentException()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.ThrowsException<ArgumentException>(() => Box.AddFigure(paperCircle));
        }

        [TestMethod]
        public void ViewFigure_NumberInRange_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.AreEqual(paperCircle, Box.ViewFigure(1));
        }

        [TestMethod]
        public void ViewFigure_NumberOutOfRange_IndexOutOfRangeException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ViewFigure(21));
        }

        [TestMethod]
        public void ExtractFigure_NumberInRange_PositiveTestResult()
        {
            int figuresCountBeforeExtract = Box.CurrentFiguresCount;
            Box.ExtractFigure(1);
            Assert.IsTrue(figuresCountBeforeExtract > Box.CurrentFiguresCount);
        }

        [TestMethod]
        public void ExtractFigure_NumberOutOfRange_IndexOutOfRangeException()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ExtractFigure(13));
        }

        [TestMethod]
        public void ReplaceFigure__NumberInRange_PositiveTestResult()
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { 6, 9 }, Colors.Green);
            Box.ReplaceFigure(1, paperRectangle);
            Assert.AreEqual(paperRectangle, Box.ViewFigure(1));
        }

        [TestMethod]
        public void ReplaceFigure__NumberOutOfRange_IndexOutOfRangeException()
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { 6, 9 }, Colors.Green);
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ReplaceFigure(66, paperRectangle));
        }

        [TestMethod]
        public void FindEqualFigure_DesiredFigureInBox_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.White);
            Assert.AreEqual(paperCircle, Box.FindEqualFigure(paperCircle));
        }

        [TestMethod]
        public void FindEqualFigure_DesiredFigureOutOfBox_Null()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.Green);
            Assert.IsNull(Box.FindEqualFigure(paperCircle));
        }

        [TestMethod]
        public void CurrentFiguresCount_PositiveTestResult()
        {
            Assert.IsTrue(Box.CurrentFiguresCount == 8);
        }

        [TestMethod]
        public void TotalArea_PositiveTestResult()
        {
            Assert.IsTrue(774.46d == Box.TotalArea);
        }

        [TestMethod]
        public void TotalPerimeter_PositiveTestResult()
        {
            Assert.IsTrue(671.75d == Box.TotalPerimeter);
        }

        [TestMethod]
        public void GetAllCircles_CirclesInBox_PositiveTestResult()
        {
            List<IFigure> expectedFigures = new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new FilmCircle(5)
            };

            CollectionAssert.AreEqual(expectedFigures, Box.GetAllCircles().ToList());
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void ReadAllFiguresFromXML_UsingXmlReader_PositiveTestResult()
        {
            using (XmlReader reader = null)
            {
                var tmp = Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList();
                CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
            }
        }

        [TestMethod]
        public void ReadAllFiguresFromXML_UsingStreamReader_PositiveTestResult()
        {
            using (StreamReader reader = null)
            {
                CollectionAssert.AreEqual(_figures, Box.ReadAllFiguresFromXML(pathToXmlFileForAllFigures, reader).ToList());
            }
        }
    }
}