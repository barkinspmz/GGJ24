using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLocation : MonoBehaviour
{
    [SerializeField] private float _timeForWaitingChangeScene = 2f;
    public int otherSceneIndex = 3;
    private void Start()
    {
        EndOfTheLevel.Instance.endOfLevel += ChangeScene;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            EndOfTheLevel.Instance.EndLevelEvents();
        }
    }

    private void ChangeScene()
    {
        GameObject.Find("SceneChangerBlackIn").GetComponent<Animator>().SetTrigger("BlackIn");
        StartCoroutine(WaitingBeforeChangingScene());
    }

    IEnumerator WaitingBeforeChangingScene()
    {
        yield return new WaitForSeconds(_timeForWaitingChangeScene);
        SceneManager.LoadScene(otherSceneIndex);
    }
}
