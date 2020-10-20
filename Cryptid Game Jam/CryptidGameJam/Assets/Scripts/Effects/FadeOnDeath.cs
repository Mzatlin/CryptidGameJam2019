using UnityEngine;
using UnityEngine.UI;

public class FadeOnDeath : MonoBehaviour
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    IFade fade;
    HealthController health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
        fade = GetComponent<IFade>();
        if(fade != null)
        {
            fade.Fade(0f, 0.01f);
        }
    }

    void HandleDie()
    {



        if(fade != null)
        {

            fade.Fade(fadeAlpha, fadeDuration);
        }
        else
        {
            Debug.Log("Fade Not Found");
        }
    }
}
