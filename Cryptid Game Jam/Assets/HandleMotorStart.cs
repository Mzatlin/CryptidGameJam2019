using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMotorStart : MonoBehaviour
{

    public static bool isMotorActive = false;

    [SerializeField]
    PlayerStatsSO playerStats;
    StartMotor[] children;
    [SerializeField]
    Transform player;
  
    void Awake()
    {
        playerStats.isOccupied = false;
        children = GetComponentsInChildren<StartMotor>();
        foreach(var child in children)
        {
            
            if(child != null)
            {
                child.OnStartMotor += HandleStart;
            }
        }

    }

    void HandleStart()
    {
        Debug.Log("Motor Started");
        isMotorActive = true;
        playerStats.isOccupied = true;
        player.parent = transform;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
