using UnityEngine;
using System;

public class PauseController : MonoBehaviour
{

    public event Action OnPause = delegate { };

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
        if (Input.GetKeyUp(KeyCode.Escape) && !playerStats.isDead)
        {
            OnPause();
        }

    }
}
