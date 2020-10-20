using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoadLevel : MonoBehaviour, ILoadScene
{
    public event Action OnStartLoad = delegate { };
    [SerializeField]
    string name;
    // Start is called before the first frame update
    public void LevelLoad()
    {
        OnStartLoad();
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
