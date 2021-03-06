﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(ShipEngineHandleInteract))]
public class RepairController : MonoBehaviour
{
    public event Action OnExit = delegate { };
    public event Action OnSuccess = delegate { };

    [SerializeField]
    KeyCode[] keys;
    ShipEngineHandleInteract interact;
    List<KeyCode> finalKeys = new List<KeyCode>();
    KeyCode listedKey;
    [SerializeField]
    TextMeshProUGUI[] keyText;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<ShipEngineHandleInteract>();
        interact.OnRepairStart += HandleRepair;
    }

    void HandleRepair()
    {
        index = 0;
        finalKeys.Clear();

        for (int i = 0; i < keyText.Length; i++)
        {
            finalKeys.Add(keys[UnityEngine.Random.Range(0, keys.Length - 1)]);
        }
        for (int i = 0; i < keyText.Length; i++)
        {
            keyText[i].text = finalKeys[i].ToString();
            keyText[i].faceColor = new Color32(0, 0, 0, 255);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ShipEngineHandleInteract.isMiniGameActive)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(finalKeys[index]))
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Engine Fix Action");
                    keyText[index].faceColor = new Color32(0, 255, 0, 255);
                    if (index >= keyText.Length - 1)
                    {
                        StartCoroutine(WinDelay());
                    }
                    else
                    {
                        index++;
                    }

                }
                else
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Engine Fix Fail");
                    Debug.Log("Wrong Key!");
                    OnExit();
                }

            }
        }
    }

 IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(0.2f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Engine Fix Success");
        OnSuccess();
        OnExit();
    }
}

