using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnClick : MonoBehaviour
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    FadeInController fade;
   
    void Start()
    {
        fade = GetComponent<FadeInController>();
        fade.Fade(0f, 0.1f);
    }
    public void OnClickFade()
    {
        fade.Fade(fadeAlpha, fadeDuration);
    }
}
