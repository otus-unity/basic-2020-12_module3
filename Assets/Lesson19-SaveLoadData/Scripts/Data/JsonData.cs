using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonData : IData<SerializableGameObject>
{
    public void Save(SerializableGameObject data, string path = null)
    {
        var str = JsonUtility.ToJson(data);
        File.WriteAllText(path, str);
    }

    public SerializableGameObject Load(string path = null)
    {
        var str = File.ReadAllText(path);
        return JsonUtility.FromJson<SerializableGameObject>(str);
    }
}