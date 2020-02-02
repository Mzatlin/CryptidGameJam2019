using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKelpie : MonoBehaviour
{

    [SerializeField]
    KelpieStats kelpieStats;
    [SerializeField]
    List<GameObject> SpawnManager = new List<GameObject>();

    FishStorageCount storage;
    FMOD.Studio.EventInstance track;
   
    void Start()
    {
        foreach(GameObject obj in SpawnManager)
        {
            obj.SetActive(false);
        }

        storage = GetComponent<FishStorageCount>();
        storage.OnFilledup += HandleFill;
        //track = FMODUnity.RuntimeManager.CreateInstance("event:/Water Horse Track");
    }

    void HandleFill()
    {
        kelpieStats.ResetSpeed();
        kelpieStats.isAlive = true;
        foreach (GameObject obj in SpawnManager)
        {
            obj.SetActive(true);
        }

       // track.start();
    }
}
