using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActivate : MonoBehaviour
{
    StartMotor motor;
    // Start is called before the first frame update
    void Awake()
    {
        motor = FindObjectOfType<StartMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
