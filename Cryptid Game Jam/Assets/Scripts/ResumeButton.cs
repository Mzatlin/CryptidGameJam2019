using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResumeButton : MonoBehaviour
{
    public event Action OnResume = delegate { };
    // Update is called once per frame
    public void ResumeGame()
    {
        Debug.Log("Pressed");
        OnResume();
    }
}
