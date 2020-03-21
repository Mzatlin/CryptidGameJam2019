using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ObjectiveSO : ScriptableObject
{
    public event Action OnSetActive = delegate { };
    public event Action OnCompletion = delegate { };
    public bool isActive;
    public string objectiveTitle;

    public void CompleteObjective()
    {
        isActive = false;
        OnCompletion();
    }

    public void BeginObjective()
    {
        isActive = true;
        OnSetActive();
    }
}

