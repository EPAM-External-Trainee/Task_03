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
        [TestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperCircle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            PaperRectangle paperRectangle = new PaperRectangle(new List<double> { 6, 7 }, Colors.Black);
            PaperCircle expectedPaperCircle = new PaperCircle(2, paperRectangle);
            PaperCircle actualPaperCircle = new PaperCircle(2, Colors.Black);
            Assert.AreEqual(expectedPaperCircle, actualPaperCircle);
        }

        [TestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperCircle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            PaperCircle paperCircle = new PaperCircle(2, Task.Enums.Colors.Black);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperCircle(6, paperCircle));
        }

        [TestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Task.Enums.Colors.Black);
            Assert.IsTrue(314.16d == paperCircle.GetArea());
        }

        [TestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Task.Enums.Colors.Black);
            Assert.IsTrue(62.83d == paperCircle.GetPerimeter());
        }

        [TestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.Black);
            paperCircle.PaintOverFigure(Colors.Blue);
            Assert.AreEqual(Colors.Blue, paperCircle.Color);
        }

        [TestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException()
        {
            PaperCircle paperCircle = new PaperCircle(10, Colors.Black);
            paperCircle.PaintOverFigure(Colors.Blue);
            Assert.ThrowsException<IsPaintedException>(() => paperCircle.PaintOverFigure(Colors.Green));
        }
    }
}