using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnock : MonoBehaviour
{
    [SerializeField]
    float initialKnockDelay = 2f;
    OpenDoor door;
    bool isKnock = false;

    void Start()
    {
        door = GetComponent<OpenDoor>();
        door.OnDoorOpen += HandleOpen;
        StartCoroutine(Knock(initialKnockDelay));
    }

    void HandleOpen()
    {
        StopAllCoroutines();
        isKnock = false;
    }

    void Update()
    {
        if (isKnock)
        {
            isKnock = false;
            StartCoroutine(Knock(UnityEngine.Random.Range(1f,3.5f)));
        }

    }


    IEnumerator Knock(float initialKnockDelay)
    {
        yield return new WaitForSeconds(initialKnockDelay);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Door Knock", GetComponent<Transform>().position);
        isKnock = true;
    }

}
