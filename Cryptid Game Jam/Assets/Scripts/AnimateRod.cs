using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateRod : MonoBehaviour
{
    RodCastBobber cast;
    RodReelBackBobber reel;
    Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        reel = GetComponent<RodReelBackBobber>();
        reel.OnReel += HandleReel;
        cast = GetComponent<RodCastBobber>();
        cast.OnCast += HandleCast;
        animate = GetComponentInChildren<Animator>();
    }

    void HandleReel()
    {
        animate.Play("ReelBackRod");
    }

    void HandleCast()
    {
        animate.Play("FishingRodCast");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
