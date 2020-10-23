using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCameraController : MonoBehaviour
{
    StopMotor stop;
    StartMotor start;
    Camera cam;

    public static Camera boatCamera;

    [SerializeField]
    Camera changeCam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        boatCamera = cam;
        start = GetComponent<StartMotor>();
        stop = GetComponent<StopMotor>();
        if(start != null && stop != null)
        {
            start.OnStartMotor += HandleStart;
            stop.OnStopMotor += HandleStop;
        }
    }

    void OnDestroy()
    {
        if (start != null && stop != null)
        {
            start.OnStartMotor -= HandleStart;
            stop.OnStopMotor -= HandleStop;
        }
    }

    private void HandleStop()
    {
        boatCamera = cam;
    }

    private void HandleStart()
    {
        boatCamera = changeCam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
