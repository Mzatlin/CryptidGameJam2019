using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ObjectiveSystem : ScriptableObject
{
    [SerializeField]
    HeaderText text;

    public event Action<string> OnObjectiveChange = delegate {};
    public Objective currentObjective;

    public List<Objective> objectives = new List<Objective>();

    public void ChangeObjective(Objective _currentObj)
    {
        text.WriteHeader(_currentObj.objectiveText);
       currentObjective.isActive = _currentObj.isActive;
       currentObjective.objectiveText = _currentObj.objectiveText;
       OnObjectiveChange(currentObjective.objectiveText);
    }
}
