using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorOnStart : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
