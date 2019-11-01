using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDeath : MonoBehaviour
{
    [SerializeField]
    ShipHealthSO ship;
    [SerializeField]
    PlayerStatsSO player;
    HealthController health;


    void Start()
    {
        ship.isDead = false;
        player.isDead = false;
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }


    void HandleDie()
    {
        player.isDead = true;
        BoatMovementController.isMotorActive = false;
        ship.isDead = true;
    }

}


