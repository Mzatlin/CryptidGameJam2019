using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUpdateController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textContent;
    [SerializeField]
    HeaderText header;
    [SerializeField]
    private float typingSpeed = 0.05f;

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

    IEnumerator TypeMessage(string content)
    {
        foreach(char i in content.ToCharArray())
        {
            textContent.text += i;
            yield return new WaitForSeconds(typingSpeed);
        }
      
    }

}
