using System.Collections.Generic;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public void Create(Transform transform, List<Transform> waypoints)
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);

        List<IState> enemyStates = new List<IState>
        {
            new EnemyIdleState(enemy),
            new EnemyMoveState(enemy),
            new EnemyAttackState(enemy)
        };

        EnemyStateMachine enemyStateMashine = new(enemyStates);

        foreach (var state in enemyStates)
        {
            state.Initialize(enemyStateMashine);
        }

        enemy.Construct(enemyStateMashine, waypoints);
    }
}
