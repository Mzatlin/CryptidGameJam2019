using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnSpawn : MonoBehaviour
{
    public float amountToMove = -10f;
    public float lowerTime = 3f;
    Vector3 moveTransform;

    void OnEnable()
    {
        float startTime = Time.time;
        moveTransform = transform.position - new Vector3(0f, amountToMove, 0f);
        StartCoroutine(HandleLerp(moveTransform, amountToMove));
    }

    IEnumerator HandleLerp(Vector3 lowerTransform, float lowerAmount)
    {
        float time = 0;

        while (time < lowerTime)
        {
            transform.position = Vector3.Lerp(lowerTransform, transform.position, time / lowerAmount);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = lowerTransform;

    }

}
