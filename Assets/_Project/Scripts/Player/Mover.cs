using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Turning _turning;
        [SerializeField] private float _speed;//TODO Вынести в SO

        private InputHandler _inputHandler;
        private Rigidbody2D _rigidbody2D;
        private PlayerBehaviour _character;

        public bool IsRunning() => _inputHandler.HorizontalDirection != 0 || _inputHandler.VerticalDirection != 0;

        private void Update()
        {
            Run();
        }

        public void Initialize(PlayerBehaviour player, Rigidbody2D rigidbody2D, InputHandler inputHandler)
        {
            _rigidbody2D = rigidbody2D;
            _inputHandler = inputHandler;
            _character = player;

            _turning.Initialize(_character);
        }

        private void Run()
        {
            float currentHorizontalSpeed = _inputHandler.HorizontalDirection * _speed; 
            float currentVerticalSpeed = _inputHandler.VerticalDirection * _speed; 

            _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
            _character.WeaponHolder.SpotTarget();
            _turning.CorrectFlip((int)currentHorizontalSpeed);
        }
    }
}