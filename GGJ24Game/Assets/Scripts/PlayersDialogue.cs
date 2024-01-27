using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayersDialogue : MonoBehaviour
{
    void Start()
    {
        DialogueManager.Instance.OnOpenPlayersDialogue += OpenPlayerDialogueHUD;
        DialogueManager.Instance.OnClosePlayersDialogue += ClosePlayerDialogueHUD;
    }

    void OpenPlayerDialogueHUD()
    {
        GameObject.Find("PlayerDialogueCanvas").transform.GetChild(0).gameObject.SetActive(true);
    }

    void ClosePlayerDialogueHUD()
    {
        GameObject.Find("DialogueText").GetComponent<TextMeshProUGUI>().text = null;
        GameObject.Find("PlayerDialogueCanvas").transform.GetChild(0).gameObject.SetActive(false);
    }
}
