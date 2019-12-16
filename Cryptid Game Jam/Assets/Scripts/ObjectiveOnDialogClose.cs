using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOnDialogClose : MonoBehaviour
{
    [SerializeField]
    HeaderText header;
    HandleDialogInteraction dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<HandleDialogInteraction>();
        dialog.OnClosed += HandleCloseDialog;
    }

    void HandleCloseDialog()
    {
        Debug.Log("clicked");
        header.WriteHeader("Get onto the boat.");
    }
}
