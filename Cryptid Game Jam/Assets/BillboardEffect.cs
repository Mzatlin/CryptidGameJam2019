using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    Camera mainCam;
    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = -mainCam.transform.forward;
    }
}
