using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipEngineHandleInteract : MonoBehaviour
{
    public event Action OnRepairStart = delegate { };

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
        RepairMinigame.enabled = false;
        isMiniGameActive = false;
        interact.IsInteractable = true;
    }


    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        RepairMinigame.enabled = true;
        isMiniGameActive = true;
        OnRepairStart();
    }
}
