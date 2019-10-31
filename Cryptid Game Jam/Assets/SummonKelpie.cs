using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonKelpie : MonoBehaviour
{
    FishStorageCount storage;
    [SerializeField]
    GameObject SpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        SpawnManager.SetActive(false);
        storage = GetComponent<FishStorageCount>();
        storage.OnFilledup += HandleFill;
    }

    void HandleFill()
    {
        SpawnManager.SetActive(true);
    }
}
