using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    public KeyCode saveKeyCode;
    public KeyCode loadKeyCode;
    public GameObject gameObject;

    private SaveLoadRepository _saveLoadRepository;
    
    void Start()
    {
        _saveLoadRepository = new SaveLoadRepository(gameObject, SaveLoadRepository.SaveDataType.xmlData);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(saveKeyCode))
        {
            _saveLoadRepository.Save();
        }

        if (Input.GetKeyDown(loadKeyCode))
        {
            _saveLoadRepository.Load();
        }
    }
}
