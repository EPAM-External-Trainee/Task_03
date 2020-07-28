using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Figures.Models.FilmFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.FilmFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="FilmCircle"/> class
    /// </summary>
    [TestClass]
    public class FilmCircleUnitTest
    {
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmCircle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { 6, 7, 8 });
            FilmCircle expectedFilmCircle = new FilmCircle(2, filmRectangle);
            FilmCircle actualFilmCircle = new FilmCircle(2);
            Assert.AreEqual(expectedFilmCircle, actualFilmCircle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmCircle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            FilmCircle filmCircle = new FilmCircle(2);
            Assert.ThrowsException<OutOfAreaException>(() => new FilmCircle(6, filmCircle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            FilmCircle filmCircle = new FilmCircle(10);
            Assert.IsTrue(314.16d == filmCircle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            FilmCircle filmCircle = new FilmCircle(10);
            Assert.IsTrue(62.83d == filmCircle.GetPerimeter());
        }
    }
}