using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKelpie : MonoBehaviour
{
    FishStorageCount storage;
    [SerializeField]
    List<GameObject> SpawnManager = new List<GameObject>();
    FMOD.Studio.EventInstance track;
    // Start is called before the first frame update
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
        foreach (GameObject obj in SpawnManager)
        {
            obj.SetActive(true);
        }

       // track.start();
    }
}
