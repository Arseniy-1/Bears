using UnityEngine;

public class ShootGun : Weapon
{
    [SerializeField] private Ammo _ammoPrefab;

    private int _bulletCount = 1;

    public override void Attack()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            Ammo ammo = Instantiate(_ammoPrefab, ShootPoint.transform.position, ShootPoint.transform.rotation);
            ammo.Activate();
        }
    }
}
