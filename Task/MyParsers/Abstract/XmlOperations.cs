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
    /// <summary>
    /// Class that describes main operations with Xml objects to get a different data
    /// </summary>
    public abstract class XmlOperations
    {
        /// <summary>
        /// Parse XmlReader object element content for getting sides
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>Sides collection</returns>
        protected IEnumerable<double> GetSidesFromXml(XmlReader reader)
        {
            reader.ReadToFollowing("Sides");
            return reader.ReadElementContentAsString().Split(' ').ToList().Select(s => double.Parse(s)).ToList();
        }

        /// <summary>
        /// Parse XElement object element content for getting sides
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>Sides collection</returns>
        protected IEnumerable<double> GetSidesFromXml(XElement element) => element.Element("Sides").Value.Split(' ').ToList().Select(s => double.Parse(s)).ToList();

        /// <summary>
        /// Parse XmlReader object element content for getting radius
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>Radius</returns>
        protected double GetRadiusFromXml(XmlReader reader)
        {
            reader.ReadToFollowing("Radius");
            return Convert.ToDouble(reader.ReadElementContentAsString());
        }

        /// <summary>
        /// Parse XElement object element content for getting radius
        /// </summary>
        /// <param name="element">XElement object</param>
        /// <returns>Radius</returns>
        protected double GetRadiusFromXml(XElement element) => Convert.ToDouble(element.Element("Radius").Value);

        /// <summary>
        /// Parse XmlReader object element content for getting color
        /// </summary>
        /// <param name="reader">XmlReader object</param>
        /// <returns>Color</returns>
        protected Colors GetColorFromXml(XmlReader reader)
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Whitespace:
                    {
                        reader.ReadToFollowing("Color");
                        Enum.TryParse(reader.ReadElementContentAsString(), out Colors color);
                        return color;
                    }

                default:
                    {
                        Enum.TryParse(reader.ReadElementContentAsString(), out Colors color);
                        return color;
                    }
            }
        }

        /// <summary>
        /// Parse XElement object element content for getting color
        /// </summary>
        /// <param name="reader">XElement object</param>
        /// <returns>Color</returns>
        protected Colors GetColorFromXml(XElement element)
        {
            Enum.TryParse(element.Element("Color").Value, out Colors color);
            return color;
        }

        /// <summary>
        /// Write figure name to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="figure">The figure whose name should be written</param>
        protected void WriteElementName(XmlWriter writer, Figure figure) => writer.WriteStartElement(figure.GetType().Name);

        /// <summary>
        /// Write figure name to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="figure">The figure whose name should be written</param>
        protected void WriteElementName(StreamWriter writer, Figure figure) => writer.WriteLine($"<{figure.GetType().Name}>");

        /// <summary>
        /// Write end figure name to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="figure">The figure whose end name should be written</param>
        protected void WriteEndElement(StreamWriter writer, Figure figure) => writer.WriteLine($"</{figure.GetType().Name}>");

        /// <summary>
        /// Write figure radius to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="figure">The figure whose radius should be written</param>
        protected void WriteRadius(XmlWriter writer, CircularFigure figure) => writer.WriteElementString(nameof(figure.Radius), figure.Radius.ToString());

        /// <summary>
        /// Write figure radius to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="figure">The figure whose radius should be written</param>
        protected void WriteRadius(StreamWriter writer, CircularFigure figure) => writer.WriteLine($"<{nameof(figure.Radius)}>{figure.Radius}</{nameof(figure.Radius)}>");

        /// <summary>
        ///  Write figure sides to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="figure">The figure whose sides should be written</param>
        protected void WriteSides(XmlWriter writer, PolygonFigure figure) => writer.WriteElementString(nameof(figure.Sides), string.Join(" ", figure.Sides.Select(s => Convert.ToString(s))));

        /// <summary>
        ///  Write figure sides to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="figure">The figure whose sides should be written</param>
        protected void WriteSides(StreamWriter writer, PolygonFigure figure) => writer.WriteLine($"<{nameof(figure.Sides)}>{string.Join(" ", figure.Sides.Select(s => Convert.ToString(s)))}</{nameof(figure.Sides)}>");

        /// <summary>
        /// Write figure color to Xml file using XmlWriter
        /// </summary>
        /// <param name="writer">XmlWriter object</param>
        /// <param name="figure">The figure whose color should be written</param>
        protected void WriteColor(XmlWriter writer, IPaperFigure figure) => writer.WriteElementString(nameof(figure.Color), figure.Color.ToString());

        /// <summary>
        /// Write figure color to Xml file using StreamWriter
        /// </summary>
        /// <param name="writer">StreamWriter object</param>
        /// <param name="figure">The figure whose color should be written</param>
        protected void WriteColor(StreamWriter writer, IPaperFigure figure) => writer.WriteLine($"<{nameof(figure.Color)}>{figure.Color}</{nameof(figure.Color)}>");
    }
}