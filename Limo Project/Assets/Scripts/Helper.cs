using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

public class Helper {

    public string CreateXML (object obj) {
        using (var stream = new MemoryStream()) {
            using (var reader = new StreamReader(stream)) {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stream, obj);
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }

    public List<XmlModel> DeserializeXML (string fileLocation) {
        XmlSerializer serializer = new XmlSerializer(typeof(List<XmlModel>));
        try {
            StreamReader sr = new StreamReader(fileLocation);
            List<XmlModel> list = (List<XmlModel>) serializer.Deserialize(sr);
            sr.Close();
            return list;
        } catch (Exception e) {
            StateManager.instance.ShowError();
            return null;
        }

    }

    public bool SaveFile (string fileLocation, string content) {
        using (StreamWriter sw = new StreamWriter(fileLocation))
            sw.WriteLine(content);

        return true;
    }


}
