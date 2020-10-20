using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPoint : MonoBehaviour
{
    public Transform objectLocation;

    // Update is called once per frame
    void Update()
    {
        if(objectLocation != null)
        {
            transform.LookAt(objectLocation);
        }

    }
}
