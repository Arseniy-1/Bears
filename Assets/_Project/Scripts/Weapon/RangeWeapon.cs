using _Project.Scripts.Spawner;
using UnityEngine;

public abstract class RangeWeapon : Weapon
{
    [SerializeField, Range(0, 1), Header("(Разброс) Среднее значение: 0,2")] private float _spread;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] private Ammo _bulletPrefab;

    protected MainAmmoSpawner AmmoSpawner;

    public void Construct(MainAmmoSpawner ammoSpawner)
    {
        AmmoSpawner = ammoSpawner;
    }

    protected override void Attack()
    {
        Debug.Log(AmmoSpawner == null);
        Ammo ammo = AmmoSpawner.Spawn(_bulletPrefab);
        ammo.Init(ShootPoint.transform.position, GetBulletDirection());

        ammo.Activate();
    }

    protected virtual Quaternion GetBulletDirection()
    {
        Quaternion rotation = transform.rotation;

        rotation.z += Random.Range(-_spread, _spread);

        return rotation;
    }
}