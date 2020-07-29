using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Models.PaperFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.PaperFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="PaperCircle"/> class
    /// </summary>
    [TestClass]
    public class PaperCircleUnitTest
    {
        [DataRow(6, 7, Colors.Black, 2)]
        [DataRow(11, 19, Colors.Blue, 3)]
        [DataRow(5, 5, Colors.Green, 1)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperCircle_CutFigureSmallerOriginal_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, Colors color, double circleRadius)
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, color);
            PaperCircle expectedPaperCircle = new PaperCircle(circleRadius, paperRectangle);
            PaperCircle actualPaperCircle = new PaperCircle(circleRadius, color);
            Assert.AreEqual(expectedPaperCircle, actualPaperCircle);
        }

        [DataRow(2, Colors.Black, 6)]
        [DataRow(7, Colors.Red, 12)]
        [DataRow(4, Colors.White, 5)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperCircle_CutFigureBiggerOriginal_OutOfAreaException(double firstCircleRadius, Colors color, double secondCircleRadius)
        {
            PaperCircle paperCircle = new PaperCircle(firstCircleRadius, color);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperCircle(secondCircleRadius, paperCircle));
        }

        [DataRow(10, Colors.Green, 314.16)]
        [DataRow(3, Colors.Blue, 28.27)]
        [DataRow(12, Colors.Black, 452.39)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double circleRadius, Colors color, double expectedArea)
        {
            PaperCircle paperCircle = new PaperCircle(circleRadius, color);
            Assert.AreEqual(expectedArea, paperCircle.GetArea());
        }

        [DataRow(10, Colors.Black, 62.83)]
        [DataRow(3, Colors.Green, 18.85)]
        [DataRow(12, Colors.Blue, 75.4)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double circleRadius, Colors color, double expectedPerimeter)
        {
            PaperCircle paperCircle = new PaperCircle(circleRadius, color);
            Assert.AreEqual(expectedPerimeter, paperCircle.GetPerimeter());
        }

        [DataRow(10, Colors.Black, Colors.White, Colors.White)]
        [DataRow(3, Colors.Green, Colors.Red, Colors.Red)]
        [DataRow(12, Colors.Blue, Colors.Black, Colors.Black)]
        [DataTestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult(double circleRadius, Colors actualColor, Colors newColor, Colors expectedColor)
        {
            PaperCircle paperCircle = new PaperCircle(circleRadius, actualColor);
            paperCircle.PaintOverFigure(newColor);
            Assert.AreEqual(expectedColor, paperCircle.Color);
        }

        [DataRow(10, Colors.Black, Colors.White, Colors.Red)]
        [DataRow(3, Colors.Green, Colors.Red, Colors.Black)]
        [DataRow(12, Colors.Blue, Colors.Black, Colors.White)]
        [TestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException(double circleRadius, Colors actualColor, Colors firstNewColor, Colors secondNewColor)
        {
            PaperCircle paperCircle = new PaperCircle(circleRadius, actualColor);
            paperCircle.PaintOverFigure(firstNewColor);
            Assert.ThrowsException<IsPaintedException>(() => paperCircle.PaintOverFigure(secondNewColor));
        }
    }
}