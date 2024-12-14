using UnityEngine;

namespace PlayerSystem
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField, Range(0.01f, 3)] private float _moveSpeed = 2;
        [SerializeField, Range(0, 1)] private float _jumpDistance = 0.2f;
        [SerializeField] private Character _character;

        private bool _isMoving = false;
        private float _currentTime = 0f;

        public void Jump()
        {
            Vector3 targetPosition = _character.transform.position + transform.right * _jumpDistance;

            if (_isMoving == false)
            {
                _character.transform.position = Vector3.Lerp(_character.transform.position, targetPosition, _currentTime);

                _currentTime = 0f;
                _isMoving = true;
            }
            else
            {
                _currentTime += Time.deltaTime * _moveSpeed;
                _character.transform.position = Vector3.Lerp(_character.transform.position, targetPosition, _currentTime);

                if (_currentTime >= 1f)
                {
                    _isMoving = false;
                }
            }
        }
    }
}