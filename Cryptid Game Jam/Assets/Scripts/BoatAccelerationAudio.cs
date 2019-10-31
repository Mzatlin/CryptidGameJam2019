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
        if (playerStats.isOccupied && Input.GetKey(KeyCode.W) && (PlaybackState(accelerate) != (PLAYBACK_STATE.PLAYING)))
        {
            accelerate = FMODUnity.RuntimeManager.CreateInstance(sound);

            accelerate.start();
        }
        if(playerStats.isOccupied && Input.GetKeyUp(KeyCode.W) && (PlaybackState(accelerate) == PLAYBACK_STATE.PLAYING) && BoatMovementController.isMotorActive) 
        {
            accelerate.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            accelerate.release();
        }
    }
    private PLAYBACK_STATE PlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }

    private void OnDisable()
    {
        accelerate.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

}
