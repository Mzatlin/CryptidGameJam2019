using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllSoundsOnEventBase : MonoBehaviour
{
    FMOD.Studio.Bus master;
    // Start is called before the first frame update
    void Awake()
    {
        master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }
    protected void StopAllSoundEvents()
    {
        master.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
