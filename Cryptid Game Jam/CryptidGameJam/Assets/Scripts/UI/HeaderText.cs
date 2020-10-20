using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class HeaderText : ScriptableObject
{
    public event Action OnWrite = delegate { };
    public string message;
    
    public void WriteHeader(string _header)
    {
        message = _header;
        OnWrite();
    }

}
