using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionUpdateController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI content;
    [SerializeField]
    DescriptionText descObject;

    void Awake()
    {
        descObject.description = "";
        content.text = "";
        descObject.OnDescWrite += HandleWrite;
    }

    void HandleWrite()
    {
        content.text = descObject.description;
    }
}
