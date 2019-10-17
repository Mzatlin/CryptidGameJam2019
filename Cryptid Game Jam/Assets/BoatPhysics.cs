using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatPhysics : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       // rb.AddForce(velocity);
       rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
