using System.Collections;
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
      //      fireTime = 0;
     //   }
      //  fireTime += Time.fixedDeltaTime;

    }

    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animate.Play("gunshot");
            //PlayOneShot
            ray = new Ray(transform.position, -transform.up);
            Debug.DrawRay(ray.origin, ray.direction * shootRange);
            if (Physics.Raycast(ray, out hit, shootRange))
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
