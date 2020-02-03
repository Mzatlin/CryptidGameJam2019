using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealOnDoorOpen : MonoBehaviour
{
    OpenDoor open;
    [SerializeField]
    GameObject itemToReveal;
    // Start is called before the first frame update
    void Start()
    {
        open = GetComponent<OpenDoor>();
        open.OnDoorOpen += HandleDoor;
        itemToReveal.SetActive(false);
    }

    void HandleDoor()
    {
        itemToReveal.SetActive(true);
    }
}
