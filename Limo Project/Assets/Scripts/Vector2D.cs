using System;
using System.Xml;
using System.Xml.Serialization;


[Serializable]
[XmlRoot("Vector2")]
public class Vector2D {

    [XmlElement("X")]
    public float X { get; set; }
    [XmlElement("Y")]
    public float Y { get; set; }

}
