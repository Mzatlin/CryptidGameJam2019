using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthController : HealthBase
{
    [FMODUnity.EventRef]
    public string path1;

    [FMODUnity.EventRef]
    public string path2;


    public event Action OnDie = delegate { };
    [SerializeField]
    private int currentHealth = 1;
    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private bool isDead;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public bool IsDead { get => isDead; set => isDead = value; }

    protected override void ProcessDamage()
    {
        if (IsDead) return;
        base.ProcessDamage();
        CurrentHealth -= 1;
        FMODUnity.RuntimeManager.PlayOneShot(path1, GetComponent<Transform>().position);
        if (currentHealth <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(path2, GetComponent<Transform>().position);
            IsDead = true;
            OnDie();
        }

    }
}
