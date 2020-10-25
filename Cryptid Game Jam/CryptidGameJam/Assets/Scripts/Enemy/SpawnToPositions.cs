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

    void Start()
    {
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

    protected override void SpawnItem()
    {
        var enemyToSpawn = GetInactiveItem();
        if (enemyToSpawn != null)
        {
            health = enemyToSpawn.GetComponent<HealthController>();
            enemyToSpawn.transform.position = GetRandomSpawnLocation().transform.position;
            health.IsDead = false;
            health.CurrentHealth = startingHealth;
            StartCoroutine("FadeSpriteIn", enemyToSpawn);
            enemyToSpawn.SetActive(true);
        }

    }
    IEnumerator FadeSpriteIn(GameObject enemy)
    {
        SpriteRenderer sprite = enemy.GetComponentInChildren<SpriteRenderer>();
        for (float f = 0f; f <= 1.05f; f += 0.05f)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.005f);
        }
        enemy.GetComponent<EnemyFollowTarget>().enabled = true;
    }

    Transform GetRandomSpawnLocation()
    {
        return SpawnLocations[Random.Range(0, SpawnLocations.Count)];
    }

    GameObject GetInactiveItem()
    {
        GameObject _enemy = null;
        for (int i = 0; i < SpawnObjects.Count; i++)
        {
            if (SpawnObjects[i].activeInHierarchy == false)
            {
                _enemy = SpawnObjects[i];
                break;
            }
        }
        return _enemy;
    }
}
