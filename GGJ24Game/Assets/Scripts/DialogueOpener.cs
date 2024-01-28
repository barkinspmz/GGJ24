using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueOpener : MonoBehaviour
{
    [SerializeField] private string[] texts;

    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private float _waitingSecondBetweenDialogues;
    [SerializeField] private float _waitingSecondBetweenTextChars;
    [SerializeField] private float _waitingSecondCloseCinematic;

    public AudioClip TypeSound;
    AudioSource audSrc;

    public AudioClip OpenHUDSound;

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audSrc.PlayOneShot(OpenHUDSound);
            Debug.Log("HEYY");
            DialogueManager.Instance.OpenDialogueCinematic();
            StartCoroutine(DialogueFlow());
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    IEnumerator DialogueFlow()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < texts.Length; i++)
        {
            if (!DialogueManager.Instance.isClickedEsc)
            {
                foreach (var a in texts[i])
                {
                    playerText.text += a.ToString();

                    audSrc.pitch = Random.Range(0.9f, 1.0f);
                    audSrc.PlayOneShot(TypeSound);
                    if (i.ToString() == "." || i.ToString() == "?") { yield return new WaitForSeconds(1f); }
                    else { yield return new WaitForSeconds(_waitingSecondBetweenTextChars); }
                }
            }

            yield return new WaitForSeconds(_waitingSecondBetweenDialogues);

            playerText.text = string.Empty;
        }

        yield return new WaitForSeconds(_waitingSecondCloseCinematic);
        if (DialogueManager.Instance.isCinematicActive)
        {
            DialogueManager.Instance.CloseDialogueCinematic();
        }
        DialogueManager.Instance.isClickedEsc = false;
    }
}
