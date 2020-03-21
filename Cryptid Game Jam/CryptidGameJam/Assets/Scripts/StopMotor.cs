using System;
using UnityEngine;

public class StopMotor : MonoBehaviour
{
    public event Action OnStopMotor = delegate { };

    [SerializeField]
    PlayerStatsSO playerStats;

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isOccupied && Input.GetKeyDown(KeyCode.X) && BoatMovementController.isMotorActive)
        {
            StopBoat();
        }
    }

    public void StopBoat()
    {
        OnStopMotor();
    }
}
