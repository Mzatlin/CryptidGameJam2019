using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class DescriptionText : ScriptableObject
{
    public event Action OnDescWrite = delegate { };
    public string description;

    public void WriteDescription(string _description)
    {
        description = _description;
        OnDescWrite();
    }
}
