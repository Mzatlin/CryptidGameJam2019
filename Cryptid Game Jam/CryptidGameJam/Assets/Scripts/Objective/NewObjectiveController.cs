using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectiveController : MonoBehaviour
{
    [SerializeField]
    ObjectiveSystem objectiveSystem;
    [SerializeField]
    HeaderText header;
    [SerializeField]
    ObjectiveSO startingObjective;
    // Start is called before the first frame update
    void Start()
    {
        if(objectiveSystem.objectives.Count > 0)
        {
            SetupObjectives();
        }
        if(startingObjective != null)
        {
            objectiveSystem.ChangeObjective(startingObjective);
        }
    }

    void SetupObjectives()
    {
        foreach (ObjectiveSO obj in objectiveSystem.objectives)
        {
            obj.isActive = false;
        }
    }
}
