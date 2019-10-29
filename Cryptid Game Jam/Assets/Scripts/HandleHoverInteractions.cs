using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHoverInteractions : MonoBehaviour
{
    [SerializeField]
    DescriptionText descObject;
    [SerializeField]
    string description;
    InteractionController interactHover;
    // Start is called before the first frame update
    void Start()
    {
        interactHover = GetComponent<InteractionController>();
        interactHover.OnHover += HandleHover;
        interactHover.OnLeaveHover += HandleLeave;
    }

    void HandleHover()
    {
        descObject.WriteDescription(description);
    }
    void HandleLeave()
    {
        descObject.WriteDescription("");
    }
}
