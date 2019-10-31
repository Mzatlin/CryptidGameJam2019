using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToPositions : MonoBehaviour
{
    [SerializeField]
    List<GameObject>SpawnLocations = new List<GameObject>();
    [SerializeField]
    List<GameObject> SpawnItems = new List<GameObject>();
    [SerializeField]
    float spawnAmount=3f;
    [SerializeField]
    float delay = 3f;
    [SerializeField]
    int startingHealth = 3;
    HealthController health;

    void Start()
    {
        SetupItems();  
    }
    void OnEnable()
    {
        InvokeRepeating("SpawnItem", Random.Range(spawnAmount,spawnAmount+2),delay);
    }

    void SetupItems()
    {
        for (int i = 0; i < SpawnItems.Count; i++)
        {
            SpawnItems[i].SetActive(false);
            health = SpawnItems[i].GetComponent<HealthController>();
            if (health != null)
            {
                SpawnItems[i].GetComponent<HealthController>().IsDead = true;
            }
        }
    }

    void SpawnItem()
    {
        Debug.Log("Spawn");
        var enemyToSpawn = GetInactiveItem();
        if (enemyToSpawn != null)
        {
            health = enemyToSpawn.GetComponent<HealthController>();
            enemyToSpawn.transform.position = GetRandomSpawnLocation().transform.position;
            health.IsDead = false;
            health.CurrentHealth = startingHealth;
            enemyToSpawn.SetActive(true);
        }

    }

    GameObject GetRandomSpawnLocation()
    {
        return SpawnLocations[Random.Range(0, SpawnLocations.Capacity)];
    }

    GameObject GetInactiveItem()
    {
        GameObject _enemy = null;
        for (int i = 0; i < SpawnItems.Count; i++)
        {
            if (SpawnItems[i].activeInHierarchy == false)
            {
                _enemy = SpawnItems[i];
                break;
            }
        }
        return _enemy;
    }

}
