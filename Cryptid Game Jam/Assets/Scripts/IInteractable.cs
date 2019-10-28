using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IInteractable 
{
    event Action OnInteract;
    //event Action OnHover
    //event Action OnLeaveHover
    void RecieveInteraction();
    //void RecieveMouseHover
}
