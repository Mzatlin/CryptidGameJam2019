using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MotorHeaderController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI content;
    StartMotor start;
    StopMotor stop;
    // Start is called before the first frame update
    void Start()
    {
        if(content != null)
        {
            content.enabled = false;
        }
        start = GetComponent<StartMotor>();
        stop = GetComponent<StopMotor>();
        if(start != null && stop != null)
        {
            start.OnStartMotor += HandleMotorStart;
            stop.OnStopMotor += HandleMotorStop;
        }
    }

    void OnDestroy()
    {
        if(start != null)
        {
            start.OnStartMotor -= HandleMotorStart;
        }

        if (stop != null)
        {
            stop.OnStopMotor -= HandleMotorStop;
        }

    }

    void HandleMotorStop()
    {
        if(content != null)
        {
            content.enabled = false;
        }
    }

    void HandleMotorStart()
    {
        if(content != null)
        {
            content.enabled = true;
        }
    }
}
