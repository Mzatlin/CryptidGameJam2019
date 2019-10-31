using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUpdateController : WriterBase
{
    [SerializeField]
    HeaderText header;
    Coroutine headerRoutine = null;

    // Start is called before the first frame update
    void Awake()
    {
        header.message = "";
        textContent.text = "";
        header.OnWrite += HandleWrite;
    }

    void Start()
    {
        header.WriteHeader("Repair Engine");
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


}
