using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject creditCanvas;
    public GameObject playCanvas;

    public Animator triggerSceneChange;

    public void BackToPlayCanvas()
    {
        creditCanvas.SetActive(false);
        playCanvas.SetActive(true);
    }
    public void GoToCreditCanvas()
    {
        playCanvas.SetActive(false);
        creditCanvas.SetActive(true);
    }

    public void ClickPlay()
    {
        StartCoroutine(ChangeScene());
    }

    public void ClickedQuit()
    {
        Application.Quit();
    }

    IEnumerator ChangeScene()
    {
        triggerSceneChange.SetTrigger("BlackIn");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
}
