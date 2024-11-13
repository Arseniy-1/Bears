using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public EnemyStateMachine(List<IState> states)
    {
        _states = states;

        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        if (state == null)
            throw new ArgumentNullException(nameof(T));

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}

public class EnemyIdleState : IState
{
    private readonly Enemy _enemy;
    private IStateSwitcher _stateSwitcher;

    public EnemyIdleState(Enemy entity)
    {
        _enemy = entity;
    }

    public void Initialize(IStateSwitcher stateSwitcher)
    {
        _stateSwitcher = stateSwitcher;
        Debug.Log(_stateSwitcher == null);
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
        if (_enemy.GunHolder.TargetScanner.HasTarget)
        {
            if (Vector3.Distance(_enemy.Position, _enemy.GunHolder.TargetScanner.ClosestTarget.Position) < _enemy.DetectionRange)
            {
                Debug.Log(_stateSwitcher == null);
                _stateSwitcher.SwitchState<EnemyMoveState>();
                Debug.Log(Vector3.Distance(_enemy.Position, _enemy.GunHolder.TargetScanner.ClosestTarget.Position));
                Debug.Log(_enemy.DetectionRange);
            }
        }
    }
}

public class EnemyMoveState : IState
{
    private readonly Enemy _enemy;
    private IStateSwitcher _stateSwitcher;

    public EnemyMoveState(Enemy entity)
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
        if (_enemy.GunHolder.TargetScanner.HasTarget)
        {
            Vector2 direction = (_enemy.GunHolder.TargetScanner.ClosestTarget.Position - _enemy.Position).normalized;
            Vector3 currentDirection = new Vector3(direction.x, direction.y, 0);
            _enemy.GunHolder.SpotTarget();
            _enemy.transform.position += currentDirection * 2 * Time.deltaTime; //Магическое число - скорость
            _enemy.Turning.CorrectFlip((int)direction.x);

            if (Vector3.Distance(_enemy.Position, _enemy.GunHolder.TargetScanner.ClosestTarget.Position) < _enemy.AttackRange)
            {
                _stateSwitcher.SwitchState<EnemyAttackState>();
            }
            else
            {
                _stateSwitcher.SwitchState<EnemyIdleState>();
            }
        }
        else
        {
            _stateSwitcher.SwitchState<EnemyIdleState>();
        }
    }
}

public class EnemyAttackState : IState
{
    protected readonly Enemy _enemy;
    protected IStateSwitcher _stateSwitcher;

    public EnemyAttackState(Enemy enemy)
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
        if (_enemy.GunHolder.TargetScanner.HasTarget)
        {
            if (Vector3.Distance(_enemy.Position, _enemy.GunHolder.TargetScanner.ClosestTarget.Position) < _enemy.AttackRange)
            {
                _enemy.GunHolder.SpotTarget();
                _enemy.GunHolder.Shoot();
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