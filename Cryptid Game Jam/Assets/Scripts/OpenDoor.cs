using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class OpenDoor : MonoBehaviour
{
    public event Action OnDoorOpen = delegate { };
    InteractionController interact;
    MeshRenderer render;
    [SerializeField]
    string level;

    void Start()
    {
        render = GetComponentInChildren<MeshRenderer>();
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }

    void HandleInteract()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Door Creak", GetComponent<Transform>().position);
        render.enabled = false;
        OnDoorOpen();
        StartCoroutine(NewScene());
    }

    IEnumerator NewScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
