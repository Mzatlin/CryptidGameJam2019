using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InteractionBase : MonoBehaviour, IInteractable
{
    public event Action OnInteract = delegate { };
    public event Action OnHover = delegate { };
    public event Action OnLeaveHover = delegate { };

    [SerializeField]
    bool _isInteractable = true;

    public bool IsInteractable { get => _isInteractable; set => _isInteractable = value; }

    public void ReceiveInteraction()
    {
        if (_isInteractable)
        {
            ProcessInteraction();
        }
    }

    public void ReceiveMouseHover()
    {
        if (_isInteractable)
        {
            ProcessHover();
        }
 
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
