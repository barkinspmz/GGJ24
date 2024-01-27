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
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isEnding)
        {
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
        yield return new WaitForSeconds(0.2f);
        ShockWaveManager.Instance.CallShockWave();
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
    }
}
