using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    string name;
    // Start is called before the first frame update
    public void LevelLoad()
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

}
