using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TappingE : MonoBehaviour
{
    [SerializeField] private Image _eButtonClickBG;
    [SerializeField] private Animator _animSuccesfull;

    [SerializeField] private float cooldownTime;

    private bool isRunning = false;
    private bool isEnding = false;

    [SerializeField] private Animator[] _bangAnims;

    [SerializeField] private Animator _anim;

    [SerializeField] private Animator[] _pressEIndicatorsAnim;

    [SerializeField] private GameObject obstacleDestroyer;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isEnding)
        {
            if (CircleChallange.Instance.isNarrowing)
            {
                foreach (var anim in _pressEIndicatorsAnim) { anim.SetTrigger("Click"); }
            }
            _anim.SetTrigger("Click");
            _eButtonClickBG.fillAmount += 0.2f;
            if (_eButtonClickBG.fillAmount>=1)
            {
                isEnding = true;
                StartCoroutine(AfterFillingEButton());
            }
            if (!isRunning)
            {
                StartCoroutine(ReverseFillingEButton());
                isRunning = true;
            }
        }
    }

    IEnumerator ReverseFillingEButton()
    {
        while (_eButtonClickBG.fillAmount > 0)
        {
            _eButtonClickBG.fillAmount -= 0.05f;
            yield return new WaitForSeconds(0.1f);
            if (_eButtonClickBG.fillAmount <= 0)
            {
                _eButtonClickBG.fillAmount = 0;
                isRunning = false;
            }
        }
    }

    IEnumerator AfterFillingEButton()
    {
        StopCoroutine(ReverseFillingEButton());
        _eButtonClickBG.fillAmount = 1;
        _animSuccesfull.SetTrigger("Succes");
        obstacleDestroyer.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        CircleChallange.Instance.eClicked = true;
        ShockWaveManager.Instance.CallShockWave();
        if (CircleChallange.Instance.isNarrowing || CircleChallange.Instance.finishedNarrowing)
        {
            CircleChallange.Instance.ExpandCircle();
        }
        var randomNumber = Random.Range(0, _bangAnims.Length);
        for (int i = 0; i < _bangAnims.Length; i++)
        {
            if (randomNumber == i)
            {
                continue;
            }
            else
            {
                _bangAnims[i].SetTrigger("Bang");
            }
        }
        _eButtonClickBG.fillAmount = 0;
        _animSuccesfull.SetTrigger("End");
        yield return new WaitForSeconds(cooldownTime);
        isRunning = false;
        isEnding = false;
        yield return new WaitForSeconds(1f);
        obstacleDestroyer.SetActive(false);
    }
}
