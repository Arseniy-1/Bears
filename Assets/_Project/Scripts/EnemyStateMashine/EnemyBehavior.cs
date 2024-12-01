using System.Collections.Generic;
using _Project.Scripts.Spawner;
using UnityEngine;
using EnemyStateMashine;
using PlayerSystem;

public class EnemyBehavior : Character
{
    private EnemyStateMachine _stateMachine;

    [field: SerializeField] public float DetectionRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public Turning Turning { get; private set; }
    
    public List<Transform> Waypoints { get; private set; }

    public void Construct(EnemyStateMachine enemyStateMachine, List<Transform> waypoints, MainAmmoSpawner ammoBoss)
    {
        _stateMachine = enemyStateMachine;
        Waypoints = waypoints;
        WeaponHolder.Construct(TargetScanner, ammoBoss);
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, DetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
