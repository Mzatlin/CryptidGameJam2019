using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class BoatAccelerationAudio : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string sound;
    FMOD.Studio.EventInstance accelerate;

    [SerializeField]
    PlayerStatsSO playerStats;

    // Start is called before the first frame update
    void Start()
    {
        accelerate = FMODUnity.RuntimeManager.CreateInstance(sound);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isOccupied && Input.GetKeyDown(KeyCode.W) && (PlaybackState(accelerate) != PLAYBACK_STATE.PLAYING))
        {
            accelerate = FMODUnity.RuntimeManager.CreateInstance(sound);
            //accelerate.setParameterByName("Throttle", 0f);
            accelerate.start();
        }
        if(playerStats.isOccupied && Input.GetKeyUp(KeyCode.W) && (PlaybackState(accelerate) == PLAYBACK_STATE.PLAYING) && BoatMovementController.isMotorActive) 
        {
            accelerate.setParameterByName("Throttle", 1f);
            accelerate.release();
        }
    }
    private PLAYBACK_STATE PlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }

}
