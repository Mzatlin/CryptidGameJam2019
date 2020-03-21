using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IHittable
{
    public event Action OnHit = delegate { };

    public void RecieveDamage()
    {
        ProcessDamage();
    }

    protected virtual void ProcessDamage()
    {
        OnHit();
    }
}
