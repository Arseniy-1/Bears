using UnityEngine;

namespace EnemyStateMashine
{
    public class EnemyIdleState : IState
    {
        private readonly EnemyBehavior _enemy;
        private IStateSwitcher _stateSwitcher;

        public EnemyIdleState(EnemyBehavior enemy)
        {
            _enemy = enemy;
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
            if (_enemy.TargetScanner.ClosestTarget != null &&
                Vector3.Distance(_enemy.Position, _enemy.TargetScanner.ClosestTarget.Position) < _enemy.DetectionRange)
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
