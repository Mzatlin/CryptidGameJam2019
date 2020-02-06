using UnityEngine;

public class FadeOnStart : MonoBehaviour
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;

    void Start()
    {
        var fade = GetComponent<IFade>();
        if (fade != null)
        {
            fade.Fade(fadeAlpha, fadeDuration);
        }
        else
        {
            Debug.Log("Fade cannot be found");
        }
    }

}
