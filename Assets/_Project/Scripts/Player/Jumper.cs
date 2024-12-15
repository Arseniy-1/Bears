using Sirenix.OdinInspector;
using UnityEngine;
using System;

namespace PlayerSystem
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private Character _character;

        [SerializeField] private float _distance = 1f;
        [SerializeField] private float _speed = 2f;   
        [SerializeField] private float _actionTime = 2.5f;   

        private Vector3 _startPosition;
        private Vector3 _targetPosition;
        private bool _isMoving = false;
        private float _currentTime = 0f;

        public event Action JumpPerformed;

        [Button]
        public void Jump()
        {
            if (_isMoving == false)
            {
                float directionSign = Mathf.Sign(_character.CharacterRigidbody2D.velocity.x);

                if (directionSign == 0)
                    return;

                _startPosition = transform.position;
                _targetPosition = _startPosition + transform.right * _distance * directionSign;
                _currentTime = 0f;
                _isMoving = true;
            }
        }

        private void Update()
        {
            if (_isMoving)
            {
                _currentTime += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(_startPosition, _targetPosition, _currentTime);

                if (_currentTime >= _actionTime)
                {
                    transform.position = _targetPosition;
                    _isMoving = false;

                    Debug.Log("OnJumpPerformedInvoke");
                    JumpPerformed?.Invoke();
                }
            }
        }
    }
}