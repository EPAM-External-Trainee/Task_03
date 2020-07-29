using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Models.PaperFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.PaperFigureTests
{
    [TestClass]
    public class PaperRectangleUnitTest
    {
        [DataRow(5, 2, 4, Colors.White)]
        [DataRow(12, 7, 6, Colors.Blue)]
        [DataRow(3, 2, 3, Colors.Green)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperRectangle_CutFigureSmallerOriginal_PositiveTestResult(double cirlceRadius, double rectangleFirstSide, double rectangleSecondSide, Colors color)
        {
            PaperCircle PaperCircle = new PaperCircle(cirlceRadius, color);
            PaperRectangle expectedPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, PaperCircle);
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, color);
            Assert.AreEqual(expectedPaperRectangle, actualPaperRectangle);
        }

        [DataRow(2, 4, 6, 7, Colors.Black)]
        [DataRow(9, 10, 22, 23, Colors.Blue)]
        [DataRow(3, 4, 7, 8, Colors.Red)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstRectFirstSide, double firstRectSecondSide, double secondRectFirstSide, double secondRectSecondSide, Colors color)
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { firstRectFirstSide, firstRectSecondSide }, color);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperRectangle(new List<double> { secondRectFirstSide, secondRectSecondSide }, actualPaperRectangle));
        }

        [DataRow(2, 4, Colors.Red, 8)]
        [DataRow(9, 10, Colors.Black, 90)]
        [DataRow(3, 4, Colors.White, 12)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, Colors color, double expectedArea)
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, color);
            Assert.AreEqual(expectedArea, actualPaperRectangle.GetArea());
        }

        [DataRow(2, 4, Colors.Black, 12)]
        [DataRow(9, 10, Colors.Blue, 38)]
        [DataRow(3, 4, Colors.White, 14)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, Colors color, double expectedPerimeter)
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, color);
            Assert.AreEqual(expectedPerimeter, actualPaperRectangle.GetPerimeter());
        }

        [DataRow(2, 4, Colors.Black, Colors.Green, Colors.Green)]
        [DataRow(9, 10, Colors.Blue, Colors.Red, Colors.Red)]
        [DataRow(3, 4, Colors.White, Colors.Blue, Colors.Blue)]
        [DataTestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, Colors actualColor, Colors newColor, Colors expectedColor)
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, actualColor);
            actualPaperRectangle.PaintOverFigure(newColor);
            Assert.AreEqual(expectedColor, actualPaperRectangle.Color);
        }

        [DataRow(2, 4, Colors.Black, Colors.Green, Colors.White)]
        [DataRow(9, 10, Colors.Blue, Colors.Red, Colors.Black)]
        [DataRow(3, 4, Colors.White, Colors.Blue, Colors.Red)]
        [DataTestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException(double rectangleFirstSide, double rectangleSecondSide, Colors actualColor, Colors firstNewColor, Colors secondNewColor)
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, actualColor);
            actualPaperRectangle.PaintOverFigure(firstNewColor);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperRectangle.PaintOverFigure(secondNewColor));
        }
    }
}