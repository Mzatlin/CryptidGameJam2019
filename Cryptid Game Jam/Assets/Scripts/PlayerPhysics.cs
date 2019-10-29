using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPhysics : MonoBehaviour
{
    Vector3 velocity, rotation;
    Rigidbody rb;
    Camera cam;
    float cameraRotationx = 0f, cameraLimit = 85f;
    float rotationCurrent = 0f;

    // Good for if I change the name of the event
    [FMODUnity.EventRef]
    public string footstepEvent;

    // Declare instance
    private FMOD.Studio.EventInstance footsteps;

    //Collision tags
    public string floortag;
    public string currentTag = "Dirt";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        // initialize the FMOD instance
        footsteps = FMODUnity.RuntimeManager.CreateInstance(footstepEvent);
        footsteps.setParameterByName("Dirt", 1f);


    }

    public void SetVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void SetRotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CameraRotation(float _camera)
    {
        cameraRotationx = _camera;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!(velocity == Vector3.zero))
        {
            FootstepGround();

        }
        else 
        {
            footsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            rotationCurrent -= cameraRotationx;
            rotationCurrent = Mathf.Clamp(rotationCurrent, -cameraLimit, cameraLimit);
            cam.transform.localEulerAngles = new Vector3(rotationCurrent, 0, 0);
        }
    }

    //Changes the terrain type for the footsteps event
    void FootstepGround()
    {

        if (PlaybackState(footsteps) != PLAYBACK_STATE.PLAYING)
        {
            footsteps.start();
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            floortag = hit.collider.tag;
        }

        if (currentTag != floortag)
        {
            currentTag = floortag;
            if (floortag == "Dirt")
            {
                footsteps.setParameterByName("Dirt", 1f);
                footsteps.setParameterByName("Dock", 0f);
                footsteps.setParameterByName("Boat", 0f);
            }

            else if (floortag == "Dock")
            {
                footsteps.setParameterByName("Dirt", 0f);
                footsteps.setParameterByName("Dock", 1f);
                footsteps.setParameterByName("Boat", 0f);
            }

            else if (floortag == "Boat")
            {
                footsteps.setParameterByName("Dirt", 0f);
                footsteps.setParameterByName("Dock", 0f);
                footsteps.setParameterByName("Boat", 1f);
            }

            else
            {
                footsteps.setParameterByName("Dirt", 0f);
                footsteps.setParameterByName("Dock", 0f);
                footsteps.setParameterByName("Boat", 0f);
            }
        }
    }

    //Returns the playback state of the footsteps event
    private PLAYBACK_STATE PlaybackState(EventInstance instance)
    {
        PLAYBACK_STATE pS;
        instance.getPlaybackState(out pS);
        return pS;
    }
}
