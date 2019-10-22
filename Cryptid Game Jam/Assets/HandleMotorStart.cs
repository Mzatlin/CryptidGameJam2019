using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMotorStart : MonoBehaviour
{

    [SerializeField]
    PlayerStatsSO playerStats;
    StartMotor[] startChildren;
    StopMotor[] stopChildren;
    [SerializeField]
    Transform player;
    [SerializeField]
    Camera boatCam;
    HandleMotorStart start;
   
  
    void Awake()
    {
        boatCam.enabled = false;
        playerStats.isOccupied = false;
        startChildren = GetComponentsInChildren<StartMotor>();
        stopChildren = GetComponentsInChildren<StopMotor>();
        foreach(var child in startChildren)
        {
            if(child != null)
            {
                child.OnStartMotor += HandleStart;
          
            }
        }
        foreach (var child in stopChildren)
        {
            if (child != null)
            {
                child.OnStopMotor += HandleStop;
              

            }
        }

    }

    void HandleStart()
    {
        Debug.Log("Motor Started");
        BoatMovementController.isMotorActive = true;
        playerStats.isOccupied = true;
        player.parent = transform;
        player.gameObject.SetActive(false);
        boatCam.enabled = true;
    }

    void HandleStop()
    {
        Debug.Log("Motor Stopped");
        BoatMovementController.isMotorActive = false;
        playerStats.isOccupied = false;
        player.parent = null;
        player.gameObject.SetActive(true);
        boatCam.enabled = false;
    }

}
