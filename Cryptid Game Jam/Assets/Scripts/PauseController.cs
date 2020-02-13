using UnityEngine;
using System;

public class PauseController : MonoBehaviour
{

    public event Action OnPause = delegate { };
    public event Action OnUnPause = delegate { };
    [SerializeField]
    PlayerStatsSO playerStats;

    public static bool isPaused;

    void Start()
    {
        isPaused = false;    
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPaused && Input.GetKeyUp(KeyCode.Escape) && !playerStats.isDead)
        {
            OnPause();
        }

    }
}
