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
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperRectangle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            PaperCircle PaperCircle = new PaperCircle(5, Colors.White);
            PaperRectangle expectedPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, PaperCircle);
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.White);
            Assert.AreEqual(expectedPaperRectangle, actualPaperRectangle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.Red);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperRectangle(new List<double> { 6, 6 }, actualPaperRectangle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.Red);
            Assert.IsTrue(8d == actualPaperRectangle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.Red);
            Assert.IsTrue(12d == actualPaperRectangle.GetPerimeter());
        }

        [TestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult()
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.Red);
            actualPaperRectangle.PaintOverFigure(Colors.Blue);
            Assert.AreEqual(Colors.Blue, actualPaperRectangle.Color);
        }

        [TestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException()
        {
            PaperRectangle actualPaperRectangle = new PaperRectangle(new List<double> { 2, 4 }, Colors.Red);
            actualPaperRectangle.PaintOverFigure(Colors.Blue);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperRectangle.PaintOverFigure(Colors.Green));
        }
    }
}