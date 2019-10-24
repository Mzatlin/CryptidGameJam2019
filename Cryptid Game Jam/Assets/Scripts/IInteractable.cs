using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInteractable 
{
    event Action OnInteract;
    void RecieveInteraction();
}
