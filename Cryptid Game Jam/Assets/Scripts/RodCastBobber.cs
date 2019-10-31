using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCastBobber : MonoBehaviour
{
    [SerializeField]
    float castingRange = 20f;
    [SerializeField]
    PlayerStatsSO stats; 
    [SerializeField]
    GameObject bobber;
    Ray ray;
    RaycastHit hit;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        if(bobber == null)
        {
            Debug.Log("No reference to the bobber was found. Please Attach it to the RodCastBobber Component");
        }
        else
        {
            bobber.SetActive(false);
        }

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CastBobber();
    }
    void CastBobber()
    {
        if (Input.GetButtonDown("Fire1") && !stats.isOccupied)
        {
            if (!bobber.activeInHierarchy)
            {
                stats.isOccupied = true;
                bobber.SetActive(true);
                bobber.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * castingRange);
                bobber.transform.parent = null;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Rod Cast");
            }
        }

    }
}
