using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diary1SE : MonoBehaviour
{
    
    [SerializeField]
    MessageBoxText message;
    [SerializeField]
    List<string> diary = new List<string>();
    DialogUpdateController dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog = GetComponent<DialogUpdateController>();
        dialog.OnCloseDialog += HandleCloseDialog;
        message.WriteDialog(diary);
    }

    void HandleCloseDialog()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
