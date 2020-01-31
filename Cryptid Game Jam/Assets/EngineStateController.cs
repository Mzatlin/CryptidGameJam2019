using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineStateController : MonoBehaviour
{
    HealthController health;
    RepairController repair;
    [SerializeField]
    GameObject shipEngine;
    // Start is called before the first frame update
    void Start()
    {
        if(shipEngine!= null)
        {
            shipEngine.SetActive(false);
        }
        health = GetComponent<HealthController>();
        health.OnHit += HandleDamage;
        repair = shipEngine.GetComponent<RepairController>();
        repair.OnSuccess += HandleCompletion;
    }

    void HandleDamage()
    {
        if (!shipEngine.activeInHierarchy)
        {
            shipEngine.SetActive(true);
        }
     
    }

    void HandleCompletion()
    {
        //Set the boat free
        shipEngine.SetActive(false);
    }
}
