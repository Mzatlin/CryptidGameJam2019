using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerOnDoorOpen : MonoBehaviour
{
    OpenDoor open;
    [SerializeField]
    PlayerStatsSO playerStats;
    [SerializeField]
    GameObject player;
    HealthController health;
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<OpenDoor>();
        open.OnDoorOpen += HandleFreeze;
        health = player.GetComponent<HealthController>();
        health.enabled = true;
    }
    void HandleFreeze()
    {
        playerStats.isOccupied = true;
        health.enabled = false;
    }
}
