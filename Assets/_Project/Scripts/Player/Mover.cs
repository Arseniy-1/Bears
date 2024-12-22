using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace PlayerSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;//TODO Вынести скорость
        [SerializeField] private Turning _turning;

        public bool IsMovingBackward => _inputHandler.HorizontalDirection != _turning.transform.localScale.x;
        
        private InputHandler _inputHandler;
        private Rigidbody2D _rigidbody2D;
        private PlayerBehaviour _player;

        public bool IsRunning() => _inputHandler.HorizontalDirection != 0 || _inputHandler.VerticalDirection != 0;

        private void Update()
        {
            Run();
        }

        private void Run()
        {
            float currentHorizontalSpeed = _inputHandler.HorizontalDirection * _speed;
            float currentVerticalSpeed = _inputHandler.VerticalDirection * _speed;

            _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
            _player.WeaponHolder.SpotTarget();

            _turning.CorrectFlip(_inputHandler.HorizontalDirection);
        }

        public void Initialize(PlayerBehaviour player, Rigidbody2D rigidbody2D, InputHandler inputHandler)
        {
            _rigidbody2D = rigidbody2D;
            _inputHandler = inputHandler;
            _player = player;
            _player = player;
            _turning.Initialize(_player);
        }
    }
}