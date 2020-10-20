using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSoundEventsOnReload : StopAllSoundsOnEventBase
{
    IReload reload;
    // Start is called before the first frame update
    void Start()
    {
        reload = GetComponent<IReload>();
        if(reload != null)
        {
            reload.OnStartReload += HandleReload;
        }
    }

    void OnDestroy()
    {
        if(reload != null)
        {
            reload.OnStartReload -= HandleReload;
        }
    }
    private void HandleReload()
    {
        StopAllSoundEvents();
    }
}
