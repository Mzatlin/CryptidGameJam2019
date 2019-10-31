using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BobberHitWater : MonoBehaviour
{
    public event Action OnHitWater = delegate { };
    public event Action OnHitObject = delegate { };

    [SerializeField]
    LayerMask layer;
    void OnCollisionEnter(Collision collision)
    {
        if ((layer.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            OnHitWater();
        }
        else if(collision.gameObject.tag == "Player")
        {

        }
        else
        {
            Debug.Log(collision.gameObject.name);
            OnHitObject();
        }
    }
}
