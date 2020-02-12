﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseHandler : MonoBehaviour
{
    public event Action OnUnpause = delegate { };

    [SerializeField]
    Canvas pauseCanvas;
    PauseController controller;
    ResumeButton resume;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PauseController>();
        controller.OnPause += HandlePause;

        resume = GetComponentInChildren<ResumeButton>();
        resume.OnResume += HandlePause;

        pauseCanvas.enabled = false;
    }

    void HandlePause()
    {
        if (pauseCanvas.enabled)
        {
            pauseCanvas.enabled = false;
            Time.timeScale = 1;
            OnUnpause();
        }
        else
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }
}
