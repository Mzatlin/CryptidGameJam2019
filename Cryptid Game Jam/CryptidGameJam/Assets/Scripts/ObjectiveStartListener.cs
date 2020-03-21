using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveStartListener : MonoBehaviour
{

    [SerializeField]
    ObjectiveSO objective;
    InteractionController interaction;

    // Start is called before the first frame update
    void Start()
    {
        interaction = GetComponent<InteractionController>();
        objective.OnSetActive += HandleBegin;
    }
    
    void HandleBegin()
    {
        interaction.IsInteractable = true;
    }
}
