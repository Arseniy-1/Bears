using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private float _healthValue;
    [field: SerializeField] public GunHolder GunHolder { get; private set; }

    private Health _health;

    private void Start()
    {
        _health = new Health(_healthValue);
        
    }

    protected virtual void Interact(IInteractable interactable){}
    
    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }
}
