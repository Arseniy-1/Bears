using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private WeaponHolder _weaponHolder;
    [SerializeField] private List<Weapon> _weapons;

    private int _currentWeaponIndex;

    public IReadOnlyList<Weapon> Weapons => _weapons;

    public void SwitchWeapon()
    {
        _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Count;
        _weaponHolder.EquipWeapon(_weapons[_currentWeaponIndex]);

        foreach (Weapon weapon in _weapons)
            weapon.gameObject.SetActive(false);

        _weapons[_currentWeaponIndex].gameObject.SetActive(true);
    }
}