using _Project.Scripts.Spawner;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private List<DoneEnemy> _enemys;
    [SerializeField] private EnemyFabric _enemyFabric;
    [SerializeField] private MainAmmoSpawner _motherAmmoBoss;
    [SerializeField] private List<Weapon> _playerWeapons;

    private void Awake()
    {
        MainAmmoSpawner ammoBoss = _motherAmmoBoss;

        foreach (Weapon weapon in _playerWeapons)
        {
            if (weapon is RangeWeapon rangeWeapon)
            {
                rangeWeapon.Construct(ammoBoss);
            }
        }

        foreach (DoneEnemy doneEnemy in _enemys)
        {
            _enemyFabric.Create(doneEnemy.Waypoints[0].transform, doneEnemy.Enemy, doneEnemy.Waypoints, ammoBoss);
            //TargetScanner targetScanner = new TargetScanner(enemy);
        }
    }
}

[Serializable]
public class DoneEnemy
{
    [field: SerializeField] public List<Transform> Waypoints { get; private set; }
    [field: SerializeField] public Enemy Enemy { get; private set; }
}
