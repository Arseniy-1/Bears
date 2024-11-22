using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Collider2D _attackZone;
    [SerializeField] private ContactFilter2D _layerMask;
    [SerializeField] private float _damage;

    private void Start()
    {
        Attack();
    }

    protected override void Attack()
    {
        List<Collider2D> targets = new();
        int targetsCount = Physics2D.OverlapCollider(_attackZone, _layerMask, targets);

        for (int i = 0; i < targetsCount; i++)
        {
            if (targets[i].TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}
