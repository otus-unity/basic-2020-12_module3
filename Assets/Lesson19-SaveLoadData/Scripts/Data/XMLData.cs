using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml;

public class XMLData : IData<SerializableGameObject>
{
    public void Save(SerializableGameObject data, string path = null)
    {
        var xmlDoc = new XmlDocument();

        XmlNode rootNode = xmlDoc.CreateElement("Object");
        xmlDoc.AppendChild(rootNode);

        var element = xmlDoc.CreateElement("Name");
        element.SetAttribute("value", data.Name);
        rootNode.AppendChild(element);
        
        element = xmlDoc.CreateElement("PosX");
        element.SetAttribute("value", data.Pos.X.ToString());
        rootNode.AppendChild(element);
        
        element = xmlDoc.CreateElement("IsEnable");
        element.SetAttribute("value", data.IsEnable.ToString());
        rootNode.AppendChild(element);
        
        xmlDoc.Save(path);
    }

    public SerializableGameObject Load(string path = null)
    {
        var result = new SerializableGameObject();
        if (!File.Exists(path)) return result;

        using (var reader = new XmlTextReader(path))
        {
            while (reader.Read())
            {
                var key = "Name";
                if (reader.IsStartElement(key))
                {
                    result.Name = reader.GetAttribute("value");
                }
                key = "PosX";
                if (reader.IsStartElement(key))
                {
                    result.Pos.X = float.Parse(reader.GetAttribute("value"));
                }
                key = "IsEnable";
                if (reader.IsStartElement(key))
                {
                    result.IsEnable = bool.Parse(reader.GetAttribute("value"));
                }
            }
        }

        return result;
    }
}
