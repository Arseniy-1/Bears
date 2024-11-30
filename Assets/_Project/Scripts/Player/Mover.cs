using TMPro.EditorUtilities;
using UnityEngine;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Turning _turning;

        private InputHandler _inputHandler;
        private Rigidbody2D _rigidbody2D;
        private Player _character;

        public bool IsRunning() => _inputHandler.HorizontalDirection + _inputHandler.VerticalDirection != 0;

        public void Initialize(Character character, Rigidbody2D rigidbody2D, InputHandler inputHandler)
        {
            _rigidbody2D = rigidbody2D;
            _inputHandler = inputHandler;
            _character = character;
        }

        private void Run()
        {
            float currentHorizontalSpeed = _inputHandler.HorizontalDirection;
            float currentVerticalSpeed = _inputHandler.VerticalDirection;

            _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
            _character.WeaponHolder.SpotTarget();
            _turning.CorrectFlip((int)currentHorizontalSpeed);
        }
    }
}