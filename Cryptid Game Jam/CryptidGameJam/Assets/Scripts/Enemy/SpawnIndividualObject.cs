using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIndividualObject : SpawnGameObjectBase
{
    int timeBeforeFirstSpawn = 10;
    int timeBetweenSpawns = 4;
    int delay = 3;
    FishStorageCount storage;
    [SerializeField]
    GameObject fishStorageObject;
    Dictionary<GameObject, Transform> enemyGroupings = new Dictionary<GameObject, Transform>();

    protected override void SpawnItem()
    {
        base.SpawnItem();
    }

    protected override void SetupObject(GameObject enemyToSpawn)
    {
        enemyToSpawn.transform.position = enemyGroupings[enemyToSpawn].position;
        base.SetupObject(enemyToSpawn);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(fishStorageObject != null)
        {
            storage = fishStorageObject.GetComponent<FishStorageCount>();
        }
       
        if(storage != null)
        {
            storage.OnFilledup += HandleFill;
        }
        SetupDictionary();
    }

    void SetupDictionary()
    {
        for(int i = 0; i<SpawnObjects.Count || i<SpawnLocations.Count; i++)
        {
            if(SpawnLocations.Count > 0 && SpawnObjects.Count > 0)
            {
                enemyGroupings[SpawnObjects[i]] = SpawnLocations[i];
            }
        }
    }

    private void HandleFill()
    {
        StartCoroutine(TimeToSpawnDelay());
    }

    IEnumerator TimeToSpawnDelay()
    {
        yield return new WaitForSeconds(timeBeforeFirstSpawn);
        InvokeRepeating("SpawnItem", UnityEngine.Random.Range(timeBetweenSpawns, timeBetweenSpawns + 2), delay);
    }
}
