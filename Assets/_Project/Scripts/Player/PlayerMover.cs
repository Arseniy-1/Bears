using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;//TODO Вынести скорость
        [SerializeField] private Flipper _flipper;

        private Rigidbody2D _rigidbody2D;
        private PlayerBehaviour _player;

        public bool IsRunning() => _inputHandler.HorizontalDirection != 0 || _inputHandler.VerticalDirection != 0;

        private void Update()
        {
            //Run();
        }

        public void Run(Vector2 direction)
        {
            //float currentHorizontalSpeed = _inputHandler.HorizontalDirection * _speed;
            //float currentVerticalSpeed = _inputHandler.VerticalDirection * _speed;

            //_rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
            _rigidbody2D.velocity = direction;
            _player.WeaponHolder.SpotTarget();

            _flipper.CorrectFlip();
        }

        public void Initialize(PlayerBehaviour player, Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _player = player;
            _player = player;
        }
    }
}