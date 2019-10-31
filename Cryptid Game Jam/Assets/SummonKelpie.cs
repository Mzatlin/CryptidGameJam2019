using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKelpie : MonoBehaviour
{
    FishStorageCount storage;
    [SerializeField]
    GameObject SpawnManager;
    FMOD.Studio.EventInstance track;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager.SetActive(false);
        storage = GetComponent<FishStorageCount>();
        storage.OnFilledup += HandleFill;
        track = FMODUnity.RuntimeManager.CreateInstance("event:/Water Horse Track");
    }

    void HandleFill()
    {
        SpawnManager.SetActive(true);
        track.start();
    }
}
