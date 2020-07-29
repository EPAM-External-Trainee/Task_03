using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Figures.Models.FilmFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.FilmFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="FilmTriangle"/> class
    /// </summary>
    [TestClass]
    public class FilmTriangleUnitTest
    {
        [DataRow(16, 20, 3, 4, 5)]
        [DataRow(12, 13, 4, 2, 1)]
        [DataRow(9, 10, 5, 6, 7)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmTriangle_CutFigureSmallerOriginal_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, double triangleFirstSide, double triangleSecondSide, double triangleThirdSide)
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide });
            FilmTriangle expectedFilmTriangle = new FilmTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, filmRectangle);
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide });
            Assert.AreEqual(expectedFilmTriangle, actualFilmTriangle);
        }

        [DataRow(3, 4, 5, 8, 9, 10)]
        [DataRow(6, 5, 7, 10, 15, 16)]
        [DataRow(4, 7, 5, 9, 10, 12)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstTriangleFirstSide, double firstTriangleSecondSide, double firstTriangleThirdSide, double secondTriangleFirstSide, double secondTriangleSecondSide, double secondTriangleThirdSide)
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { firstTriangleFirstSide, firstTriangleSecondSide, firstTriangleThirdSide });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmTriangle(new List<double> { secondTriangleFirstSide, secondTriangleSecondSide, secondTriangleThirdSide }, actualFilmTriangle));
        }

        [DataRow(3, 4, 5, 6)]
        [DataRow(12, 13, 4, 23.89)]
        [DataRow(9, 10, 5, 22.45)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, double expectedArea)
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide });
            Assert.AreEqual(expectedArea, actualFilmTriangle.GetArea());
        }

        [DataRow(3, 4, 5, 12)]
        [DataRow(12, 13, 4, 29)]
        [DataRow(9, 10, 5, 24)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, double expectedPerimeter)
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide });
            Assert.AreEqual(expectedPerimeter, actualFilmTriangle.GetPerimeter());
        }
    }
}