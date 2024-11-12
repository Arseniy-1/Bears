using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public EnemyStateMachine(Enemy enemy)
    {
        _states = new List<IState>()
            {
                new EnemyIdleState(this, enemy),
                new EnemyMoveState(this, enemy),
                new EnemyAttackState()
            };

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
        if (Vector3.Distance(_enemy.Position, _enemy.TargetScaner.ClosestTarget.Position) < _enemy.DetectionRange)
            _stateSwitcher.SwitchState<EnemyMoveState>();
    }
}

public class EnemyMoveState : IState
{
    private readonly Enemy _enemy;
    private  IStateSwitcher _stateSwitcher;

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
        if (_enemy.TargetScaner.HasTarget)
        {
            _enemy.transform.position += (_enemy.TargetScaner.transform.position - _enemy.transform.position) * 2 * Time.deltaTime; //Магическое число - скорость
        }

        if(Vector3.Distance(_enemy.Position, _enemy.TargetScaner.ClosestTarget.Position) < _enemy.AttackRange)
        {
            _stateSwitcher.SwitchState<EnemyAttackState>();
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
        if (Vector3.Distance(_enemy.Position, _enemy.TargetScaner.ClosestTarget.Position) < _enemy.AttackRange)
        {

        }
    }
}