using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.Enums;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Models.FilmFigures;
using Task.Figures.Models.PaperFigures;
using Task.MyExceptions.Models;

namespace TaskUnitTests.FiguresTests
{
    [TestClass]
    public class FiguresTest
    {
        [TestMethod, Description("")]
        public void PaperTriangle_CutFigureSmallerOriginal_PositiveTestResult()
        {
            PaperCircle paperCircle = new PaperCircle(9, Colors.White);
            PaperTriangle expectedPaperTriangle = new PaperTriangle(new List<double> { 6, 7, 8 }, paperCircle);
            PaperTriangle actualPaperTriangle = new PaperTriangle(new List<double> { 6, 7, 8 }, Colors.White);
            Assert.AreEqual(expectedPaperTriangle, actualPaperTriangle);
        }

        [TestMethod, Description("")]
        public void PaperCircle_CutFigureBiggerOriginal_OutOfAreaException()
        {
            PaperSquare paperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Red);
            Assert.ThrowsException<OutOfAreaException>(() => new PaperCircle(6, paperSquare));
        }

        [TestMethod, Description("")]
        public void GetArea_PositiveTestResult()
        {
            FilmCircle filmCircle = new FilmCircle(10);
            Assert.IsTrue(314.16d == filmCircle.GetArea());
        }

        [TestMethod, Description("")]
        public void GetPerimeter_PositiveTestResult()
        {
            FilmCircle filmCircle = new FilmCircle(10);
            Assert.IsTrue(62.83 == filmCircle.GetPerimeter());
        }

        [TestMethod, Description("")]
        public void PaintOverFigure_PositiveTestResult()
        {
            PaperSquare paperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Black);
            paperSquare.PaintOverFigure(Colors.Blue);
            Assert.AreEqual(Colors.Blue, paperSquare.Color);
        }

        [TestMethod, Description("")]
        public void PaintOverFigure_IsPaintedException()
        {
            PaperSquare paperSquare = new PaperSquare(new List<double> { 2, 2, 2, 2 }, Colors.Black);
            paperSquare.PaintOverFigure(Colors.Blue);
            Assert.ThrowsException<IsPaintedException>(() => paperSquare.PaintOverFigure(Colors.White));
        }
    }
}