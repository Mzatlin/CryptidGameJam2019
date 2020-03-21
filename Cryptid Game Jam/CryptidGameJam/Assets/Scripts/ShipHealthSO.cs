using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipHealthSO : ScriptableObject
{
    public int health;
    public bool isDead;
    public bool isBeingDriven;
}
