using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepairController : MonoBehaviour
{

    public static bool isActive = false;
    [SerializeField]
    KeyCode[] keys;
    [SerializeField]
    TextMeshProUGUI[] images;
    [SerializeField]
    Canvas RepairCanvas;
    [SerializeField]
    Dictionary<KeyCode, string> keyPresses = new Dictionary<KeyCode, string>();
    private int index = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        RepairCanvas.enabled = true;
        for(int i = 0; i< images.Length; i++)
        {
            images[i].text = keys[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(keys[index]))
            {
                Debug.Log("You pressed the right key!");
                images[index].faceColor = new Color32(255, 0, 0, 255);
                if(index >= images.Length-1)
                {
                    RepairCanvas.enabled = false;
                }
                else
                {
                    index++;
                }
            } 
        }
    }
}
