using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("MyXmlContext")]
public class XmlModel {

    [XmlElement("Location")]
    public List<Vector2D> Location { get; set; }

    [XmlElement("ObjectType")]
    public ObjectTypes ObjectType { get; set; }
}


[Serializable]
public enum ObjectTypes {

    Monster,
    Coin,
    Meteor,
    Box

}
