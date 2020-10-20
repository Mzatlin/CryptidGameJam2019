using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleLevelChange : MonoBehaviour
{
    InteractionController interact;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<InteractionController>();
        interact.OnInteract += HandleInteract;
    }

    void HandleInteract()
    {
        SceneManager.LoadScene("Level1Lake", LoadSceneMode.Single);
    }
}
