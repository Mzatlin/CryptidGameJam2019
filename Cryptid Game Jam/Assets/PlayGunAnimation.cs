using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGunAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    ShootRifle shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<ShootRifle>();
        shoot.OnShoot += HandleShoot;
        animator = GetComponentInChildren<Animator>();
    }

    void HandleShoot()
    {
        //animator.SetBool("IsShooting", true);
        animator.Play("GunShotAnimation");
    }



}
