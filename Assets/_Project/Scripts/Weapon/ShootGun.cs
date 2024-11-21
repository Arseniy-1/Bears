using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootGun : RangeWeapon<Buckshot>
{
    [SerializeField, Range(0, 1), Header("(Разброс) Среднее значение: 0,2")] private float _spread;

    private readonly int _bulletCount = 6;

    protected override void Attack()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            base.Attack();
        }
    }

    protected override Quaternion GetBulletDirection()
    {
        Quaternion rotation = transform.rotation;

        rotation.z += Random.Range(-_spread, _spread);

        return rotation;
    }
}