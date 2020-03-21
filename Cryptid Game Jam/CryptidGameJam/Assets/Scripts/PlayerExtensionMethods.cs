using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerExtensionMethods 
{
    public static void ResetPlayerStats(this PlayerStatsSO playerStats)
    {
        playerStats.isDead = false;
        playerStats.isOccupied = false;
    }

    public static void KillPlayer(this PlayerStatsSO playerStats)
    {
        playerStats.isDead = true;
    }

    public static void ResetPlayerMovement(this PlayerMoveController movement)
    {
        movement.StopMovement();
        movement.GetComponent<Rigidbody>().Sleep();
    }
}
