using _Project.Scripts.Spawner;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    public Enemy Create(Transform transform, Enemy enemyPrefab, List<Transform> waypoints, MainAmmoSpawner ammoSpawner)
    {
        Enemy enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

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

        enemy.Construct(enemyStateMashine, waypoints, ammoSpawner);

        return enemy;
    }
}
