using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Figures.Models.FilmFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.FilmFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="FilmRectangle"/> class
    /// </summary>
    [TestClass]
    public class FilmRectangleUnitTest
    {
        [DataRow(5, 2, 4)]
        [DataRow(12, 7, 6)]
        [DataRow(3, 2, 3)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmRectangle_CutFigureSmallerOriginal_PositiveTestResult(double cirlceRadius, double rectangleFirstSide, double rectangleSecondSide)
        {
            FilmCircle filmCircle = new FilmCircle(cirlceRadius);
            FilmRectangle expectedFilmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, filmCircle);
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide });
            Assert.AreEqual(expectedFilmRectangle, actualFilmRectangle);
        }

        [DataRow(2, 4, 6, 7)]
        [DataRow(9, 10, 22, 23)]
        [DataRow(3, 4, 7, 8)]
        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstRectFirstSide, double firstRectSecondSide, double secondRectFirstSide, double secondRectSecondSide)
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { firstRectFirstSide, firstRectSecondSide });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmRectangle(new List<double> { secondRectFirstSide, secondRectSecondSide }, actualFilmRectangle));
        }

        [DataRow(2, 4, 8)]
        [DataRow(9, 10, 90)]
        [DataRow(3, 4, 12)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, double expectedArea)
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide });
            Assert.AreEqual(expectedArea, actualFilmRectangle.GetArea());
        }

        [DataRow(2, 4, 12)]
        [DataRow(9, 10, 38)]
        [DataRow(3, 4, 14)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, double expectedPerimeter)
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide });
            Assert.AreEqual(expectedPerimeter, actualFilmRectangle.GetPerimeter());
        }
    }
}