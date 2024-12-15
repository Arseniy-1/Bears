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
            _player.CharacterAnimator.StartIdleWithWeapon();
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            if (_player.Mover.IsRunning)
            {
                _stateSwitcher.SwitchState<PlayerMoveState>();
            }
        }
    }
}
