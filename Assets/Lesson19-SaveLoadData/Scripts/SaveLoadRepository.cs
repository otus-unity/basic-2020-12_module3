using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadRepository : MonoBehaviour
{
    public enum SaveDataType
    {
        playerPrefsData,
        jsonData,
        xmlData
    }

    private GameObject _gameObject;
    private readonly IData<SerializableGameObject> _data;

    private const string _folderName = "saveData";
    private const string _fileName = "data.dat";
    private readonly string _path;

    public SaveLoadRepository(GameObject gameObject, SaveDataType saveDataType)
    {
        _gameObject = gameObject;

        switch (saveDataType)
        {
            case SaveDataType.playerPrefsData:
                _data = new PlayerPrefsData();
                break;
            case SaveDataType.jsonData:
                _data = new JsonData();
                break;
            case SaveDataType.xmlData:
                _data = new XMLData();
                break;
        }

        _path = Path.Combine(Application.dataPath, _folderName);
        Debug.Log("Path = " + _path);
    }

    public void Save()
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }

        var saveObject = new SerializableGameObject
        {
            Name = _gameObject.name,
            Pos = _gameObject.transform.position,
            IsEnable = _gameObject.activeSelf
        };
        
        _data.Save(saveObject, Path.Combine(_path, _fileName));
    }

    public void Load()
    {
        SerializableGameObject saveObject = _data.Load(Path.Combine(_path, _fileName));
        _gameObject.name = saveObject.Name;
        _gameObject.transform.position = saveObject.Pos;
        _gameObject.SetActive(saveObject.IsEnable);
        
        Debug.Log(saveObject);
    }
}
