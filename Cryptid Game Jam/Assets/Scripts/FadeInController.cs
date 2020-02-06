using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour, IFade
{
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
        fadeCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(alpha, duration, true);
    }




}
