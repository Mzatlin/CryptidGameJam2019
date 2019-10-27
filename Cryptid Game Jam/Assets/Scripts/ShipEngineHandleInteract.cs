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
    public static bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        RepairMinigame.enabled = false;
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
        repair = GetComponent<RepairController>();
        repair.OnCompletion += HandleCompletion;
    }

    void HandleInteract()
    {
        if (!isActive)
        {
            StartCoroutine(StartDelay());
        }
    }
    void HandleCompletion()
    {
        RepairMinigame.enabled = false;
        isActive = false;

    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        RepairMinigame.enabled = true;
        isActive = true;
        OnRepairStart();
    }
}
