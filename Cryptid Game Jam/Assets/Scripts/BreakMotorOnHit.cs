using UnityEngine;

public class BreakMotorOnHit : MonoBehaviour
{
    HealthController health;
    StopMotor stop;
    InteractionController interact;
    BoatAccelerationAudio boat;
    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<InteractionController>();
        stop = GetComponent<StopMotor>();
        health = GetComponentInParent<HealthController>();
        health.OnHit += HandleDamage;
        boat = GetComponentInChildren<BoatAccelerationAudio>();
    }

    void HandleDamage()
    {
        stop.StopBoat();
        interact.IsInteractable = false;
        if(boat != null)
        {
            boat.enabled = false;
        }
    }

}
