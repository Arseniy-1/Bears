using UnityEngine;

namespace EnemyStateMashine
{
    public class PlayerIdleState : IState
    {
        private readonly PlayerBehaviour _player;
        private IStateSwitcher _stateSwitcher;

        public PlayerIdleState(PlayerBehaviour player)
        {
            _player = player;
        }

        public void Initialize(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public virtual void Enter()
        {
            _player.PlayerInputController.JumpButtonPressed += OnJumpButtonPressed;
            _player.CharacterAnimator.StartIdleWithWeapon();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
            _player.PlayerInputController.JumpButtonPressed -= OnJumpButtonPressed;
        }

        public virtual void Update()
        {
            if (_player.Mover.IsRunning)
            {
                _stateSwitcher.SwitchState<PlayerMoveState>();
            }
        }

        public void OnJumpButtonPressed()
        {
            _stateSwitcher.SwitchState<PlayerJumpState>();
        }
    }
}
