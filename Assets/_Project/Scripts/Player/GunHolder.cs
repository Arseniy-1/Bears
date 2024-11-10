using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private TargetScaner _targetScaner;

    private Weapon _currentWeapon;

    private void FixedUpdate()
    {
        if (_targetScaner.HasTarget)
            SpotTarget(_targetScaner.ClosestTarget.Position);
    }

    public void EnquipWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        _currentWeapon.Transform.parent = transform;
        _currentWeapon.Transform.position = transform.position;
        _currentWeapon.Transform.rotation = transform.rotation;
    }

    public void Shoot()
    {
        _currentWeapon.Shoot();
    }

    public void SpotTarget(Vector3 targetPosition)
    {
        var direction = targetPosition - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
