using _Project.Scripts.Spawner;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneEntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _player;
    [SerializeField] private List<Weapon> _playerWeapons;
    [SerializeField] private PlayerInitializer _playerInitializer;

    [SerializeField] private List<DoneEnemy> _enemys;
    [SerializeField] private EnemyFabric _enemyFabric;
    [SerializeField] private MainAmmoSpawner _mainAmmoSpawner;

    private void Awake()
    {
        _playerInitializer.Initialize(_player);

        foreach (Weapon weapon in _playerWeapons)
        {
            if (weapon is RangeWeapon rangeWeapon)
            {
                rangeWeapon.Construct(_mainAmmoSpawner);
            }
        }

        foreach (DoneEnemy doneEnemy in _enemys)
        {
            _enemyFabric.Create(doneEnemy.Waypoints[0].transform, doneEnemy.Enemy, doneEnemy.Waypoints, _mainAmmoSpawner);
        }
    }
}
