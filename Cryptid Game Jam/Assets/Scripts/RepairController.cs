using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepairController : MonoBehaviour
{

    [SerializeField]
    KeyCode[] keys;
    List<KeyCode> finalKeys = new List<KeyCode>();
    [SerializeField]
    TextMeshProUGUI[] images;
    private int index = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Length; i++)
        {
            finalKeys.Add(keys[Random.Range(0, keys.Length)]);
        }
        for (int i = 0; i< images.Length; i++)
        {
            images[i].text = finalKeys[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(finalKeys[index]))
            {
                Debug.Log("You pressed the right key!");
                images[index].faceColor = new Color32(255, 0, 0, 255);
                if(index >= images.Length-1)
                {
               //     RepairCanvas.enabled = false;
                }
                else
                {
                    index++;
                }
            } 
        }
    }
}
