using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    HealthController health;
    PlayerStatsSO stats;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    void HandleDie() {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Death Stinger");
        stats.isOccupied = true;
    }
}
