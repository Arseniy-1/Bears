using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    [SerializeField, Range(0.5f, 3f), Header("Скорость отдаления")]
    private float _distanceRateOut = 1.5f;

    [SerializeField, Range(9f, 15f), Header("Максимальное отдаление камеры")]
    private float _focusMovement = 10f;

    [SerializeField, Range(2f, 8f), Header("Скорость приближения")]
    private float _distanceRateIn = 4f;

    [SerializeField, Range(4f, 8f), Header("Максимальное приблежение камеры")]
    private float _focusRest = 7f;

    [SerializeField] private Rigidbody2D _rigidbodyPlayer;

    private readonly float _minSpeedPlayer = 0.1f;
    private Camera _camera;
    private Tween _animation;
    private bool _isZoomedOut;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (_rigidbodyPlayer.velocity.magnitude > _minSpeedPlayer)
        {
            if (!_isZoomedOut)
            {
                _animation?.Kill();
                _animation = _camera.DOOrthoSize(_focusMovement, _distanceRateOut).SetEase(Ease.Linear);
                _isZoomedOut = true;
            }
        }
        else
        {
            if (_isZoomedOut)
            {
                _animation?.Kill();
                _animation = _camera.DOOrthoSize(_focusRest, _distanceRateIn).SetEase(Ease.Linear).SetDelay(1f);
                _isZoomedOut = false;
            }
        }
    }

    private void OnDestroy()
    {
        _animation.Kill(true);
    }
}