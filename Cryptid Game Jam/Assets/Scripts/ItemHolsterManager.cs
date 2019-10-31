using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolsterManager : MonoBehaviour
{
    [SerializeField]
    GameObject holsterPosition;
    [SerializeField]
    public GameObject child;
    [SerializeField]
    GameObject startingItem;
    [SerializeField]
    bool canRotate = false;

    void Awake()
    {
        if(startingItem != null)
        {
            SetItem(startingItem);
        }
    }

   public void SetItem(GameObject item)
    {
        RemoveItem(child);
        child = item;
        child.transform.position = holsterPosition.transform.position;
        if (canRotate)
        {
        child.transform.rotation = holsterPosition.transform.rotation;
        }
        child.transform.SetParent(holsterPosition.transform);
        child.SetActive(true);
    }

    public void RemoveItem(GameObject item)
    {
        if (child != null)
        {
            child.transform.SetParent(null);
            child.SetActive(false);
            child = null;
        }
    }
}
