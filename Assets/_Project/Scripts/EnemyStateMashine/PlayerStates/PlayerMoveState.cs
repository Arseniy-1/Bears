using UnityEngine;

namespace EnemyStateMashine
{
    public class PlayerMoveState : IState
    {
        private readonly PlayerBehaviour _player;
        private IStateSwitcher _stateSwitcher;

        public PlayerMoveState(PlayerBehaviour enemy)
        {
            _player = enemy;
        }

        public void Initialize(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Enter()
        {
            _player.PlayerInputController.JumpButtonPressed += OnJumpButtonPressed;
            _player.CharacterAnimator.StartRunningWithWeapon();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            _player.PlayerInputController.JumpButtonPressed -= OnJumpButtonPressed;
        }

        public virtual void Update()
        {
            var direction = _player.PlayerInputController.InputDirection;

            _player.Mover.Run(direction);

            if (_player.Mover.IsRunning == false)
            {
                _stateSwitcher.SwitchState<PlayerIdleState>();
            }
        }

        public void OnJumpButtonPressed()
        {
            _stateSwitcher.SwitchState<PlayerJumpState>();
        }
    }
}
