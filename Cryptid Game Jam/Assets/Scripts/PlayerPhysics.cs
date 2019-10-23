using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerPhysics : MonoBehaviour
{
    Vector3 velocity, rotation;
    Rigidbody rb;
    Camera cam;
    float cameraRotationx = 0f, cameraLimit = 85f;
    float rotationCurrent = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    public void SetVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void SetRotation(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void CameraRotation(float _camera)
    {
        cameraRotationx = _camera;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            rotationCurrent -= cameraRotationx;
            rotationCurrent = Mathf.Clamp(rotationCurrent, -cameraLimit, cameraLimit);
            cam.transform.localEulerAngles = new Vector3(rotationCurrent, 0, 0);
        }
    }
}
