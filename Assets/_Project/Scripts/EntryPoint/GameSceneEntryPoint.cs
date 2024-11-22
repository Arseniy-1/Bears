using _Project.Scripts.Spawner;
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
        foreach (Weapon weapon in _playerWeapons)
        {
            if (weapon is RangeWeapon rangeWeapon)
            {
                rangeWeapon.Construct(_motherAmmoBoss);
            }
        }

        foreach (DoneEnemy doneEnemy in _enemys)
        {
            _enemyFabric.Create(doneEnemy.Waypoints[0].transform, doneEnemy.Enemy, doneEnemy.Waypoints, _motherAmmoBoss);
            //TargetScanner targetScanner = new TargetScanner(enemy);
        }
    }
}
