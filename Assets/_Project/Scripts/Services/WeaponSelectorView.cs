using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorView : MonoBehaviour
{
    [SerializeField] private Image _currentGunView;
    [SerializeField] private List<Image> _gunsView;

    [SerializeField] private WeaponHolder _weaponHolder;

    private void OnEnable()
    {
        _weaponHolder.WeaponChanged += UpdateView;
    }

    private void OnDisable()
    {
        _weaponHolder.WeaponChanged -= UpdateView;
    }

    private void UpdateView()
    {
        foreach (Weapon weapon  in _weaponHolder.Weapons)
        {
            _currentGunView.sprite = _weaponHolder.CurrentWeapon.View.sprite;
        }
    }
}
