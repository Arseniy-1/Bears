using _Project.Scripts.Spawner;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    [SerializeField] private TargetScanner _targetScaner;

    [SerializeField] private Transform _rightHand;
    [SerializeField] private Transform _leftHand;

    [SerializeField] private Transform _flipView;

    public event Action WeaponChanged;

    public Weapon CurrentWeapon => _currentWeapon;
    public bool HasWeapon => _currentWeapon != null && _currentWeapon.gameObject.activeSelf;

    private void Update()
    {
        if (HasWeapon)
        {
            PutHands();
        }
    }

    private void PutHands()
    {
        _rightHand.transform.parent = _currentWeapon.RightHandPosition;
        _rightHand.transform.position = _currentWeapon.RightHandPosition.position;

        _leftHand.transform.parent = _currentWeapon.LeftHandPosition;
        _leftHand.transform.position = _currentWeapon.LeftHandPosition.position;
    }

    public void Construct(TargetScanner targetScanner, MainAmmoSpawner ammoSpawner)
    {
        _targetScaner = targetScanner;

        if (_currentWeapon is RangeWeapon weapon)
        {
            weapon.Construct(ammoSpawner);
        }
    }

    public void EquipWeapon(Weapon pickedWeapon)
    {
        if (pickedWeapon.gameObject.activeSelf)
        {
            return;
        }

        _currentWeapon = pickedWeapon;

        WeaponChanged?.Invoke();
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
