using _Project.Scripts.Spawner;
using Sirenix.OdinInspector;
using System;
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

    private void Start()
    {
        if (HasWeapon)
        {
            PutHands();
        }
    }

    [Button]
    public void PutHands()
    {
        if(_currentWeapon.RightHand == null || _currentWeapon.LeftHand == null)
            return;

        _rightHand.transform.parent = _currentWeapon.RightHand;
        _rightHand.transform.position = _currentWeapon.RightHand.position;

        _leftHand.transform.parent = _currentWeapon.LeftHand;
        _leftHand.transform.position = _currentWeapon.LeftHand.position;

        _currentWeapon.gameObject.SetActive(true); 
    }

    [Button]
    public void DeselectWeapon()
    {
        _rightHand.transform.parent = null;
        _leftHand.transform.parent = null;

        _currentWeapon.gameObject.SetActive(false); 
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
