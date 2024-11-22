using System.Collections.Generic;
using _Project.Scripts.Player;
using _Project.Scripts.Spawner;
using UnityEngine;

public class Enemy : Character
{
    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    public List<Transform> Waypoints { get; private set; }

    private EnemyStateMachine _stateMachine;
    public Turning Turning { get; private set; }

    public void Construct(EnemyStateMachine enemyStateMachine, List<Transform> waypoints, MainAmmoSpawner ammoBoss)
    {
        _stateMachine = enemyStateMachine;
        Waypoints = waypoints;
        WeaponHolder.Construct(TargetScanner, ammoBoss);
    }

    private void Start()
    {
        Turning = new Turning(this);
    }

    private void Update()
    {
        _stateMachine.Update();
        Debug.Log(TargetScanner.ClosestTarget);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}