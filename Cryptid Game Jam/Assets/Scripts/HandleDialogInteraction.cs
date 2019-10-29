using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDialogInteraction : MonoBehaviour
{
    [SerializeField]
    MessageBoxText writer;
    [SerializeField]
    List<string> dialog = new List<string>();
    InteractionController interact;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }
    
    void HandleInteract()
    {
        Debug.Log("Interacted");
        writer.WriteDialog(dialog);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
