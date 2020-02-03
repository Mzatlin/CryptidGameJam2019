using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelpieDie : MonoBehaviour
{
    HealthController health;
    KelpieChaseTarget follow;
    HitOnTouch hit;
    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<KelpieChaseTarget>();
        hit = GetComponent<HitOnTouch>();
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    void HandleDie()
    {
        hit.enabled = false;
        follow.enabled = false;
        gameObject.SetActive(false);
    }
}
