using _Project.Scripts.Spawner;
using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private TargetScanner _targetScaner;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _weaponPosition;
    [SerializeField] private Transform _weaponRotation;

    public TargetScanner TargetScanner => _targetScaner;
    public bool HasWeapon => _currentWeapon != null;
    
    private Type _currentWeaponType => _currentWeapon.GetType();
    private float _offsetX = -0.44f;
    private float _offsetY = 0.44f;
    private float _offsetRotationY = 151.5f;

    private void Update()
    {
        if (HasWeapon)
        {
            _currentWeapon.Transform.position = new Vector3(_weaponPosition.position.x + _offsetX, _weaponPosition.position.y + _offsetY);
            _currentWeapon.Transform.rotation = Quaternion.Euler(0, 0, _weaponRotation.transform.rotation.eulerAngles.z - _offsetRotationY);
        }
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
        _currentWeapon.Transform.position = _weaponPosition.position;
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
        if (TargetScanner.HasTarget)
        {
            Vector3 targetPosition = _targetScaner.ClosestTarget.Position;
            var direction = targetPosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}