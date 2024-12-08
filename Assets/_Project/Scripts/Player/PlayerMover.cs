using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;//TODO Вынести скорость
        [SerializeField] private Flipper _flipper;

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

            _flipper.CorrectFlip(_inputHandler.HorizontalDirection);
        }

        public void Initialize(PlayerBehaviour player, Rigidbody2D rigidbody2D, InputHandler inputHandler)
        {
            _rigidbody2D = rigidbody2D;
            _inputHandler = inputHandler;
            _player = player;
            _player = player;
        }
    }
}