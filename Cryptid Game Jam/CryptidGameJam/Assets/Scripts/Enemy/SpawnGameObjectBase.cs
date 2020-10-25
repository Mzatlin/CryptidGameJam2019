using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnGameObjectBase : MonoBehaviour
{
    [SerializeField]
    protected List<GameObject> SpawnObjects = new List<GameObject>();
    [SerializeField]
    protected List<Transform> SpawnLocations = new List<Transform>();
    protected abstract void SpawnItem();
}
