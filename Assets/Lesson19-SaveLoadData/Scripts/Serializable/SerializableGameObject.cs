using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SerializableGameObject
{
    public string Name;
    public SerializableVector3 Pos;
    public bool IsEnable;

    public override string ToString()
    {
        return $"Name = {Name}; IsEnable = {IsEnable}; Pos = ({Pos});";
    }
}