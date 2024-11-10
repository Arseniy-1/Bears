using System.Collections;
using UnityEngine;

public class ShootGun : Weapon
{
    [SerializeField] private Ammo _ammoPrefab;
    [SerializeField] private float _spread;

    private int _bulletCount = 6;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    public override void Attack()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Ammo ammo = Instantiate(_ammoPrefab, ShootPoint.transform.position, GetRandomSpread(ShootPoint.transform.rotation));
            ammo.Activate();
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Attack();
        }
    }

    private Quaternion GetRandomSpread(Quaternion rotation)
    {
        rotation.z += Random.Range(-_spread, _spread);

        return rotation;
    }
}
