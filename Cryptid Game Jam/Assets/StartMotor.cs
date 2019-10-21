using UnityEngine;
using System;

public class StartMotor : MonoBehaviour
{

    public event Action OnStartMotor = delegate { };

    [SerializeField]
    PlayerStatsSO playerStats;

    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<PlayerMoveController>();
        if (player != null && !playerStats.isOccupied && Input.GetKeyDown(KeyCode.E) && !BoatMovementController.isMotorActive)
        {
            OnStartMotor();
        }
    }
}
