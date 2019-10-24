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


    // Update is called once per frame
    void FixedUpdate()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction);
        if(Physics.Raycast(ray, out hit, interactDist, interactLayer))
        {
            var interact = hit.transform.GetComponent<IInteractable>();
            if (interact != null && Input.GetKeyDown(KeyCode.E))
            {
                interact.RecieveInteraction();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }


}