using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkOnDeath : MonoBehaviour
{
    public float amountToMove = 10f;
    public float lowerTime = 3f;
    HealthController health;
    Vector3 moveTransform;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    void HandleDie()
    {
        float startTime = Time.time;
        moveTransform = transform.position - new Vector3(0f, amountToMove, 0f);
        StartCoroutine(HandleLerp(moveTransform, amountToMove));
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
