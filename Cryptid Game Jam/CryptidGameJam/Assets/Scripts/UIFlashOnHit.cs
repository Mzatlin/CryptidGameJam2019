using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlashOnHit : MonoBehaviour
{
    [SerializeField]
    float flashDuration;
    IFade fade;
    HealthController health;


    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnHit += HandleHit;
        fade = GetComponent<IFade>();
    }

    void HandleHit()
    {
        if (fade != null && health.CurrentHealth > 1)
        {
            StartCoroutine(HitDelay());
        }
        else
        {
            Debug.Log("Fade Not Found");
        }
    }

    IEnumerator HitDelay()
    {
        fade.Fade(1f, flashDuration);
        yield return new WaitForSeconds(0.2f);
        fade.Fade(0f, flashDuration);
    }
}

