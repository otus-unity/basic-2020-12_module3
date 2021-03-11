using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData : IData<SerializableGameObject>
{
    public void Save(SerializableGameObject data, string path = null)
    {
        PlayerPrefs.SetString("Name", data.Name);
        PlayerPrefs.SetFloat("PosX", data.Pos.X);
        /*PlayerPrefs.SetFloat("PosY", data.Pos.Y);
        PlayerPrefs.SetFloat("PosZ", data.Pos.Z);*/
        PlayerPrefs.SetString("IsEnable", data.IsEnable.ToString());
        
        PlayerPrefs.Save();
    }

    public SerializableGameObject Load(string path = null)
    {
        var result = new SerializableGameObject();

        var key = "Name";
        result.Name = PlayerPrefs.GetString(key, "DefaultName");
        
        key = "PosX";
        if (PlayerPrefs.HasKey(key))
        {
            result.Pos.X = PlayerPrefs.GetFloat(key);
        }
        
        key = "IsEnable";
        if (PlayerPrefs.HasKey(key))
        {
            result.IsEnable = bool.Parse(PlayerPrefs.GetString(key));
        }

        return result;
    }

    public void Clear()
    {
        PlayerPrefs.DeleteKey("Name");
        PlayerPrefs.DeleteAll();
    }
}
