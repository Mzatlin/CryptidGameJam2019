using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppressInteractOnStart : MonoBehaviour
{
    InteractionController interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<InteractionController>();
        interaction.IsInteractable = false;
    }

}
