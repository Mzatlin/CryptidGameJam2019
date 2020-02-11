using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnStart : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO playerStats;
    [SerializeField]
    Canvas cursor;
    IFade fade;
    // Start is called before the first frame update
    void Start()
    {
        if(cursor != null)
        {
            cursor.enabled = false;
        }
        fade = GetComponent<IFade>();
        if(fade != null)
        {
            fade.OnEndFade += HandleFade;
        }
        else
        {
            Debug.Log("No fade found");
        }
        playerStats.isOccupied = true;
    }

    void HandleFade()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        if (cursor != null)
        {
            cursor.enabled = true;
        }
        playerStats.ResetPlayerStats();
    }
}
