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
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmTriangle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { 16, 20 });
            FilmTriangle expectedFilmTriangle = new FilmTriangle(new List<double> { 3, 4, 5 }, filmRectangle);
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { 3, 4, 5 });
            Assert.AreEqual(expectedFilmTriangle, actualFilmTriangle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { 3, 4, 5 });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmTriangle(new List<double> { 8, 9, 10 }, actualFilmTriangle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { 3, 4, 5 });
            Assert.IsTrue(6d == actualFilmTriangle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            FilmTriangle actualFilmTriangle = new FilmTriangle(new List<double> { 3, 4, 5 });
            Assert.IsTrue(12d == actualFilmTriangle.GetPerimeter());
        }
    }
}