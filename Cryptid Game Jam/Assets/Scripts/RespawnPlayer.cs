using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField]
    Transform respawnPosition;

    void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<PlayerMoveController>();
        if(player != null)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Fall in water");
            collision.transform.position = respawnPosition.position;
        }
    }
}
