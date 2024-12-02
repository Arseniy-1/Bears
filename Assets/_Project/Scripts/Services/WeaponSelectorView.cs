using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorView : MonoBehaviour
{
    [SerializeField] private Image _currentGunView;
    [SerializeField] private List<Image> _gunsView;

    [SerializeField] private WeaponHolder _weaponHolder;

    private Queue<Image> _gunsViewStack = new();

    private void Start()
    {
        //UpdateView();
    }

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
        _currentGunView.sprite = _weaponHolder.CurrentWeapon.Icon.sprite;
    }
}
