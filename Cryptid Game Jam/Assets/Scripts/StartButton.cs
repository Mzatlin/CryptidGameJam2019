using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Boat Horn");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
