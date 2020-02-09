using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelOnEvent : MonoBehaviour
{
    OpenDoor door;
    LoadLevel level;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<OpenDoor>();
        if(door != null)
        {
            door.OnDoorOpen += HandleOpen;
        }
        level = GetComponent<LoadLevel>();
    }

    void HandleOpen()
    {
        StartCoroutine(NewScene());
    }

    IEnumerator NewScene()
    {
        yield return new WaitForSeconds(3f);
        level.LevelLoad();
    }
}
