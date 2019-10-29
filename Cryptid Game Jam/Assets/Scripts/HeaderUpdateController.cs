using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUpdateController : WriterBase
{
    [SerializeField]
    HeaderText header;

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
        StopCoroutine(TypeMessage(header.message));
        StartCoroutine(TypeMessage(header.message));
    }


}
