using System;
using _Project.Scripts.Spawner;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootGun : Weapon
{
    [SerializeField] private Ammo _ammoPrefab;
    [SerializeField, Range(0, 1) , Header("(Разброс) Среднее значение: 0,2")] private float _spread;

    private readonly int _bulletCount = 6;
    
    private AmmoSpawner _ammoSpawner;

    public void Construct(AmmoSpawner ammoSpawner)
    {
        Debug.Log($"shotgun construct");
        _ammoSpawner = ammoSpawner;
    }

    protected override void Attack()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Ammo ammo = _ammoSpawner.Spawn();
            ammo.Init(ShootPoint.transform.position, GetRandomSpread(ShootPoint.transform.rotation)); 
            
            //Ammo ammo = Instantiate(_ammoPrefab, ShootPoint.transform.position, GetRandomSpread(ShootPoint.transform.rotation));
            ammo.Activate();
        }
    }

    private Quaternion GetRandomSpread(Quaternion rotation)
    {
        rotation.z += Random.Range(-_spread, _spread);

        return rotation;
    }
}