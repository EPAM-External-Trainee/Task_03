using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Models.PaperFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.PaperFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="PaperSquare"/> class
    /// </summary>
    [TestClass]
    public class PaperSquareUnitTest
    {
        [DataRow(8, 10, Colors.Green, 2)]
        [DataRow(12, 7, Colors.Blue, 3)]
        [DataRow(21, 19, Colors.Red, 4)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperSquare_CutFigureSmallerOriginal_PositiveTestResult(double rectFirstSide, double rectSecondSide, Colors color, double squareSide)
        {
            PaperRectangle PaperRectangle = new PaperRectangle(new List<double> { rectFirstSide, rectSecondSide }, color);
            PaperSquare expectedPaperSquare = new PaperSquare(new List<double> { squareSide }, PaperRectangle);
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { squareSide }, color);
            Assert.AreEqual(expectedPaperSquare, actualPaperSquare);
        }

        [DataRow(2, Colors.Blue, 5)]
        [DataRow(3, Colors.Green, 9)]
        [DataRow(6, Colors.Black, 7)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstSquareSide, Colors color, double secondSquareSide)
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { firstSquareSide }, color);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperSquare(new List<double> { secondSquareSide }, actualPaperSquare));
        }

        [DataRow(2, Colors.Red, 4)]
        [DataRow(3, Colors.Black, 9)]
        [DataRow(4, Colors.Blue, 16)]
        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double squareSide, Colors color, double expectedArea)
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { squareSide }, color);
            Assert.AreEqual(expectedArea, actualPaperSquare.GetArea());
        }

        [DataRow(2, Colors.Black, 8)]
        [DataRow(3, Colors.Green, 12)]
        [DataRow(4, Colors.White, 16)]
        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double squareSide, Colors color, double expectedPerimeter)
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { squareSide }, color);
            Assert.AreEqual(expectedPerimeter, actualPaperSquare.GetPerimeter());
        }

        [DataRow(2, Colors.Black, Colors.Green, Colors.Green)]
        [DataRow(9, Colors.Blue, Colors.Red, Colors.Red)]
        [DataRow(3, Colors.White, Colors.Blue, Colors.Blue)]
        [DataTestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult(double squareSide, Colors actualColor, Colors newColor, Colors expectedColor)
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { squareSide }, actualColor);
            actualPaperSquare.PaintOverFigure(newColor);
            Assert.AreEqual(expectedColor, actualPaperSquare.Color);
        }

        [DataRow(2, Colors.Black, Colors.Green, Colors.Blue)]
        [DataRow(9, Colors.Blue, Colors.Red, Colors.Green)]
        [DataRow(3, Colors.White, Colors.Blue, Colors.Red)]
        [DataTestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException(double squareSide, Colors actualColor, Colors newFirstColor, Colors newSecondColor)
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { squareSide }, actualColor);
            actualPaperSquare.PaintOverFigure(newFirstColor);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperSquare.PaintOverFigure(newSecondColor));
        }
    }
}