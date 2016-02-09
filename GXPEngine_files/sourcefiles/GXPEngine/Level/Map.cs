using System;
using System.Xml.Serialization;

namespace GXPEngine
{
	/// <summary>
	/// Represents a Tiled map.
	/// </summary>
	[XmlRootAttribute("map")]
	public class Map {

		[XmlAttribute("width")]
		public int Width = 0;
		
		[XmlAttribute("height")]
		public int Height = 0;

        [XmlAttribute("tilewidth")]
        public int tileWidth = 0;

        [XmlAttribute("tileheight")]
        public int tileHeight = 0;

        [XmlElement("layer")]
        public Layer[] Layers;

        [XmlElement("objectgroup")]
		public ObjectGroup[] objectGroups;

		public Map () {}
        public override string ToString()
        {
            string objectGroupString = "";
            foreach (ObjectGroup objectGroup in objectGroups)
            {
                objectGroupString += objectGroup.ToString();
            }
            return "width: " + Width + "\nheight: " + Height + "\ntileWidth: " + tileWidth + "\ntileHeight: " + tileHeight +"\n" + objectGroupString;
        }
    }
    [XmlRootAttribute("layer")]
    public class Layer
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlElement("data")]
        public Data Data;

        public Layer() { }
        public override string ToString() { return "\nLayer name: " + Name + Data; }
    }
    [XmlRootAttribute("data")]
    public class Data
    {
        [XmlAttribute("encoding")]
        public string Encoding;

        [XmlText]
        public string innerXML;

        public Data() { }
        public override string ToString() { return "\nEncoding: " + Encoding + "\ninnerXML: " + innerXML; }
    }
    /// <summary>
    /// Represents the Object group tag in a map layer
    /// </summary>
    [XmlRootAttribute("objectgroup")]
	public class ObjectGroup {
		[XmlAttribute("name")]
		public string Name;
		
		[XmlElement("object")]
		public TiledObject[] TiledObject;
        public override string ToString()
        {
            string stringOutput = "";
            foreach (TiledObject tiledObject in TiledObject)
            {
                stringOutput += tiledObject;
            }
            return stringOutput;
        }
    }
	
	/// <summary>
	/// Represents the Object tag in an Object group
	/// </summary>
	[XmlRootAttribute("object")]
	public class TiledObject {
		[XmlAttribute("gid")]
		public int GID;
		[XmlAttribute("x")]
		public int X;
		[XmlAttribute("y")]
		public int Y;
		
		[XmlElement("properties")]
		public Properties Properties;

        public override string ToString()
        {

            return "\nTiledObject GID: " + GID + "\nTiledObject X: " + X + "\nTiledObject Y: " + Y + "\nProperties: " +Properties;
        }
    }
	
	/// <summary>
	/// Represents the Properties container in an Object
	/// </summary>
	[XmlRootAttribute("properties")]
	public class Properties {
		[XmlElement("property")]
		public Property[] Property;
        public override string ToString()
        {
            string properties = "";
            foreach (Property property in Property)
            {
                properties += property;
            }
            return properties;
        }
    }

    /// <summary>
    /// Represents an individual Property in a Properties container.
    /// </summary>
    [XmlRootAttribute("property")]
	public class Property {
		[XmlAttribute("name")]
		public string Name;
		[XmlAttribute("value")]
		public string Value;
        public override string ToString()
        {
            return "\nProperty name: " + Name + "\nProperty value: " + Value;
        }
    }

}


