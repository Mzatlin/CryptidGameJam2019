using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnTouch : MonoBehaviour
{
    [SerializeField]
    GameObject boat;
    [SerializeField]
    Transform respawnPosition;

    void OnTriggerEnter(Collider other)
    {
        var trigger = other.GetComponent<IMovable>();
        if(trigger != null && SpawnAroundCircle.isActive)
        {
            SceneManager.LoadScene("FinalTown", LoadSceneMode.Single);
        }
        else if(trigger != null)
        {
            boat.transform.position = respawnPosition.position;
        }
    }
}
