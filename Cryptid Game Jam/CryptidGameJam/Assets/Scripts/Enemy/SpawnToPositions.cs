using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToPositions : SpawnGameObjectBase
{
    [SerializeField]
    float spawnAmount=1f;
    [SerializeField]
    float delay = 3f;
    [SerializeField]
    int startingHealth = 1;
    HealthController health;
    ISpriteFade sprite;

    void Start()
    {
        sprite = GetComponent<ISpriteFade>();
        SetupItems();  
    }
    void OnEnable()
    {
        InvokeRepeating("SpawnItem", Random.Range(spawnAmount,spawnAmount+2),delay);
    }

    void OnDisable()
    {
        StopAllCoroutines();
        CancelInvoke();
    }

    void SetupItems()
    {
        for (int i = 0; i < SpawnObjects.Count; i++)
        {
            SpawnObjects[i].SetActive(false);
            health = SpawnObjects[i].GetComponent<HealthController>();
            if (health != null)
            {
                SpawnObjects[i].GetComponent<HealthController>().IsDead = true;
            }
        }
    }

    protected override void SetupObject(GameObject enemyToSpawn)
    {
        health = enemyToSpawn.GetComponent<HealthController>();
        enemyToSpawn.transform.position = GetRandomSpawnLocation().transform.position;
        health.IsDead = false;
        health.CurrentHealth = startingHealth;
        if(sprite != null)
        {
            sprite.FadeSpriteIn(enemyToSpawn);
        }
        enemyToSpawn.GetComponent<EnemyFollowTarget>().enabled = true;
        base.SetupObject(enemyToSpawn);
    }

    Transform GetRandomSpawnLocation()
    {
        return SpawnLocations[Random.Range(0, SpawnLocations.Count)];
    }

}
