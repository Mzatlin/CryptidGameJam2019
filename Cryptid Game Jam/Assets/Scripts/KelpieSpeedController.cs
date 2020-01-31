using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpieSpeedController : MonoBehaviour
{
    EnemyFollowTarget follow;
    HealthController health;
    SpawnAroundCircle spawn;
    [SerializeField]
    GameObject kelpie;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GetComponent<SpawnAroundCircle>();
        spawn.OnSpawned += HandleSpawnSpeed;
        follow = kelpie.GetComponent<EnemyFollowTarget>();
        health = kelpie.GetComponent<HealthController>();
        health.OnDie += HandleDeathSpeed;
    }

    void HandleDeathSpeed()
    {

    }

    void HandleSpawnSpeed()
    {

    }

}
