﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRifle : MonoBehaviour
{
    [SerializeField]
    float shootRange = 10f;
    [SerializeField]
    float timeBeforeFire = .01f;
    float fireTime = 0;
    Ray ray;
    RaycastHit hit;
    Animator animate;
    [SerializeField]
    LayerMask hittableLayer;
    // Start is called before the first frame update
    void Awake()
    {
        animate = GetComponentInChildren<Animator>();
        fireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
      //  if (fireTime >= timeBeforeFire)
    //    {
            FireWeapon();
      //    fireTime = 0;
     //   }
      //  fireTime += Time.fixedDeltaTime;

    }

    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Shotgun Shot");
            animate.Play("gunshot");
            ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * shootRange);
            if (Physics.Raycast(ray, out hit, shootRange,hittableLayer))
            {
                var target = hit.transform.GetComponent<IHittable>();
                if (target != null)
                {
                    target.RecieveDamage();
                }
            }
        }
    }
}
