using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HolsterSystemSO : ScriptableObject
{
    public GameObject holsterPosition;
    public GameObject child;

    void SetItem(GameObject item)
    {
        RemoveItem(child);
        child = item;
        child.transform.position = holsterPosition.transform.position;
        child.transform.SetParent(holsterPosition.transform);
        child.SetActive(true);
    }

    void RemoveItem(GameObject item)
    {
        if (child != null)
        {
            child.SetActive(false);
            child.transform.SetParent(null);
            child = null;
        }
    }


}
