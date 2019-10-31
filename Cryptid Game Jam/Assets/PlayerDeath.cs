using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    HealthController health;
    PlayerStatsSO stats;
    FMOD.Studio.Bus master;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
        master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    void HandleDie()
    {
        master.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Death Stinger");
        stats.isOccupied = true;
    }
}
