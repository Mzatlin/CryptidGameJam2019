﻿using System;
using UnityEngine;

public class CursorVisibility : MonoBehaviour
{
    PauseHandler pause, unpause;
    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<PauseHandler>();
        pause.OnPause += HandlePause;
        unpause = GetComponent<PauseHandler>();
        unpause.OnUnpause += HandleUnPause;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void HandleUnPause()
    {
        Cursor.visible = false;
    }

    private void HandlePause()
    {
        Cursor.visible = true;
    }
}
