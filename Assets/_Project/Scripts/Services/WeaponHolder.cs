using _Project.Scripts.Spawner;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Weapon _currentWeapon;

    public IReadOnlyList<Weapon> Weapons => _weapons;
    public Weapon CurrentWeapon => _currentWeapon;

    [SerializeField] private TargetScanner _targetScaner;
    [SerializeField] private Transform _rightHandPosition;
    [SerializeField] private Transform _positionHandLeft;
    [SerializeField] private Transform _flipView;

    private int _currentWeaponIndex;

    private readonly float _offset = 0.1f;

    public event Action WeaponChanged;

    public bool HasWeapon => _currentWeapon != null && _currentWeapon.gameObject.activeSelf;

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
        _rightHandPosition.position = _currentWeapon.transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(_offset, 0, 0);
    }

    public void SwitchWeapon()
    {
        _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Count;
        EquipWeapon(_weapons[_currentWeaponIndex]);
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

        foreach (Weapon weapon in _weapons)
            weapon.gameObject.SetActive(false);

        _currentWeapon.gameObject.SetActive(true);

        WeaponChanged.Invoke();
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

public class WeaponCell : MonoBehaviour
{
    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    [field: SerializeField] public Weapon Weapon { get; private set; }
}