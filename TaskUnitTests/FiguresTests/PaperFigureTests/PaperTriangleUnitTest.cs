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
        [DataRow(16, 20, 3, 4, 5, Colors.Red)]
        [DataRow(12, 13, 4, 2, 1, Colors.White)]
        [DataRow(9, 10, 5, 6, 7, Colors.Blue)]
        [DataTestMethod, Description("Testing cutting a figure that is smaller than the original one")]
        public void PaperTriangle_CutFigureSmallerOriginal_PositiveTestResult(double rectangleFirstSide, double rectangleSecondSide, double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, Colors color)
        {
            PaperRectangle PaperRectangle = new PaperRectangle(new List<double> { rectangleFirstSide, rectangleSecondSide }, color);
            PaperTriangle expectedPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, PaperRectangle);
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, color);
            Assert.AreEqual(expectedPaperTriangle, actualPaperTriangle);
        }

        [DataRow(3, 4, 5, Colors.Blue, 8, 9, 10)]
        [DataRow(6, 5, 7, Colors.Black, 10, 15, 16)]
        [DataRow(4, 7, 5, Colors.White, 9, 10, 12)]
        [DataTestMethod, Description("Testing cutting a figure that is bigger than the original one")]
        public void PaperRectangle_CutFigureBiggerOriginal_OutOfAreaException(double firstTriangleFirstSide, double firstTriangleSecondSide, double firstTriangleThirdSide, Colors color, double secondTriangleFirstSide, double secondTriangleSecondSide, double secondTriangleThirdSide)
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { firstTriangleFirstSide, firstTriangleSecondSide, firstTriangleThirdSide }, color);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperTriangle(new List<double> { secondTriangleFirstSide, secondTriangleSecondSide, secondTriangleThirdSide }, actualPaperTriangle));
        }

        [DataRow(3, 4, 5, Colors.Red, 6)]
        [DataRow(12, 13, 4, Colors.Blue, 23.89)]
        [DataRow(9, 10, 5, Colors.Black, 22.45)]
        [DataTestMethod, Description("Testing calculating the area of a figure")]
        public void GetArea_PositiveTestResult(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, Colors color, double expectedArea)
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, color);
            Assert.AreEqual(expectedArea, actualPaperTriangle.GetArea());
        }

        [DataRow(3, 4, 5, Colors.Black, 12)]
        [DataRow(12, 13, 4, Colors.Blue, 29)]
        [DataRow(9, 10, 5, Colors.Green, 24)]
        [DataTestMethod, Description("Testing calculating the perimeter of a figure")]
        public void GetPerimeter_PositiveTestResult(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, Colors color, double expectedPerimeter)
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, color);
            Assert.AreEqual(expectedPerimeter, actualPaperTriangle.GetPerimeter());
        }

        [DataRow(3, 4, 5, Colors.Black, Colors.Green, Colors.Green)]
        [DataRow(12, 13, 4, Colors.Blue, Colors.Red, Colors.Red)]
        [DataRow(9, 10, 5, Colors.White, Colors.Blue, Colors.Blue)]
        [DataTestMethod, Description("Testing paint over a figure for the first time")]
        public void PaintOverFigure_PositiveTestResult(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, Colors actualColor, Colors newColor, Colors expectedColor)
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, actualColor);
            actualPaperTriangle.PaintOverFigure(newColor);
            Assert.AreEqual(expectedColor, actualPaperTriangle.Color);
        }

        [DataRow(3, 4, 5, Colors.Black, Colors.Green, Colors.Red)]
        [DataRow(12, 13, 4, Colors.Blue, Colors.Red, Colors.Black)]
        [DataRow(9, 10, 5, Colors.White, Colors.Blue, Colors.Red)]
        [DataTestMethod, Description("Testing paint over the figure a second time")]
        public void PaintOverFigure_IsPaintedException(double triangleFirstSide, double triangleSecondSide, double triangleThirdSide, Colors actualColor, Colors newFirstColor, Colors newSecondColor)
        {
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { triangleFirstSide, triangleSecondSide, triangleThirdSide }, actualColor);
            actualPaperTriangle.PaintOverFigure(newFirstColor);
            Assert.ThrowsException<IsPaintedException>(() => actualPaperTriangle.PaintOverFigure(newSecondColor));
        }
    }
}