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
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmRectangle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            FilmCircle filmCircle = new FilmCircle(5);
            FilmRectangle expectedFilmRectangle = new FilmRectangle(new List<double> { 2, 4 }, filmCircle);
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { 2, 4 });
            Assert.AreEqual(expectedFilmRectangle, actualFilmRectangle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { 2, 4 });
            Assert.ThrowsException<OutOfAreaException>(() => new FilmRectangle(new List<double> { 6, 6 }, actualFilmRectangle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { 2, 4 });
            Assert.IsTrue(8d == actualFilmRectangle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            FilmRectangle actualFilmRectangle = new FilmRectangle(new List<double> { 2, 4 });
            Assert.IsTrue(12d == actualFilmRectangle.GetPerimeter());
        }
    }
}