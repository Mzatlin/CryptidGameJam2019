using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKnock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Knock());
    }


    IEnumerator Knock()
    {
        yield return new WaitForSeconds(.3f);
        Debug.Log("Knock");
        yield return new WaitForSeconds(.3f);
        Debug.Log("Knock");
        yield return new WaitForSeconds(.3f);
        Debug.Log("Knock");
    }

}
