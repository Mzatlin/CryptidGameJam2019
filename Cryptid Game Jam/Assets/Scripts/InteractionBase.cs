using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionBase : MonoBehaviour, IInteractable
{
    public event Action OnInteract = delegate { };

    public void RecieveInteraction()
    {
        ProcessInteraction();
    }

    protected void ProcessInteraction()
    {
        OnInteract();
    }
}
