using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance {  get; private set; }
    private CinemachineVirtualCamera _cam;
    [SerializeField] private Transform _newZoomInPos;
    private Transform _newZoomOutPos;

    private float shakeTimer;
    private void Awake()
    {
        Instance = this;
        _cam = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        _newZoomOutPos = GetComponent<CinemachineVirtualCamera>().Follow;
        DialogueManager.Instance.ZoomInCam += ZoomIn;
        DialogueManager.Instance.ZoomOutCam += ZoomOut;
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
            _cam.m_Lens.OrthographicSize -= 0.05f;
        }
    }

    IEnumerator ZoomOutNum()
    {
        for (int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _cam.m_Lens.OrthographicSize += 0.05f;
        }
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
            _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer<=0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                _cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
