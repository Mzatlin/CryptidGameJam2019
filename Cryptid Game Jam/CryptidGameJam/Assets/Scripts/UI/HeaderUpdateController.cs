using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUpdateController : WriterBase
{
    [SerializeField]
    HeaderText header;
    Coroutine headerRoutine = null;

    void Awake()
    {
        header.message = "";
        textContent.text = "";
        header.OnWrite += HandleWrite;
    }

    void HandleWrite()
    {
        textContent.text = "";
        if (headerRoutine != null)
        {
            StopCoroutine(headerRoutine);
        }
        headerRoutine = StartCoroutine(TypeMessage(header.message));
    }
    void OnDestroy()
    {
        header.OnWrite -= HandleWrite;
        StopAllCoroutines();
    }


}
