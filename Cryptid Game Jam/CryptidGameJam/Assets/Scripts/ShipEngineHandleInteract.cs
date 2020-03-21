using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipEngineHandleInteract : MonoBehaviour
{
    public event Action OnRepairStart = delegate { };
    public event Action OnRepairSuccess = delegate { };

    [SerializeField]
    Canvas RepairMinigame;
    InteractionController interact;
    RepairController repair;
    public static bool isMiniGameActive = false;
    
    void Start()
    {
        if (RepairMinigame != null)
        {
            RepairMinigame.enabled = false;
            interact = GetComponent<InteractionController>();
            interact.OnInteract += HandleInteract;
            repair = GetComponent<RepairController>();
            repair.OnExit += HandleExit;
            repair.OnSuccess += HandleSuccess;
        }
    }

    void HandleInteract()
    {
        if (!isMiniGameActive)
        {
            interact.IsInteractable = false;
            StartCoroutine(StartDelay());
        }
    }
    void HandleExit()
    {
        StopMinigame();
        interact.IsInteractable = true;
    }

    void HandleSuccess()
    {
        StopMinigame();
        OnRepairSuccess();
    }

    void StopMinigame()
    {
        RepairMinigame.enabled = false;
        isMiniGameActive = false;
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        RepairMinigame.enabled = true;
        isMiniGameActive = true;
        OnRepairStart();
    }
}
