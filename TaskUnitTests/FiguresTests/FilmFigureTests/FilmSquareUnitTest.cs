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
        [DataRow(8, 10, 2)]
        [DataRow(12, 7, 3)]
        [DataRow(21, 19, 4)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmSquare_CutFigureSmallerOriginal_PositiveTestResult(double rectFirstSide, double rectSecondSide, double squareSide)
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { rectFirstSide, rectSecondSide });
            FilmSquare expectedFilmSquare = new FilmSquare(new List<double> { squareSide }, filmRectangle);
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { squareSide });
            Assert.AreEqual(expectedFilmSquare, actualFilmSquare);
        }

        [DataRow(2, 5)]
        [DataRow(3, 9)]
        [DataRow(6, 7)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstSquareSide, double secondSquareSide)
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { firstSquareSide });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmSquare(new List<double> { secondSquareSide }, actualFilmSquare));
        }

        [DataRow(2, 4)]
        [DataRow(3, 9)]
        [DataRow(4, 16)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double squareSide, double expectedArea)
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { squareSide });
            Assert.AreEqual(expectedArea, actualFilmSquare.GetArea());
        }

        [DataRow(2, 8)]
        [DataRow(3, 12)]
        [DataRow(4, 16)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double squareSide, double expectedPerimeter)
        {
            FilmSquare actualFilmSquare = new FilmSquare(new List<double> { squareSide });
            Assert.AreEqual(expectedPerimeter, actualFilmSquare.GetPerimeter());
        }
    }
}