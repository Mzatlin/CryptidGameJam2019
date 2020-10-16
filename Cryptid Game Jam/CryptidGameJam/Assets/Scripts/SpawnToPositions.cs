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

    GameObject GetRandomSpawnLocation()
    {
        return SpawnLocations[Random.Range(0, SpawnLocations.Count)];
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
