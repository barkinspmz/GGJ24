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
            yield return new WaitForSeconds(0.5f);
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
        yield return new WaitForSeconds(0.5f);
        ShockWaveManager.Instance.CallShockWave();
        _eButtonClickBG.fillAmount = 0;
        _animSuccesfull.SetTrigger("End");
        yield return new WaitForSeconds(cooldownTime);
        isRunning = false;
        isEnding = false;
    }
}
