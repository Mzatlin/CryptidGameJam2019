using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectBase : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> SpawnObjects = new List<GameObject>();
    [SerializeField]
    protected List<Transform> SpawnLocations = new List<Transform>();

    protected virtual void SpawnItem()
    {
        var enemyToSpawn = GetInactiveItem();
        if (enemyToSpawn != null)
        {
            SetupObject(enemyToSpawn);
        }
    }

    protected virtual void SetupObject(GameObject enemyToSpawn)
    {
        enemyToSpawn.SetActive(true);
    }

    protected virtual GameObject GetInactiveItem()
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
