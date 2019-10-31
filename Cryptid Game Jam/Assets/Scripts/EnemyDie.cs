using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    HealthController health;
    SpriteRenderer render;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        render = GetComponentInChildren<SpriteRenderer>();
        originalColor = render.color;
        health.OnDie += HandleDie;
    }

    void HandleDie()
    {
        render.color = originalColor;
        gameObject.SetActive(false);
    }

}
