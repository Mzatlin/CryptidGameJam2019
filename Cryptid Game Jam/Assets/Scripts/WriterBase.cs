using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class WriterBase : MonoBehaviour
{
    
    public float typingSpeed = 0.05f;
    [SerializeField]
    protected TextMeshProUGUI textContent;

  protected virtual IEnumerator TypeMessage(string content)
    {
        foreach (char i in content.ToCharArray())
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Medium Voice");
            textContent.text += i;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
}
