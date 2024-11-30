using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    [SerializeField, Range(0.5f, 3f), Header("Скорость отдаления")] 
    private float _speedDistance = 1.5f;
    
    [SerializeField, Range(9f, 15f), Header("Максимальное отдаление камеры")] 
    private float _focusMovement = 10f;
    
    [SerializeField, Range(2f, 8f), Header("Скорость приближения")] 
    private float _speedApproach = 4f;
    
    [SerializeField, Range(4f, 8f), Header("Максимальное приблежение камеры")]
    private float _focusRest = 7f;
    
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody2D _rigidbodyPlayer;

    private readonly float _minSpeedPlayer = 0.1f;
    private Camera _camera;
    private Tween _animation;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (_rigidbodyPlayer.velocity.magnitude > _minSpeedPlayer)
        {
            _animation = _camera.DOOrthoSize(_focusMovement, _speedDistance).SetEase(Ease.Linear);
        }
        else
        {
            _animation = _camera.DOOrthoSize(_focusRest, _speedApproach).SetEase(Ease.Linear).SetDelay(1f);
        }
        
        transform.position = new Vector3(_player.position.x, _player.position.y, -1);
    }

    private void OnDestroy()
    {
        _animation.Kill(true);
    }
}
