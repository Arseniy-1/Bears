public class ShootGun : RangeWeapon
{
    private readonly int _bulletCount = 6;

    protected override void Attack()
    {
        for (int i = 0; i < _bulletCount; i++)
        {
            base.Attack();
        }
    }
}
