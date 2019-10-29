using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionBase : MonoBehaviour, IInteractable
{
    public event Action OnInteract = delegate { };
    public event Action OnHover = delegate { };
    public event Action OnLeaveHover = delegate { };

    private bool isInteractable = true;

    public bool IsInteractable { get => isInteractable; set => isInteractable = value; }

    public void ReceiveInteraction()
    {
        if (isInteractable)
        {
            ProcessInteraction();
        }
    }

    public void ReceiveMouseHover()
    {
        ProcessHover();
    }

    public void ReceiveHoverLeave()
    {
        ProcessHoverLeave();
    }

    protected void ProcessHoverLeave()
    {
        OnLeaveHover();
    }

    protected void ProcessHover()
    {
        OnHover();
    }
    protected void ProcessInteraction()
    {
        OnInteract();
    }
}
