using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogUpdateController : WriterBase
{
    public event Action OnCloseDialog = delegate { };

    [SerializeField]
    MessageBoxText messageBox;
    [SerializeField]
    PlayerStatsSO playerStats;
    [SerializeField]
    Canvas panel;
    [SerializeField]
    TextMeshProUGUI continueText;
    private int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        panel.enabled = false;
        messageBox.dialogMessages = new List<string>();
        textContent.text = "";
        messageBox.OnWriteDialog += HandleWrite;
        continueText.enabled = false;
    }


    void Update()
    {
        if (panel.enabled)
        {
            if (textContent.text == messageBox.dialogMessages[index])
            {
                continueText.enabled = true;
            }
        }

        if(continueText.enabled && Input.GetKeyDown(KeyCode.Return))
        {
            if(index >= messageBox.dialogMessages.Count - 1)
            {
                CloseDialog();
            }
            else
            {
                textContent.text = "";
                index++;
                StartDialog();
            }
        }
    }

    void StartDialog()
    {
        playerStats.isOccupied = true;
        continueText.enabled = false;
        StopCoroutine(TypeMessage(messageBox.dialogMessages[index]));
        StartCoroutine(TypeMessage(messageBox.dialogMessages[index]));
    }

    void CloseDialog()
    {
        playerStats.isOccupied = false;
        panel.enabled = false;
        textContent.text = "";
        continueText.enabled = false;
        OnCloseDialog();
    }

    void HandleWrite()
    {
        if (!panel.enabled)
        {
            panel.enabled = true;
            index = 0;
            StartDialog();
        }


    }

    protected override IEnumerator TypeMessage(string content)
    {
        foreach (char i in content.ToCharArray())
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Medium Voice");
            textContent.text += i;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
}
