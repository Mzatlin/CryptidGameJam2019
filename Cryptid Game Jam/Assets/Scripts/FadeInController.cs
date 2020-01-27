using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{
    [SerializeField]
    Canvas fadeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if(fadeCanvas != null)
        {
            fadeCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(0.1f, 2.5f, false);
        }
        else
        {
            Debug.Log("No Fade Canvas Assigned!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
