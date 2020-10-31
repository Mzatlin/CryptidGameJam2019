using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    HealthController health;
    SpriteRenderer render;
    EnemyFollowTarget follow;
    HitOnTouch hit;
    Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        follow = GetComponent<EnemyFollowTarget>();
        hit = GetComponent<HitOnTouch>();
        health = GetComponent<HealthController>();
        render = GetComponentInChildren<SpriteRenderer>();
        originalColor = render.color;
        if(health != null)
        {
            health.OnDie += HandleDie;
        }
    }

    void HandleDie()
    {
        //render.color = new Color(1f, 1f, 1f, Mathf.PingPong(Time.time * 5f,1f));
        if(render != null)
        {
            render.color = originalColor;
        }
        if(hit != null)
        {
            hit.enabled = false;
        }
        if(follow != null)
        {
            follow.enabled = false;
        }

        StartCoroutine("Fade");
        StartCoroutine("DeathDelay");
    }

    IEnumerator Fade()
    {
        for(float f = 1f; f>= -0.05f; f-= 0.05f)
        {
            Color c = render.material.color;
            c.a = f;
            render.material.color = c;
            yield return new WaitForSeconds(0.0005f);
        }
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }

}
