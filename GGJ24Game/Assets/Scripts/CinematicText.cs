using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CinematicText : MonoBehaviour
{
    [SerializeField] private string[] texts;

    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private float _waitingSecondBetweenDialogues;
    [SerializeField] private float _waitingSecondBetweenTextChars;
    [SerializeField] private float _waitingSecondCloseCinematic;

    public Animator changeSceneObj;
    private void Start()
    {
        StartCoroutine(DialogueFlow());
    }

    IEnumerator DialogueFlow()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < texts.Length; i++)
        {
            foreach (var a in texts[i])
            {
                playerText.text += a.ToString();

                if (i.ToString() == "." || i.ToString() == "?") { yield return new WaitForSeconds(1f); }
                else { yield return new WaitForSeconds(_waitingSecondBetweenTextChars); }
            }

            yield return new WaitForSeconds(_waitingSecondBetweenDialogues);

            playerText.text = string.Empty;
        }
        changeSceneObj.SetTrigger("BlackIn");
        yield return new WaitForSeconds(_waitingSecondCloseCinematic);
        SceneManager.LoadScene(2);
    }
}
