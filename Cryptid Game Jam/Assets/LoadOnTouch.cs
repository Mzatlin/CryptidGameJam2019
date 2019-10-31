using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<IMovable>();
        if(trigger != null)
        {
            SceneManager.LoadScene("FinalTown", LoadSceneMode.Single);
        }
    }
}
