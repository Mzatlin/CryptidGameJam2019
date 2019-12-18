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
    List<Objective> objectives = new List<Objective>();
    [SerializeField]
    Objective startingObjective;
    // Start is called before the first frame update
    void Start()
    {
        if(startingObjective.objectiveText != null)
        {
            objectiveSystem.ChangeObjective(startingObjective);
        }
    }
}
