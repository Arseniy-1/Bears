using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    
    private Slider _slider;
    private float _offset = 1.5f;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.gameObject.SetActive(false);
        
        if (_character != null && _character.Health != null)
        {
            _character.Health.HealthChanged += SetViewHealth;
        }
        else
        {
            Debug.LogError("Health не найден!");
        }
    }

    private void OnDisable()
    {
        _character.Health.HealthChanged -= SetViewHealth;
    }

    private void LateUpdate()
    {
        var position = _character.transform.position;
        transform.position = new Vector3(position.x, position.y + _offset, 0);
    }

    private void SetViewHealth(float currentHealthPoint, float maxHealth)
    {
        /*if (_slider.IsActive() == false)
            _slider.gameObject.SetActive(true);*/
        
        var normalizedValue = currentHealthPoint / maxHealth;
        _slider.value = normalizedValue;
    }
}
