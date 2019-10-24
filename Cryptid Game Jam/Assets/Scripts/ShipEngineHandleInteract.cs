using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngineHandleInteract : MonoBehaviour
{
    [SerializeField]
    Canvas RepairMinigame;
    InteractionController interact;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        RepairMinigame.enabled = false;
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }

    void HandleInteract()
    {
        if (!isActive)
        {
            RepairMinigame.enabled = true;
            isActive = true;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
