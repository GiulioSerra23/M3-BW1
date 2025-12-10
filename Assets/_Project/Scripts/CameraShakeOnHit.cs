using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeOnHit : MonoBehaviour
{

    private float _shakeDuration;
    private float _shakeMagnitude;

    private Vector3 _cameraPos;

    // Update is called once per frame
    void LateUpdate()
    {
        _cameraPos = transform.localPosition;

        if (_shakeDuration > 0)
        {
            float _shakeX = Random.Range(-1, 1) * _shakeMagnitude;
            float _shakeY = Random.Range(-1, 1) * _shakeMagnitude;

            transform.position = new Vector3(transform.position.x + _shakeX, transform.position.y + _shakeY, transform.localPosition.z);

            _shakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = _cameraPos;
        }
    }

    public void ShakeOnHit (float duration, float magnitude)
    {
        _shakeDuration = duration;
        _shakeMagnitude = magnitude;
    }
}
