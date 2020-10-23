using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBillboardEffect : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = -MotorCameraController.boatCamera.transform.forward;
    }
}
