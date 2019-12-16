using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectiveController : MonoBehaviour
{
    public Objective objective; 
    [SerializeField]
    HeaderText header;
    [SerializeField]
    List<string> objectives = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
      if(objectives.Count >=1)
        {
            header.WriteHeader(objectives[0]);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
