using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class MessageBoxText : ScriptableObject
{
    public event Action OnWriteDialog = delegate { };
    public List<string> dialogMessages;
    public void WriteDialog(List<string> _dialog)
    {
        dialogMessages = _dialog;
        OnWriteDialog();
    }
}
