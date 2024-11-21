using _Project.Scripts.Spawner;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private List<DoneEnemy> _enemyWays;
    [SerializeField] private EnemyFabric _enemyFabric;
    [SerializeField] private MotherAmmoBoss _motherAmmoBoss;

    private void Awake()
    {
        MotherAmmoBoss ammoBoss = _motherAmmoBoss;

        foreach (DoneEnemy doneEnemy in _enemyWays)
        {
            Enemy enemy = _enemyFabric.Create(doneEnemy.Waypoints[0].transform, doneEnemy.Enemy);
            TargetScanner targetScanner = new TargetScanner(enemy);

            List<IState> enemyStates = new List<IState>
            {
            new EnemyIdleState(enemy),
            new EnemyMoveState(enemy),
            new EnemyAttackState(enemy),
            new EnemyActivitysState(enemy)
            };
            
            EnemyStateMachine enemyStateMashine = new EnemyStateMachine(enemyStates);

            foreach (var state in enemyStates)
            {
                state.Initialize(enemyStateMashine);
            }

            enemy.Construct(enemyStateMashine, doneEnemy.Waypoints, ammoBoss);
        }
    }
}

[Serializable]
public class DoneEnemy
{
    [field: SerializeField] public List<Transform> Waypoints { get; private set; }
    [field: SerializeField] public Enemy Enemy { get; private set; }
}
