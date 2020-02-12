using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RodReelBackBobber : MonoBehaviour
{
    public event Action OnReel = delegate { };

    [SerializeField]
    GameObject bobber;
    [SerializeField]
    PlayerStatsSO stats;
    BobberHitWater water;
    bool isReelable = false;
    // Start is called before the first frame update
    void Awake()
    {
        water = bobber.GetComponent<BobberHitWater>();
        water.OnHitWater += HandleReelBack;
        water.OnHitObject += HandleRetrieve;
    }

    // Update is called once per frame
    void Update()
    {
        ReelBobber();
    }

    void ReelBobber()
    {
        if (isReelable && Input.GetButtonDown("Fire1"))
        {
            RetrieveBobber();
        }
    }

    void HandleReelBack()
    {
        isReelable = true;
    }
    void HandleRetrieve()
    {
        RetrieveBobber();
    }

    public void RetrieveBobber()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Reel In");
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        OnReel();
        stats.isOccupied = false;
        bobber.transform.SetParent(transform);
        bobber.transform.position = transform.position;
        bobber.SetActive(false);
        isReelable = false;

    }
}
