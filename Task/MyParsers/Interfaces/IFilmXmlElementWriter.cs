using System.IO;
using System.Xml;
using Task.Figures.Abstract.BaseAbstract;

namespace Task.MyParsers.Interfaces
{
    public interface IFilmXmlElementWriter
    {
        void WritePolygonFilmFigure(XmlWriter writer, PolygonFigure polygonFigure);

        void WritePolygonFilmFigure(StreamWriter writer, PolygonFigure polygonFigure);

        void WriteCircularFilmFigure(XmlWriter writer, CircularFigure circularFigure);

        void WriteCircularFilmFigure(StreamWriter writer, CircularFigure circularFigure);
    }
}