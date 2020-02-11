using System;
using System.Collections;
using UnityEngine;

public class PlayAnimationOnDoorOpen : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    OpenDoor open;
    // Start is called before the first frame update
    void Start()
    {
        open = FindObjectOfType<OpenDoor>();
        open.OnDoorOpen += HandleOpenDoor;
        animator = GetComponentInChildren<Animator>();
    }

    private void HandleOpenDoor()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("IsAnimate", true);
    }

}
