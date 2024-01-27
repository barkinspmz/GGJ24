using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EscOption : MonoBehaviour
{
    
    void Start()
    {
        DialogueManager.Instance.OnOpenPlayersDialogue += OpenEsc;
        DialogueManager.Instance.OnClosePlayersDialogue += CloseEsc;
    }

    
    void OpenEsc()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
    }
    
    void CloseEsc()
    {
        this.gameObject.GetComponent<Image>().enabled = false;
    }
}
