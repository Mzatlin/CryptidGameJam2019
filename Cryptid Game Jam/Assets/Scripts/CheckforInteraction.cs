using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckforInteraction : MonoBehaviour
{
    PlayerInteract interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var checker = interaction.Hit.collider.transform.GetComponent<IInteractable>();
            if (checker != null)
            {
                checker.ReceiveInteraction();
                Debug.Log("can interact");
            }
        }
    }
}
