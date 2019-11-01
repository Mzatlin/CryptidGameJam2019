using UnityEngine;
using System;

public class StartMotor : MonoBehaviour
{
    InteractionController interact;
    public event Action OnStartMotor = delegate { };

    [SerializeField]
    PlayerStatsSO playerStats;

    void Start()
    {
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }

    void HandleInteract()
    {
       // var player = other.GetComponent<PlayerMoveController>();
        if (!playerStats.isOccupied && Input.GetKeyDown(KeyCode.E) && !BoatMovementController.isMotorActive)
        {
            OnStartMotor();
        }
    }
}
