using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashOnHit : MonoBehaviour
{
    HealthController health;
    SpriteRenderer render;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnHit += HandleHit;
        render = GetComponentInChildren<SpriteRenderer>();
        originalColor = render.color;
    }

    void HandleHit()
    {
        StartCoroutine(Flash());
        render.color = originalColor;
    }
    IEnumerator Flash()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(.1f);
        render.color = originalColor;
    }
}
