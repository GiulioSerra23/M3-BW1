using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeOnHit : MonoBehaviour
{
    [SerializeField] private float _shakeMagnitude = 0.1f;
    [SerializeField] private float _shakeDuration = 0.05f;

    private float _timer;
    private Vector3 _cameraPos;

    void LateUpdate()
    {
        _cameraPos = transform.localPosition;

        if (_timer > 0)
        {
            float _shakeX = Random.Range(-1, 1) * _shakeMagnitude;
            float _shakeY = Random.Range(-1, 1) * _shakeMagnitude;

            transform.localPosition = _cameraPos + new Vector3(_shakeX, _shakeY, 0);

            _timer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = _cameraPos;
        }
    }

    public void ShakeOnHit ()
    {
        _timer = _shakeDuration;
    }
}
