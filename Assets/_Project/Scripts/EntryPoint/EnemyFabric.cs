using System.Collections.Generic;
using UnityEngine;

public class EnemyFabric : MonoBehaviour
{
    public Enemy Create(Transform transform, Enemy enemyPrefab)
    {
        Enemy newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);

        return newEnemy;
    }
}
