using _Project.Scripts.Spawner;
using System.Collections.Generic;
using UnityEngine;
using EnemyStateMashine;

public class EnemyFabric : MonoBehaviour
{
    public EnemyBehavior Create(Transform transform, EnemyBehavior enemyPrefab, List<Transform> waypoints, MainAmmoSpawner ammoSpawner)
    {
        EnemyBehavior enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        List<IState> enemyStates = new List<IState>
            {
            new EnemyIdleState(enemy),
            new EnemyMoveState(enemy),
            new EnemyAttackState(enemy),
            new EnemyActivitysState(enemy)
            };

        EnemyStateMachine enemyStateMashine = new EnemyStateMachine(enemyStates);

        foreach (IState state in enemyStates)
        {
            state.Initialize(enemyStateMashine);
        }

        enemy.Construct(enemyStateMashine, waypoints, ammoSpawner);

        return enemy;
    }
}
