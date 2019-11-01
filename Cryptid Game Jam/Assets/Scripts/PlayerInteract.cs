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
    RaycastHit hit;
    bool lastTouched = false;
    bool isInteracted = false;
    IInteractable interact;


    // Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDist);
        if (Physics.Raycast(ray, out hit, interactDist, interactLayer) && !playerStats.isOccupied)
        {

            interact = hit.collider.transform.GetComponent<IInteractable>();
            if (interact != null)
            {
                lastTouched = true;
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
            if (lastTouched)
            {
                lastTouched = false;
                if (interact != null)
                {
                    interact.ReceiveHoverLeave();
                }

            }

        }
    }


}