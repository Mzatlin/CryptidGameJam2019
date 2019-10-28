using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractDescription : MonoBehaviour
{
    [SerializeField]
    string content;
    [SerializeField]
    Canvas interactCanvas;
    [SerializeField]
    TextMeshProUGUI interactText;
    InteractionController interact;
    // Start is called before the first frame update
    void Start()
    {
        interactCanvas.enabled = false;
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }
    
    void HandleInteract()
    {
        interactCanvas.enabled = true;
        interactText.text = content;
    }
}
