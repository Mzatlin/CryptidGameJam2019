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
    GameObject player;
    PlayerMoveController move;
    [SerializeField]
    Camera boatCam;
    HandleMotorStart start;
    [SerializeField]
    List<GameObject> Items = new List<GameObject>();
   
  
    void Awake()
    {
        boatCam.enabled = false;
        startChildren = GetComponentsInChildren<StartMotor>();
        stopChildren = GetComponentsInChildren<StopMotor>();
        move = player.GetComponent<PlayerMoveController>();
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
        for(int i = 0; i<Items.Capacity; i++)
        {
            Items[i].transform.parent = transform;
        }

        player.transform.parent = transform;
        player.gameObject.SetActive(false);
        boatCam.enabled = true;
    }

    void HandleStop()
    {
        Debug.Log("Motor Stopped");
        BoatMovementController.isMotorActive = false;
 
        StartCoroutine("DelayStop");

        for (int i = 0; i < Items.Capacity; i++)
        {
            Items[i].transform.parent = null;
        }
    }

    IEnumerator DelayStop()
    {
        yield return new WaitForSeconds(.2f);
        move.ResetPlayerMovement();
        player.gameObject.SetActive(true);
        playerStats.isOccupied = false;
        player.transform.parent = null;
        boatCam.enabled = false;
    }

}
