using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ObjectiveSystem : ScriptableObject
{
    public event Action<string> OnObjectiveChange = delegate {};
    Objective currentObjective;

    public void ChangeObjective(Objective _currentObj)
    {
       currentObjective.isActive = _currentObj.isActive;
       currentObjective.objectiveText = _currentObj.objectiveText;
       OnObjectiveChange(currentObjective.objectiveText);
    }
}
