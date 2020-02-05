using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcealOnDoorOpen : MonoBehaviour
{
    [SerializeField]
    GameObject itemToConceal;
    OpenDoor open;
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<OpenDoor>();
        open.OnDoorOpen += HandleDoorOpen;
        itemToConceal.SetActive(true);
    }

    void HandleDoorOpen()
    {
        itemToConceal.SetActive(false);
    }

}
