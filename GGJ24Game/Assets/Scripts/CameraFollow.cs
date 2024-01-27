using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    [SerializeField] private Transform _newZoomInPos;
    private Transform _newZoomOutPos;
    void Start()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _newZoomOutPos = GetComponent<CinemachineVirtualCamera>().Follow;
    }

    void ZoomIn()
    {
        if (_cam != null) 
        {
            _cam.Follow = _newZoomInPos;
            StartCoroutine(ZoomInNum());
        }
    }

    void ZoomOut()
    {
        if (_cam != null)
        {
            _cam.Follow = _newZoomOutPos;
            StartCoroutine(ZoomOutNum());
        }
    }

    IEnumerator ZoomInNum()
    {
        for (int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _cam.m_Lens.OrthographicSize -= 0.07f;
        }
    }

    IEnumerator ZoomOutNum()
    {
        for (int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _cam.m_Lens.OrthographicSize += 0.07f;
        }
    }
}
