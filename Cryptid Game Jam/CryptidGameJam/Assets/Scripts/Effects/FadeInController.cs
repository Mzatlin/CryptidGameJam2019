using UnityEngine;
using UnityEngine.UI;
using System;

public class FadeInController : MonoBehaviour, IFade
{
    public event Action OnFade = delegate { };
    public event Action OnEndFade = delegate { };

    [SerializeField]
    Canvas fadeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (fadeCanvas == null)
        {
            Debug.Log("No Fade Canvas Assigned!");
        }
    }

    public void Fade(float alpha, float duration)
    {
        OnFade();
        fadeCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(alpha, duration, true);
        OnEndFade();
    }




}
