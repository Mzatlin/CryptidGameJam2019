using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatPhysics : MonoBehaviour
{
    Vector3 velocity;
    float rotation;
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
    public void SetRotation(float _rotation)
    {
        rotation = _rotation; 
    }
    public void StopBoat()
    {
        rb.velocity = Vector3.zero;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(velocity);
        rb.AddTorque(transform.up * rotation * Time.deltaTime);
        // rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        // rb.AddForce(-Vector3.Project(rb.velocity, transform.right) * rotation);
        //  transform.Translate(velocity*Time.deltaTime);
    }
}
