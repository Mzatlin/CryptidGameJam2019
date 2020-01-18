using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforInteraction : MonoBehaviour
{
    PlayerInteract interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(interaction.Hit.collider.transform.GetComponent<IInteractable>() != null)
            {
                Debug.Log("can interact");
            }
        }
    }
}
