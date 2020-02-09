using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boat Horn");
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Level1House", LoadSceneMode.Single);
    }
}
