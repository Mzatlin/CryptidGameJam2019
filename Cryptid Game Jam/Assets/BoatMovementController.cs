using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoatPhysics))]
public class BoatMovementController : MonoBehaviour, IMovable
{
    [SerializeField]
    float boatSpeed = 10f;
    [SerializeField]
    float boatTorque = 10f;
    float xMove, zMove;
    Vector3 moveVertical, moveHorizontal;
    BoatPhysics physics;

    public static bool isMotorActive = false;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<BoatPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMotorActive)
        {
            physics.SetVelocity(Vector3.zero);
            return;
        }
        CalculateMovement();
        CalculateRotation();
    }

    public void CalculateMovement()
    {
        zMove = Input.GetAxis("Vertical");
        moveVertical = -(transform.forward * zMove);
        physics.SetVelocity(moveVertical*boatSpeed);
    }

    public void CalculateRotation()
    {
        xMove = Input.GetAxis("Horizontal");
     //   moveHorizontal = (transform.right * xMove);
        physics.SetRotation(xMove * boatTorque);
    }
}
