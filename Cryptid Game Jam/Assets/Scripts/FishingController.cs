using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    [SerializeField]
    BobberHitWater bobber;
    [SerializeField]
    HeaderText header;
    [SerializeField]
    ItemHolsterManager holster;
    [SerializeField]
    List<GameObject> fish = new List<GameObject>();
    RodReelBackBobber reelBack;
    [SerializeField]
    PlayerStatsSO playerstats;
    SpriteRenderer render;
    int index = 0;
    [SerializeField]
    Animator animate;
    Color original;

    FMOD.Studio.EventInstance FishOn;

    Coroutine fishRoutine = null;

    enum FishState {WatingForBite, Bite, Missed}
    [SerializeField]
    FishState fishing;

    bool isWatingForBite;
    // Start is called before the first frame update
    void Start()
    {
        reelBack = FindObjectOfType<RodReelBackBobber>();
        //   holster = FindObjectOfType<ItemHolsterManager>();
        //bobber = FindObjectOfType<BobberHitWater>();
        reelBack.OnReel += HandleReel;
        bobber.OnHitWater += HandleMinigame;
        render = bobber.GetComponentInChildren<SpriteRenderer>();
        animate = bobber.GetComponentInChildren<Animator>();
        fishing = FishState.Missed;
        original = render.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (fishing == FishState.Bite)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Fish Splash Out");
                FishOn.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                StartCoroutine(CatchDelay());
                render.color = original;
            }
            else
            {
                render.color = original;
                fishing = FishState.Missed;
            }

        }

 
    }

    void HandleReel()
    {
        render.color = original;
        fishing = FishState.Missed;
        if(fishRoutine != null)
        {
            StopCoroutine(fishRoutine);
        }

    }

    IEnumerator CatchDelay()
    {
        yield return new WaitForSeconds(.4f);
        //  holster.SetItem(fish[Random.Range(0, fish.Count - 1)]);
        if (index >= fish.Capacity)
        {
            index = 0;
        }
        holster.SetItem(fish[index]);
        if(index == 2)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Bridle Stinger");
            Debug.Log("You caught the bridle!");
        }

        if(index >= fish.Capacity)
        {
            index = 0;
        }
        index++;
        header.WriteHeader("Place in Front Chest");
        playerstats.isOccupied = false;
       // reelBack.RetrieveBobber();

    }

    void HandleMinigame()
    {
        fishing = FishState.WatingForBite;//isWatingForBite = true;
        fishRoutine = StartCoroutine(WaitForCatch());
    }

    IEnumerator WaitForCatch()
    {
        yield return new WaitForSeconds(Random.Range(5f,10f));
        Debug.Log("You got a Bite!");
        render.color = Color.red;
        FishOn = FMODUnity.RuntimeManager.CreateInstance("event:/Fish On the Hook");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(FishOn, bobber.GetComponent<Transform>(),bobber.GetComponent<Rigidbody>());
        FishOn.start();
        fishing = FishState.Bite;
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        render.color = original;
        Debug.Log("Too Slow!");
        fishing = FishState.Missed;
        FishOn.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
