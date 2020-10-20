using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    PlayerStatsSO playerStats;
    // Start is called before the first frame update
    void Awake()
    {
        playerStats.ResetPlayerStats();
    }


}
