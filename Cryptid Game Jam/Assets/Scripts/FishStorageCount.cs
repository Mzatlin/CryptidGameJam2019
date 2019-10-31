using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStorageCount : MonoBehaviour
{
    [SerializeField]
    GameObject rod;
    [SerializeField]
    int fishCount = 0;
    InteractionController interact;
    ItemHolsterManager holster;
    [SerializeField]
    HeaderText header;


    // Start is called before the first frame update
    void Start()
    {
        holster = FindObjectOfType<ItemHolsterManager>();
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }

    void HandleInteract()
    {
        if(holster.child != rod)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Item Put Away");
            holster.SetItem(rod);
            Debug.Log("Stored");
            fishCount++;
            if(fishCount >= 1)
            {
                header.WriteHeader("Drive Home Using Boat");
            }
        }


    }
}
