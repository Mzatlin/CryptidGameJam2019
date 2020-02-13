using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    public event Action OnUnpause = delegate { };

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
        controller.OnUnPause += HandleUnPause;

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
        OnUnpause();
        button.interactable = false;
    }

    void HandlePause()
    {
        StartCoroutine(PauseDelay());
    }

    IEnumerator PauseDelay()
    {
        yield return new WaitForSeconds(.1f);
        if (PauseController.isPaused)
        {
            HandleUnPause();
        }
        else
        {
            Time.timeScale = 0;
            PauseController.isPaused = true;
            pauseCanvas.enabled = true;
            button.interactable = true;
        }
    }
}
