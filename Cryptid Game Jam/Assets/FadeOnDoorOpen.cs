using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnDoorOpen : MonoBehaviour
{
    OpenDoor door;
    IFade fade;
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<IFade>();
        door = GetComponent<OpenDoor>();
        door.OnDoorOpen += HandleDoor;
    }

    private void HandleDoor()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        if (fade != null)
        {
            fade.Fade(fadeAlpha, fadeDuration);
        }
        else
        {
            Debug.Log("Fade Cannot Be Found");
        }
    }
}
