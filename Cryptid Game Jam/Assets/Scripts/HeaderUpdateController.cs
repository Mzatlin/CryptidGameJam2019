using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUpdateController : WriterBase
{
    [SerializeField]
    HeaderText header;
    Coroutine headerRoutine = null;
  //  private static bool created = false;
    private static HeaderUpdateController _instance;

    public static HeaderUpdateController Instance { get { return _instance; } }


    // Start is called before the first frame update
    void Awake()
    {
 

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        /* if (!created)
         {
           
             created = true;
         }*/

        header.message = "";
        textContent.text = "";
        header.OnWrite += HandleWrite;
    }

    void Start()
    {
     //   header.WriteHeader("Repair Engine");
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
