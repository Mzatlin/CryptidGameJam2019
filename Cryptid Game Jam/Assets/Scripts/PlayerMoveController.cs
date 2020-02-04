using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerMoveController : MonoBehaviour, IMovable
{
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float sensitivity = 10f;
    [SerializeField]
    PlayerStatsSO player;
    PlayerPhysics physics;
    Rigidbody rb;
    float xMove, zMove, yRotation, xRotation, cameraRotationX;
    Vector3 moveHorizontal, moveVertical, moveVelocity, rotation;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<PlayerPhysics>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isOccupied || player.isDead)
        {
            StopMovement();
            return;
        }


        CalculateMovement();
        CalculateRotation();
    }

    public void StopMovement()
    {
        physics.SetVelocity(Vector3.zero);
        physics.SetRotation(Vector3.zero);
        physics.CameraRotation(0f);
    }

    public void CalculateRotation()
    {
        yRotation = Input.GetAxisRaw("Mouse X");
        rotation = new Vector3(0, yRotation, 0) * sensitivity;
        physics.SetRotation(rotation);

        xRotation = Input.GetAxisRaw("Mouse Y");
        cameraRotationX = xRotation * sensitivity;
        physics.CameraRotation(cameraRotationX);
    }

    public void CalculateMovement()
    {
        xMove = Input.GetAxis("Horizontal");
        moveHorizontal = transform.right * xMove;

        zMove = Input.GetAxis("Vertical");
        moveVertical = transform.forward * zMove;

        moveVelocity = (moveHorizontal + moveVertical) * speed;
        physics.SetVelocity(moveVelocity);
    }
}
