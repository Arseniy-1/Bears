using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private TargetScanner _targetScaner;
    [SerializeField] private Weapon _currentWeapon;

    public void EquipWeapon(Weapon weapon)
    {
        if (_currentWeapon.gameObject.activeSelf)
        {
            return;
        }
        
        _currentWeapon = weapon;
        _currentWeapon.Transform.parent = transform;
        _currentWeapon.Transform.position = transform.position;
        _currentWeapon.Transform.rotation = transform.rotation;
        _currentWeapon.Transform.localScale = transform.localScale;
    }

    public void Shoot()
    {
        _currentWeapon.TryAttack();
    }

    public void ReturnWeapon()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    public void SpotTarget()
    {
        if (_targetScaner.HasTarget)
        {
            Vector3 targetPosition = _targetScaner.ClosestTarget.Position;
            var direction = targetPosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
