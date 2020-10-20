using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    [SerializeField]
    Canvas deathCanvas;
    HealthController health;


    void Start()
    {
        deathCanvas.enabled = false;
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    void HandleDie()
    {
        deathCanvas.enabled = true;
    }

}
