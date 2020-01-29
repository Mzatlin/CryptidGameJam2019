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

    Ray ray;
    bool lastTouched = false;
    bool isInteracted = false;
    IInteractable interact;
    RaycastHit _hit;

    public RaycastHit Hit => _hit;



    // Update is called once per frame
    //todo: have another class that attempts an interaction based on the hit variable. CanInteract - interact != null - Also based on other criteria  
    void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
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