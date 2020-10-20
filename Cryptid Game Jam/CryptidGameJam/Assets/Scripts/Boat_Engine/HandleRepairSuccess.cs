using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRepairSuccess : MonoBehaviour
{
    [SerializeField]
    GameObject motor;
    InteractionController interact;
    RepairController repair;
    BoatAccelerationAudio boat;

    // Start is called before the first frame update
    void Start()
    {
        if(motor != null)
        {
            boat = motor.GetComponentInChildren<BoatAccelerationAudio>();
            interact = motor.GetComponent<InteractionController>();
        }
        repair = GetComponent<RepairController>();
        repair.OnSuccess += HandleSuccess;
    }

    void HandleSuccess()
    {
        interact.IsInteractable = true;
        boat.enabled = true;
    }
}
