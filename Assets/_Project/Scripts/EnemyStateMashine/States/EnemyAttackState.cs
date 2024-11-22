using UnityEngine;

public class EnemyAttackState : IState
{
    protected readonly EnemyBehavior _enemy;
    protected IStateSwitcher _stateSwitcher;

    public EnemyAttackState(EnemyBehavior enemy)
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
        if (_enemy.TargetScanner.HasTarget)
        {
            if (Vector3.Distance(_enemy.Position, _enemy.TargetScanner.ClosestTarget.Position) < _enemy.AttackRange)
            {
                _enemy.WeaponHolder.SpotTarget();
                _enemy.Turning.CorrectFlip((int)_enemy.TargetScanner.ClosestTarget.Position.x);
                _enemy.WeaponHolder.Shoot();
            }
            else
            {
                _stateSwitcher.SwitchState<EnemyMoveState>();
            }
        }
        else
        {
            _stateSwitcher.SwitchState<EnemyIdleState>();
        }
    }
}