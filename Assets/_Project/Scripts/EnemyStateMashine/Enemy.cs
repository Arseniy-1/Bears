using System;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

public class Enemy : Character
{
    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    public List<Transform> Waypoints { get; private set; }

    private EnemyStateMachine _stateMachine;
    public Turning Turning { get; private set; }

    private void Start()
    {
        Turning = new Turning(this);
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    public void Construct(EnemyStateMachine enemyStateMachine, List<Transform> waypoints)
    {
        _stateMachine = enemyStateMachine;
        Waypoints = waypoints;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}