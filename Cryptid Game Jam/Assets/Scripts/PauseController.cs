using UnityEngine;
using System;

public class PauseController : MonoBehaviour
{

    public event Action OnPause = delegate { };
    [SerializeField]
    PlayerStatsSO playerStats;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !playerStats.isDead)
        {
            OnPause();
        }
    }
}
