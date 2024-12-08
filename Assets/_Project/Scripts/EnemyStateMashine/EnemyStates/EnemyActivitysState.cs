using UnityEngine;

namespace EnemyStateMashine
{
    public class EnemyActivitysState : IState
    {
        private readonly EnemyBehavior _enemy;
        private IStateSwitcher _stateSwitcher;

        private int _currentWaypoint = 0;
        private float _speed = 3;

        public EnemyActivitysState(EnemyBehavior enemy)
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
            _enemy.WeaponHolder.ReturnWeapon();
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

            if (_enemy.transform.position == _enemy.Waypoints[_currentWaypoint].position)
            {
                _currentWaypoint = (_currentWaypoint + 1) % _enemy.Waypoints.Count;
            }

            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, _enemy.Waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
            
            float direction = (_enemy.Waypoints[_currentWaypoint].position.x - _enemy.Position.x);
            _enemy.Turning.CorrectFlip((int)direction);
        }
    }
}
