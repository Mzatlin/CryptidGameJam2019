using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnClick : MonoBehaviour
{
    [SerializeField]
    float fadeAlpha;
    [SerializeField]
    float fadeDuration;
    [SerializeField]
    Canvas fadeCanvas;
    FadeInController fade;
   
    void Start()
    {
        fadeCanvas.enabled = false;
        fade = GetComponent<FadeInController>();
        fade.Fade(0f, 0.1f);
    }
    public void OnClickFade()
    {
        fadeCanvas.enabled = true;
        fade.Fade(fadeAlpha, fadeDuration);
    }
}
