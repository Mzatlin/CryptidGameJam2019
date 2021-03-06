﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandleDialogInteraction : MonoBehaviour
{
    public event Action OnClosed = delegate { };


    [SerializeField]
    MessageBoxText writer;
    [SerializeField]
    List<string> dialog = new List<string>();
    InteractionController interact;
    bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
        writer.OnFinish += HandleClosedDialog;
        isTalking = false;
    }

    void HandleInteract()
    {
        isTalking = true;
        writer.WriteDialog(dialog);
    }

    void HandleClosedDialog()
    {
        if (isTalking)
        {
            isTalking = false;
            OnClosed();
        }

    }

}
