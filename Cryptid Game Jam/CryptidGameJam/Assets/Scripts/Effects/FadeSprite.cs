using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSprite : MonoBehaviour, ISpriteFade
{

    public void FadeSpriteIn(GameObject item)
    {
        StartCoroutine(FadeDelay(item));
    }

    IEnumerator FadeDelay(GameObject item)
    {
        SpriteRenderer sprite = item.GetComponentInChildren<SpriteRenderer>();
        if(sprite != null)
        {
            for (float f = 0f; f <= 1.05f; f += 0.05f)
            {
                Color c = sprite.material.color;
                c.a = f;
                sprite.material.color = c;
                yield return new WaitForSeconds(0.005f);
            }
        }
        else
        {
            Debug.Log("No sprite found");
        }
    }
}
