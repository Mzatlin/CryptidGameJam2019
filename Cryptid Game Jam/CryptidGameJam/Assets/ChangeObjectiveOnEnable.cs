using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectiveOnEnable : MonoBehaviour
{
    [SerializeField]
    HeaderText header;

    void OnEnable()
    {
        if(header != null)
        {
            header.WriteHeader("Repair Engine");
        }
    }

    void OnDisable()
    {
        if (header != null)
        {
            header.WriteHeader("Escape Using the Boat");
        }
    }

}
