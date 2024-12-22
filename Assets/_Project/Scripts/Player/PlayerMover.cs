using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed; //TODO Вынести скорость в SO player'а
        [SerializeField] private Flipper _flipper;

        private PlayerBehaviour _player;

        public bool IsRunning => _player.PlayerInputController.InputDirection != Vector2.zero;
        public bool IsMovingBackward => _player.PlayerInputController.InputDirection.x != _flipper.transform.localScale.x;

        public void Initialize(PlayerBehaviour player)
        {
            _player = player;
        }

        public void Run(Vector2 direction)
        {
            _player.CharacterRigidbody2D.velocity = direction.normalized * _speed;
        }
    }
}