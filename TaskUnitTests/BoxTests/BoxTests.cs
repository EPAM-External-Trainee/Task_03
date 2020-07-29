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
            new PaperRectangle(new List<double> { 6, 9 }, Colors.Green),
            new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red),
            new PaperTriangle(new List<double> { 6, 7, 8 }, Colors.Blue),
            new FilmCircle(5),
            new FilmRectangle(new List<double>{ 10, 20 }),
            new FilmSquare(new List<double> { 7, 7, 7, 7 }),
            new FilmTriangle(new List<double> { 9, 10, 11 }),
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

        [DataTestMethod, Description("Testing adding a unique figure to a collection")]
        [DynamicData(nameof(GetFiguresForTestingAddUniqFigureMethod), DynamicDataSourceType.Method)]
        public void AddFigure_UniqFigure_PositiveTestResult(IFigure figure)
        {
            Box.AddFigure(figure);
            Assert.AreEqual(figure, Box.ViewFigure(Box.CurrentFiguresCount));
        }

        /// <summary>
        /// Creating uniq figures for testing AddFigure method
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingAddUniqFigureMethod()
        {
            yield return new object[] { new PaperCircle(5, Colors.Blue) };
            yield return new object[] { new FilmRectangle(new List<double> { 5, 6 }) };
            yield return new object[] { new PaperSquare(new List<double> { 5 }, Colors.Green) };
            yield return new object[] { new FilmTriangle(new List<double> { 5, 6, 7 }) };
        }

        [DataTestMethod, Description("Testing adding a non unique figure to the collection")]
        [DynamicData(nameof(GetFiguresForTestingAddNonUniqFigureMethod), DynamicDataSourceType.Method)]
        public void AddFigure_NotUniqFigure_ArgumentException(IFigure figure)
        {
            Assert.ThrowsException<ArgumentException>(() => Box.AddFigure(figure));
        }

        /// <summary>
        /// Creating non uniq figures for testing AddFigure method
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingAddNonUniqFigureMethod()
        {
            yield return new object[] { new PaperCircle(10, Colors.White) };
            yield return new object[] { new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { new FilmTriangle(new List<double> { 9, 10, 11 }) };
        }

        [DataTestMethod, Description("Testing viewing a figure by the correct number")]
        [DynamicData(nameof(GetFiguresForTestingViewFigureMethodWithCorrectNumber), DynamicDataSourceType.Method)]
        public void ViewFigure_NumberInRange_PositiveTestResult(int number, IFigure expectedFigure)
        {
            Assert.AreEqual(expectedFigure, Box.ViewFigure(number));
        }

        /// <summary>
        /// Creating figures for testing ViewFigure method with correct number 
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingViewFigureMethodWithCorrectNumber()
        {
            yield return new object[] { 1, new PaperCircle(10, Colors.White) };
            yield return new object[] { 6, new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { 3, new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { 8, new FilmTriangle(new List<double> { 9, 10, 11 }) };
        }

        [DataRow(22)]
        [DataRow(41)]
        [DataRow(190)]
        [DataTestMethod, Description("Testing viewing a figure by an incorrect number")]
        public void ViewFigure_NumberOutOfRange_IndexOutOfRangeException(int number)
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ViewFigure(number));
        }

        [DataTestMethod, Description("Testing the figure extraction by the correct number")]
        [DynamicData(nameof(GetFiguresForTestingExtractFigureMethodWithCorrectNumber), DynamicDataSourceType.Method)]
        public void ExtractFigure_NumberInRange_PositiveTestResult(int number, IFigure expectedFigure)
        {
            int figuresCountBeforeExtract = Box.CurrentFiguresCount;
            Assert.AreEqual(expectedFigure, Box.ExtractFigure(number));
            Assert.IsTrue(figuresCountBeforeExtract > Box.CurrentFiguresCount);
        }

        /// <summary>
        /// Creating figures for testing ExtractFigure method with correct number 
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingExtractFigureMethodWithCorrectNumber()
        {
            yield return new object[] { 1, new PaperCircle(10, Colors.White) };
            yield return new object[] { 6, new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { 3, new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { 8, new FilmTriangle(new List<double> { 9, 10, 11 }) };
        }

        [DataRow(25)]
        [DataRow(125)]
        [DataRow(325)]
        [DataTestMethod, Description("Testing the figure extraction by an incorrect number")]
        public void ExtractFigure_NumberOutOfRange_IndexOutOfRangeException(int number)
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ExtractFigure(number));
        }

        [DataTestMethod, Description("Testing the replacement of a figure with the correct number")]
        [DynamicData(nameof(GetFiguresForTestingReplaceFigureMethodWithCorrectNumber), DynamicDataSourceType.Method)]
        public void ReplaceFigure__NumberInRange_PositiveTestResult(int number, IFigure newFigure)
        {
            Box.ReplaceFigure(number, newFigure);
            Assert.AreEqual(newFigure, Box.ViewFigure(number));
        }

        /// <summary>
        /// Creating figures for testing ReplaceFigure method with correct number 
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingReplaceFigureMethodWithCorrectNumber()
        {
            yield return new object[] { 1, new FilmTriangle(new List<double> { 9, 10, 11 }) };
            yield return new object[] { 6, new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { 3, new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { 8, new PaperCircle(10, Colors.White) };
        }

        [DataTestMethod, Description("Testing the replacement of a figure with an incorrect number")]
        [DynamicData(nameof(GetFiguresForTestingReplaceFigureMethodWithIncorrectNumber), DynamicDataSourceType.Method)]
        public void ReplaceFigure__NumberOutOfRange_IndexOutOfRangeException(int number, IFigure newFigure)
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => Box.ReplaceFigure(number, newFigure));
        }

        /// <summary>
        /// Creating figures for testing ReplaceFigure method with correct number 
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingReplaceFigureMethodWithIncorrectNumber()
        {
            yield return new object[] { 133, new FilmTriangle(new List<double> { 9, 10, 11 }) };
            yield return new object[] { 666, new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { 35, new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { 81, new PaperCircle(10, Colors.White) };
        }

        [DataTestMethod, Description("Testing finding the same figure when there is one in the box")]
        [DynamicData(nameof(GetFiguresForTestingFindEqualFigureMethodDesiredFigureInBox), DynamicDataSourceType.Method)]
        public void FindEqualFigure_DesiredFigureInBox_PositiveTestResult(IFigure desiredFigure, IFigure expectedFiugre)
        {
            Assert.AreEqual(expectedFiugre, Box.FindEqualFigure(desiredFigure));
        }

        /// <summary>
        /// Creating figures for testing FindEqualFigure method for case when desired figure is in box
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingFindEqualFigureMethodDesiredFigureInBox()
        {
            yield return new object[] { new PaperCircle(10, Colors.White), new PaperCircle(10, Colors.White) };
            yield return new object[] { new FilmRectangle(new List<double> { 10, 20 }), new FilmRectangle(new List<double> { 10, 20 }) };
            yield return new object[] { new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red), new PaperSquare(new List<double> { 4, 4, 4, 4 }, Colors.Red) };
            yield return new object[] { new FilmTriangle(new List<double> { 9, 10, 11 }), new FilmTriangle(new List<double> { 9, 10, 11 }) };
        }

        [DataTestMethod, Description("Testing for finding the same figure when it's not in the box")]
        [DynamicData(nameof(GetFiguresForTestingFindEqualFigureMethodDesiredFigureOutOfBox), DynamicDataSourceType.Method)]
        public void FindEqualFigure_DesiredFigureOutOfBox_Null(IFigure desiredFigure)
        {
            Assert.IsNull(Box.FindEqualFigure(desiredFigure));
        }

        /// <summary>
        /// Creating figures for testing FindEqualFigure method for case when desired figure is out of box
        /// </summary>
        /// <returns>Figure object</returns>
        private static IEnumerable<object[]> GetFiguresForTestingFindEqualFigureMethodDesiredFigureOutOfBox()
        {
            yield return new object[] { new PaperCircle(11, Colors.White)};
            yield return new object[] { new FilmRectangle(new List<double> { 101, 20 })};
            yield return new object[] { new PaperSquare(new List<double> { 5 }, Colors.Red) };
            yield return new object[] { new FilmTriangle(new List<double> { 9, 10, 12 }) };
        }

        [DataTestMethod, Description("Testing finding the current number of figures in a box")]
        [DynamicData(nameof(GetFiguresForTestingCurrentFiguresCountProperty), DynamicDataSourceType.Method)]
        public void CurrentFiguresCount_PositiveTestResult(IEnumerable<IFigure> figures, int expectedFiguresCount)
        {
            Box.InitializeFigures(figures);
            Assert.AreEqual(expectedFiguresCount, Box.CurrentFiguresCount);
        }

        /// <summary>
        /// Creating figures for testing CurrentFiguresCount property
        /// </summary>
        /// <returns>Figures collection</returns>
        private static IEnumerable<object[]> GetFiguresForTestingCurrentFiguresCountProperty()
        {
            yield return new object[] { new List<IFigure> 
            {
                new PaperCircle(11, Colors.White), 
                new FilmRectangle(new List<double> { 101, 20 }) },
                2 
            };

            yield return new object[] { new List<IFigure> 
            { 
                new PaperCircle(12, Colors.White) }, 
                1 
            };

            yield return new object[] { new List<IFigure>
            {
                new PaperCircle(10, Colors.White),
                new FilmRectangle(new List<double> { 12, 20 }),
                new PaperSquare(new List<double> { 3 }, Colors.Red) },
                3
            };
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