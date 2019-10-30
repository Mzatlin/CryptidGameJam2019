using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerPhysics>();
        if(player != null)
        {
            var health = other.GetComponent<IHittable>();
            if (health != null)
            {
                health.RecieveDamage();
                gameObject.SetActive(false);
            }
        }

    }
}
