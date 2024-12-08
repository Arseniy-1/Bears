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
            Debug.Log(GetType());
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
            if (_player.TargetScanner.ClosestTarget != null &&
                Vector3.Distance(_player.Position, _player.TargetScanner.ClosestTarget.Position) < _player.DetectionRange)
            {
                _stateSwitcher.SwitchState<EnemyMoveState>();
            }
            else
            {
                _stateSwitcher.SwitchState<EnemyActivitysState>();
            }
        }
    }
}
