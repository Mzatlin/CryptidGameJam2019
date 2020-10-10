using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkOnDeath : MonoBehaviour
{
    public float lowerAmount = 10f;
    public float lowerTime = 3f;
    HealthController health;
    Vector3 lowerTransform;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    void HandleDie()
    {
        float startTime = Time.time;
        lowerTransform = transform.position - new Vector3(0f, lowerAmount, 0f);
        StartCoroutine(HandleLerp(lowerTransform, lowerAmount));
    }

    IEnumerator HandleLerp(Vector3 lowerTransform, float lowerAmount)
    {
        float time = 0;

        while(time < lowerTime)
        {
            transform.position = Vector3.Lerp(transform.position, lowerTransform,  time/lowerAmount);
            time+=Time.deltaTime;
            yield return null;
        }
        transform.position = lowerTransform;

    }

}
