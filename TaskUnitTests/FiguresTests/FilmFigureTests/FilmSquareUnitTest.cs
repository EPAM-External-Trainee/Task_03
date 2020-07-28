using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Figures.Models.FilmFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.FilmFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="FilmSquare"/> class
    /// </summary>
    [TestClass]
    public class FilmSquareUnitTest
    {
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmSquare_CutFigureSmallerOriginal_PositiveTestResult()
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { 8, 10 });
            FilmSquare expectedFilmSquare = new FilmSquare(new List<double> { 2, 2, 2, 2 }, filmRectangle);
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { 2, 2, 2, 2 });
            Assert.AreEqual(expectedFilmSquare, actualFilmSquare);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { 2, 2, 2, 2 });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmSquare(new List<double> { 5, 5, 5, 5 }, actualFilmSquare));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { 2, 2, 2, 2 });
            Assert.IsTrue(4d == actualFilmSquare.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { 2, 2, 2, 2 });
            Assert.IsTrue(8d == actualFilmSquare.GetPerimeter());
        }
    }
}