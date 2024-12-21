using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorView : MonoBehaviour
{
    [SerializeField] private Image _currentGunView;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private List<Image> _gunsView;

    [SerializeField] private WeaponHolder _weaponHolder;

    private Queue<Image> _gunsViewStack = new();
    private readonly float _startRotationAngle = 90f;
    private float _endRotationAngle = 0f;

    private void Start()
    {
        _currentGunView.sprite = _weaponHolder.CurrentWeapon.Icon.sprite;
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
        DOVirtual.Float(_rectTransform.rotation.y, _startRotationAngle, 0.5f,
                value => { _rectTransform.localEulerAngles = new Vector3(0, value, 0); })
            .SetEase(Ease.InOutQuad)
            .SetLoops(2, LoopType.Yoyo)
            .OnStepComplete(() => { _currentGunView.sprite = _weaponHolder.CurrentWeapon.Icon.sprite; });
    }
}