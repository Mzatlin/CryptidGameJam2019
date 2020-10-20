using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveOnDeath : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDeactivate = new List<GameObject>();
    HealthController health;
    // Start is called before the first frame update
    void Start()
    {
        if(objectsToDeactivate.Count < 1)
        {
            Debug.Log("Empty List");
        }
        else
        {
            health = GetComponent<HealthController>();
            if(health != null)
            {
                health.OnDie += HandleDie;
            }
        }


    }

    void OnDestroy()
    {
        if(health != null)
        {
            health.OnDie -= HandleDie;
        }
    }

    void HandleDie()
    {
        foreach(GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
