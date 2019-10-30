using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobberHitWater : MonoBehaviour
{
    LayerMask layer;
    void OnCollisionEnter(Collision collision)
    {
        if(layer == collision.gameObject.layer)
        {
            Debug.Log("I hit the water");
        }
        else
        {
          //  gameObject.SetActive(false);
        }
    }
}
