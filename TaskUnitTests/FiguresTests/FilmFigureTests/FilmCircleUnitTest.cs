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
        [DataRow(2, 6, 7)]
        [DataRow(3, 11, 19)]
        [DataRow(1, 5, 5)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void FilmCircle_CutFigureSmallerOriginal_PositiveTestResult(double circleRadius, double rectangleFirstSide, double rectangleSecondSide)
        {
            FilmRectangle filmRectangle = new FilmRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide });
            FilmCircle expectedFilmCircle = new FilmCircle(circleRadius, filmRectangle);
            FilmCircle actualFilmCircle = new FilmCircle(circleRadius);
            Assert.AreEqual(expectedFilmCircle, actualFilmCircle);
        }

        [DataRow(2, 6)]
        [DataRow(7, 12)]
        [DataRow(4, 5)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void FilmCircle_CutFigureBiggerOriginal_OutOfAreaException(double firstCircleRadius, double secondCircleRadius)
        {
            FilmCircle filmCircle = new FilmCircle(firstCircleRadius);
            Assert.ThrowsException<OutOfAreaException>(() => new FilmCircle(secondCircleRadius, filmCircle));
        }

        [DataRow(10, 314.16)]
        [DataRow(3, 28.27)]
        [DataRow(12, 452.39)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double circleRadius, double expectedArea)
        {
            FilmCircle filmCircle = new FilmCircle(circleRadius);
            Assert.AreEqual(expectedArea, filmCircle.GetArea());
        }

        [DataRow(10, 62.83)]
        [DataRow(3, 18.85)]
        [DataRow(12, 75.4)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double circleRadius, double expectedPerimter)
        {
            FilmCircle filmCircle = new FilmCircle(circleRadius);
            Assert.AreEqual(expectedPerimter, filmCircle.GetPerimeter());
        }
    }
}