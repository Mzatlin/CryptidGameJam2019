using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitOnTouch : MonoBehaviour
{
    public event Action OnTouched = delegate { };

    void OnTriggerEnter(Collider other)
    {
        var movableCharacter = other.GetComponent<IMovable>();
        if(movableCharacter != null)
        {
            var health = other.GetComponent<Collider>().transform.GetComponent<IHittable>();
            if (health != null)
            {
                health.RecieveDamage();
                OnTouched();
                gameObject.SetActive(false);
            }
        }

    }
}
