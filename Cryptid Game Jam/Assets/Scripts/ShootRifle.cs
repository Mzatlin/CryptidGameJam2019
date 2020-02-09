using System;
using UnityEngine;

public class ShootRifle : MonoBehaviour
{
    public static Action OnShoot = delegate { };

    public static bool isShootable = true;
    [SerializeField]
    float shootRange = 10f;
    [SerializeField]
    float timeBeforeFire = .5f;
    float fireRate = .4f;
    Ray ray;
    RaycastHit hit;
    Animator animate;
    [SerializeField]
    LayerMask hittableLayer;
    Camera playerCamera;
    // Start is called before the first frame update
    void Awake()
    {
        playerCamera = GetComponentInParent<Camera>();
        animate = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (CanFire())
            {
                FireWeapon();
            }
        }
    }


    public bool CanFire()
    {
        if (isShootable && Time.time >= timeBeforeFire)
        {
            timeBeforeFire = Time.time + fireRate;
            return true;
        }
  
        return false;
    }

    void FireWeapon()
    {
        OnShoot();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Shotgun Shot");
        animate.Play("gunshot");
        ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * shootRange);
        if (Physics.Raycast(ray, out hit, shootRange, hittableLayer))
        {
            var target = hit.transform.GetComponent<IHittable>();
            if (target != null)
            {
                target.RecieveDamage();
            }
        }

    }
}
