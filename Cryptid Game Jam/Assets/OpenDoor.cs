using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    InteractionController interact;
    MeshRenderer render;

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
        StartCoroutine(NewScene());
    }

    IEnumerator NewScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level1Diary", LoadSceneMode.Single);
    }
}
