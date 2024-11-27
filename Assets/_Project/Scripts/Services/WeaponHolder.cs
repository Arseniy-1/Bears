using _Project.Scripts.Spawner;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private TargetScanner _targetScaner;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _positionHandRight;
    [SerializeField] private Transform _positionHandLeft;
    [SerializeField] private Transform _flipView;

    public TargetScanner TargetScanner => _targetScaner;
    public bool HasWeapon => _currentWeapon != null && _currentWeapon.gameObject.activeSelf;

    private Type _currentWeaponType => _currentWeapon.GetType();
    private readonly float _offset = 0.1f;

    private void Update()
    {
        if (HasWeapon)
        {
            CalculateOffset();
        }
    }

    private void CalculateOffset()
    {
        float angle = transform.rotation.eulerAngles.z;
        _positionHandLeft.position = _currentWeapon.transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(transform.localScale.x * _flipView.transform.localScale.x, 0, 0);
        _positionHandRight.position = _currentWeapon.transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(_offset, 0, 0);
    }

    public void Construct(TargetScanner targetScanner, MainAmmoSpawner ammoSpawner)
    {
        _targetScaner = targetScanner;

        if (_currentWeapon is RangeWeapon weapon)
        {
            weapon.Construct(ammoSpawner);
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (_currentWeapon.gameObject.activeSelf)
        {
            return;
        }

        _currentWeapon = weapon;
        _currentWeapon.Transform.parent = transform;
        _currentWeapon.Transform.position = _positionHandRight.position;
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
        _currentWeapon.gameObject.SetActive(false);
    }

    public void TakeWeapon()
    {
        _currentWeapon.gameObject.SetActive(true);
    }

    public void SpotTarget()
    {
        if (TargetScanner.HasTarget)
        {
            Vector3 targetPosition = _targetScaner.ClosestTarget.Position;
            var direction = targetPosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}