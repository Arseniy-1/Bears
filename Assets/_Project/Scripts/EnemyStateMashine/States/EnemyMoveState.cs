using UnityEngine;

namespace EnemyStateMashine
{
    public class EnemyMoveState : IState
    {
        private readonly EnemyBehavior _enemy;
        private IStateSwitcher _stateSwitcher;

        public EnemyMoveState(EnemyBehavior entity)
        {
            _enemy = entity;
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
            if (_enemy.TargetScanner.HasTarget)
            {
                Vector2 direction = (_enemy.TargetScanner.ClosestTarget.Position - _enemy.Position).normalized;
                Vector3 currentDirection = new Vector3(direction.x, direction.y, 0);
                _enemy.WeaponHolder.SpotTarget();
                _enemy.transform.position += currentDirection * 2 * Time.deltaTime; //Магическое число - скорость
                _enemy.Turning.CorrectFlip((int)currentDirection.x);

                if (Vector3.Distance(_enemy.Position, _enemy.TargetScanner.ClosestTarget.Position) < _enemy.AttackRange)
                {
                    _stateSwitcher.SwitchState<EnemyAttackState>();
                }
                else if (Vector3.Distance(_enemy.Position, _enemy.TargetScanner.ClosestTarget.Position) > _enemy.DetectionRange)
                {
                    _stateSwitcher.SwitchState<EnemyIdleState>();
                }
            }
            else
            {
                _stateSwitcher.SwitchState<EnemyIdleState>();
                Debug.Log("2");
            }
        }
    }
}