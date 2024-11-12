using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private TargetScaner _targetScaner;
    [SerializeField] private Weapon _currentWeapon;

    public void EnquipWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        _currentWeapon.Transform.parent = transform;
        _currentWeapon.Transform.position = transform.position;
        _currentWeapon.Transform.rotation = transform.rotation;
    }

    public void Shoot()
    {
        _currentWeapon.TryAttack();
    }

    public void SpotTarget()
    {
        Vector3 targetPosition = _targetScaner.ClosestTarget.Position;
        var direction = targetPosition - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
