using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float _shockWaveTime = 0.75f;

    private Coroutine _shockWaveCoroutine;

    private Material _material;

    private static int _WaveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    public static ShockWaveManager Instance;

    private void Awake()
    {
        Instance = this;
        _material = GetComponent<SpriteRenderer>().material;
    }

    public void CallShockWave()
    {
        _shockWaveCoroutine = StartCoroutine(ShockWaveAction(-0.1f,12));
        CameraFollow.Instance.ShakeCamera(3f,0.8f);
    }

    public IEnumerator ShockWaveAction(float startPos, float endPos)
    {
        _material.SetFloat(_WaveDistanceFromCenter, startPos);

        float lerpedAmount = 0f;

        float elapsedTime = 0f;
        while (elapsedTime < _shockWaveTime) 
        {  
            elapsedTime += Time.deltaTime;

            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / _shockWaveTime));
            _material.SetFloat(_WaveDistanceFromCenter, lerpedAmount);

            yield return null;
        }
    }
}
