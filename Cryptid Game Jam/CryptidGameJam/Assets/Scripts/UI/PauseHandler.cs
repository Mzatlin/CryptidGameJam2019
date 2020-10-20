using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    public event Action OnUnpause = delegate { };
    public event Action OnPause = delegate { };

    [SerializeField]
    Canvas pauseCanvas;
    PauseController controller;
    ResumeButton resume;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PauseController>();
        controller.OnPause += HandlePause;

        resume = GetComponentInChildren<ResumeButton>();
        resume.OnResume += HandleUnPause;

        button = GetComponentInChildren<Button>();
        button.interactable = false;

        pauseCanvas.enabled = false;
    }

    void HandleUnPause()
    {
        PauseController.isPaused = false;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
        button.interactable = false;
        OnUnpause();
    }

    void HandlePause()
    {
        if (PauseController.isPaused)
        {
            HandleUnPause();
        }
        else
        {
            OnPause();
            Time.timeScale = 0;
            PauseController.isPaused = true;
            pauseCanvas.enabled = true;
            button.interactable = true;
        }
    }
}
