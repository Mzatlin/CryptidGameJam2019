using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDeath : MonoBehaviour
{
    [SerializeField]
    ShipHealthSO ship;
    [SerializeField]
    GameObject player;
    HealthController health;
    [SerializeField]
    HolsterSystemSO holster;
    [SerializeField]
    PlayerStatsSO playerStats;
    PlayerMoveController move;


    void Start()
    {
        ship.isDead = false;
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
        move = player.GetComponent<PlayerMoveController>();
    }


    void HandleDie()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Death Stinger");
        player.GetComponent<PlayerMoveController>().enabled = false;
        //player.GetComponent<RodCastBobber>().enabled = false;
        BoatMovementController.isMotorActive = false;
        ship.isDead = true;
        holster.RemoveItem(holster.child);
        playerStats.KillPlayer();
        move.ResetPlayerMovement();
        
    }

}


