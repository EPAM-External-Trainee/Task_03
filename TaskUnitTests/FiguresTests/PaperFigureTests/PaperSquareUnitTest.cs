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
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperSquare_CutFigureSmallerOriginal_PositiveTestResult()
        {
            PaperRectangle PaperRectangle = new PaperRectangle(new List<double> { 8, 10 }, Colors.Green);
            PaperSquare expectedPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, PaperRectangle);
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            Assert.AreEqual(expectedPaperSquare, actualPaperSquare);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperSquare(new List<double> { 5, 5, 5, 5 }, actualPaperSquare));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            Assert.IsTrue(4d == actualPaperSquare.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            Assert.IsTrue(8d == actualPaperSquare.GetPerimeter());
        }

        [TestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult()
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            actualPaperSquare.PaintOverFigure(Colors.Blue);
            Assert.AreEqual(Colors.Blue, actualPaperSquare.Color);
        }

        [TestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException()
        {
            PaperSquare actualPaperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Green);
            actualPaperSquare.PaintOverFigure(Colors.Blue);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperSquare.PaintOverFigure(Colors.Green));
        }
    }
}