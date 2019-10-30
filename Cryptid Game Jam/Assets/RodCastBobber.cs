using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCastBobber : MonoBehaviour
{
    [SerializeField]
    float castingRange = 20f;
    [SerializeField]
    GameObject bobber;
    Ray ray;
    RaycastHit hit;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        bobber.SetActive(false);
        rb = bobber.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CastBobber();
    }
    void CastBobber()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!bobber.activeInHierarchy)
            {
                bobber.SetActive(true);
                bobber.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * castingRange);
                bobber.transform.parent = null;
            }
        }

    }
}
