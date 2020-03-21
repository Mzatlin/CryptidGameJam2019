using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeController : MonoBehaviour
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeOut", sprite);
    }



    IEnumerator FadeOut(SpriteRenderer render)
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = render.material.color;
            c.a = f;
            render.material.color = c;
            yield return new WaitForSeconds(0.005f);
        }
        gameObject.SetActive(false);
    }
}
