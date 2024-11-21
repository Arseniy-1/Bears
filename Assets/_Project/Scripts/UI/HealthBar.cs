using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Character _character;
    private Slider _slider;
    private float _offset = 1.5f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    /*private void LateUpdate()
    {
        var position = _character.transform.position;
        transform.position = new Vector3(position.x, position.y + _offset, 0);
    }*/

    public void SetCharacter(Character character)
    {
        /*_slider.gameObject.SetActive(false);*/
        _character = character;
        
        if (_character.Health != null)
        {
            _character.Health.HealthChanged += SetViewHealth;
        }
    }

    private void SetViewHealth(float currentHealthPoint, float maxHealth)
    {
        /*if (_slider.IsActive() == false)
            _slider.gameObject.SetActive(true);*/

        var normalizedValue = currentHealthPoint / maxHealth;
        _slider.value = normalizedValue;

        if ((int)normalizedValue <= 0) return;

        _character.Health.HealthChanged -= SetViewHealth;
        Destroy(gameObject);
    }
}