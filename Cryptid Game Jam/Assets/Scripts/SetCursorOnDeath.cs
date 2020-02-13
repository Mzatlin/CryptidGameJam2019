using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorOnDeath : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorTexture;
    HealthController health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthController>();
        health.OnDie += HandleDie;
    }

    private void HandleDie()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
    }


}
