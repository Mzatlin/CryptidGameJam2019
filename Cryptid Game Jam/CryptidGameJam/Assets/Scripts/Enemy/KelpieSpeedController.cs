using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpieSpeedController : MonoBehaviour
{
    HealthController health;
    SpawnAroundCircle spawn;
    HitOnTouch touch;
    [SerializeField]
    GameObject kelpie;
    [SerializeField]
    KelpieStats kelpieStats;
    [SerializeField]
    float speedIncrease;
    KelpieChaseTarget chase;
    // Start is called before the first frame update
    void Start()
    {
        kelpieStats.isAlive = false;
        touch = kelpie.GetComponent<HitOnTouch>();
        touch.OnTouched += HandleTouch;
        touch.enabled = true;
        chase = kelpie.GetComponent<KelpieChaseTarget>();
        chase.enabled = true;
        spawn = GetComponent<SpawnAroundCircle>();
        spawn.OnSpawned += HandleSpawnSpeed;
        health = kelpie.GetComponent<HealthController>();
        health.OnDie += HandleDeathSpeed;
    }


    void FixedUpdate()
    {
        if (kelpieStats.isAlive)
        {
            kelpieStats.KelpieMoveSpeed += speedIncrease;
            speedIncrease += 0.001f;
        }
        else
        {
            speedIncrease = 0f;
        }

    }

    void HandleTouch()
    {
        kelpieStats.isAlive = false;
    }

    void HandleDeathSpeed()
    {
        HandleTouch();
        kelpieStats.KelpieMoveSpeed = 0;
        touch.enabled = false;
        chase.enabled = false;
    }

    void HandleSpawnSpeed()
    {
        kelpieStats.isAlive = true;
        kelpieStats.ResetSpeed();
        touch.enabled = true;
        chase.enabled = true;
    }


}
