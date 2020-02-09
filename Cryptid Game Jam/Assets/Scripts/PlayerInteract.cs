using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    float interactDist = 10f;
    [SerializeField]
    private LayerMask interactLayer;
    [SerializeField]
    PlayerStatsSO playerStats;

    Camera playerCamera;
    Ray ray;
    bool lastTouched = false;
    bool isInteracted = false;
    IInteractable interact;
    RaycastHit _hit;

    public RaycastHit Hit => _hit;


    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    void FixedUpdate()
    {
        DrawRaycast();
    }

    void DrawRaycast()
    {
        ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDist);
        if (Physics.Raycast(ray, out _hit, interactDist, interactLayer) && !playerStats.isOccupied && !playerStats.isDead)
        {
            interact = _hit.collider.transform.GetComponent<IInteractable>();
            if (interact != null)
            {
                interact.ReceiveMouseHover();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.ReceiveInteraction();
                    interact.ReceiveHoverLeave();
                }
            }
        }
        else
        {
            if (interact != null)
            {
                interact.ReceiveHoverLeave();
            }
        }
    }

}