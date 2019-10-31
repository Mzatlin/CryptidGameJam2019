using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField]
    Transform respawnPosition;

    void OnCollisionEnter(Collision collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Fall in water");
        var player = collision.gameObject.GetComponent<IMovable>();
        if(player != null)
        {
            collision.transform.position = respawnPosition.position;
        }
    }
}
