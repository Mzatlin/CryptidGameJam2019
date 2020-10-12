using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSoundEventsOnNewScene : StopAllSoundsOnEventBase
{
    ILoadScene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<ILoadScene>();
        if(scene != null)
        {
            scene.OnStartLoad += HandleLoad;
        }
    }

    void OnDestroy()
    {
        if (scene != null)
        {
            scene.OnStartLoad -= HandleLoad;
        }
    }
    private void HandleLoad()
    {
        StopAllSoundEvents();
    }
}
