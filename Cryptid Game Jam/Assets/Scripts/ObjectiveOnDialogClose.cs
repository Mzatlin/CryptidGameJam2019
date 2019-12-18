using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOnDialogClose : MonoBehaviour
{
    [SerializeField]
    HeaderText header;
    [SerializeField]
    ObjectiveSystem objectiveSystem;
    HandleDialogInteraction dialog;
    Objective playerObjective;
    // Start is called before the first frame update
    void Start()
    {
        playerObjective = new Objective("Head to boat");
        dialog = GetComponent<HandleDialogInteraction>();
        dialog.OnClosed += HandleCloseDialog;
    }

    void HandleCloseDialog()
    {
        objectiveSystem.ChangeObjective(playerObjective);
    }
}
