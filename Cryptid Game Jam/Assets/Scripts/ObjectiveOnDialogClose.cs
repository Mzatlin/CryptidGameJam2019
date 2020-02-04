using UnityEngine;

public class ObjectiveOnDialogClose : MonoBehaviour
{
    [SerializeField]
    string objectiveTitle;
    [SerializeField]
    HeaderText header;
    [SerializeField]
    ObjectiveSystem objectiveSystem;
    [SerializeField]
    ObjectiveSO playerObjective;
    HandleDialogInteraction dialog;

    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<HandleDialogInteraction>();
        dialog.OnClosed += HandleCloseDialog;
    }

    void HandleCloseDialog()
    {
        objectiveSystem.ChangeObjective(playerObjective);
    }
}
