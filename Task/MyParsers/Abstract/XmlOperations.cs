using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Task.Enums;
using Task.Figures.Abstract.BaseAbstract;
using Task.Figures.Interfaces;

namespace Task.MyParsers.Abstract
{
    public abstract class XmlOperations
    {
        protected IEnumerable<double> GetSidesFromXml(XmlReader reader)
        {
            reader.ReadToFollowing("Sides");
            return reader.ReadElementContentAsString().Split(' ').ToList().Select(s => double.Parse(s)).ToList();
        }

        protected IEnumerable<double> GetSidesFromXml(XElement element) => element.Element("Sides").Value.Split(' ').ToList().Select(s => double.Parse(s)).ToList();

        protected double GetRadiusFromXml(XmlReader reader)
        {
            reader.ReadToFollowing("Radius");
            return Convert.ToDouble(reader.ReadElementContentAsString());
        }

        protected double GetRadiusFromXml(XElement element) => Convert.ToDouble(element.Element("Radius").Value);

        protected Colors GetColorFromXml(XmlReader reader)
        {
            reader.ReadToFollowing("Color");
            Enum.TryParse(reader.ReadElementContentAsString(), out Colors color);
            return color;
        }

        protected Colors GetColorFromXml(XElement element)
        {
            Enum.TryParse(element.Element("Color").Value, out Colors color);
            return color;
        }

        protected void WriteElementName(XmlWriter writer, Figure figure) => writer.WriteStartElement(figure.GetType().Name);

        protected void WriteElementName(StreamWriter writer, Figure figure) => writer.WriteLine($"<{figure.GetType().Name}>");

        protected void WriteEndElement(StreamWriter writer, Figure figure) => writer.WriteLine($"</{figure.GetType().Name}>");

        protected void WriteRadius(XmlWriter writer, CircularFigure figure) => writer.WriteElementString(nameof(figure.Radius), figure.Radius.ToString());

        protected void WriteRadius(StreamWriter writer, CircularFigure figure) => writer.WriteLine($"<{nameof(figure.Radius)}>{figure.Radius}</{nameof(figure.Radius)}>");

        protected void WriteSides(XmlWriter writer, PolygonFigure figure) => writer.WriteElementString(nameof(figure.Sides), string.Join(" ", figure.Sides.Select(s => Convert.ToString(s))));

        protected void WriteSides(StreamWriter writer, PolygonFigure figure) => writer.WriteLine($"<{nameof(figure.Sides)}>{string.Join(" ", figure.Sides.Select(s => Convert.ToString(s)))}</{nameof(figure.Sides)}>");

        protected void WriteColor(XmlWriter writer, IPaperFigure figure) => writer.WriteElementString(nameof(figure.Color), figure.Color.ToString());

        protected void WriteColor(StreamWriter writer, IPaperFigure figure) => writer.WriteLine($"<{nameof(figure.Color)}>{figure.Color}</{nameof(figure.Color)}>");
    }
}