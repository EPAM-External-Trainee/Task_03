using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task.Enums;
using Task.Figures.Models.PaperFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests.PaperFigureTests
{
    /// <summary>
    /// Testing methods of the <see cref="PaperTriangle"/> class
    /// </summary>
    [TestClass]
    public class PaperTriangleUnitTest
    {
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperTriangle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            PaperRectangle PaperRectangle = new PaperRectangle(new List<double> { 16, 20 }, Colors.Blue);
            PaperTriangle expectedPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, PaperRectangle);
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.Blue);
            Assert.AreEqual(expectedPaperTriangle, actualPaperTriangle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.Blue);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperTriangle(new List<double> { 8, 9, 10 }, actualPaperTriangle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.Blue);
            Assert.IsTrue(6d == actualPaperTriangle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.Blue);
            Assert.IsTrue(12d == actualPaperTriangle.GetPerimeter());
        }

        [TestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult()
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.White);
            actualPaperTriangle.PaintOverFigure(Colors.Blue);
            Assert.AreEqual(Colors.Blue, actualPaperTriangle.Color);
        }

        [TestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException()
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 3, 4, 5 }, Colors.White);
            actualPaperTriangle.PaintOverFigure(Colors.Blue);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperTriangle.PaintOverFigure(Colors.Green));
        }
    }
}
