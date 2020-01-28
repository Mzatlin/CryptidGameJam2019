using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ObjectiveSystem : ScriptableObject
{
    [SerializeField]
    HeaderText text;

    public ObjectiveSO currentObjective;

    public List<ObjectiveSO> objectives = new List<ObjectiveSO>();

    public void ChangeObjective(ObjectiveSO _currentObj)
    {
        if(currentObjective != null)
        {
            currentObjective.CompleteObjective();
        }

        currentObjective = _currentObj;

        text.WriteHeader(currentObjective.objectiveTitle);

        currentObjective.BeginObjective();

    }
}
