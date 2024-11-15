using System;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

public class Enemy : Character, ITarget
{
    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }

    private EnemyStateMachine _stateMachine;

    public Vector2 Position => transform.position;
    public Turning Turning { get; private set; }

    private void Start()
    {
        Turning = new Turning(this);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Construct(EnemyStateMachine enemyStateMachine)
    {
        _stateMachine = enemyStateMachine;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}