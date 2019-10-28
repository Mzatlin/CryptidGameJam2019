using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField]
    float interactDist = 10f;
    [SerializeField]
    private LayerMask interactLayer;
    Ray ray;
    RaycastHit hit;
    bool lastTouched = false;


    // Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDist);
        if (Physics.Raycast(ray, out hit, interactDist, interactLayer))
        {
            lastTouched = true;
            var interact = hit.transform.GetComponent<IInteractable>();
            if (interact != null && Input.GetKeyDown(KeyCode.E))
            {
                interact.RecieveInteraction();
            }
        }
        else
        {
            if (lastTouched)
            {
                lastTouched = false;
                Debug.Log("Remove Header");
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }


}