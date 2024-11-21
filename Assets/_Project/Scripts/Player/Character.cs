using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [field: SerializeField] public GunHolder GunHolder { get; private set; }
    [SerializeField] protected float maxHealth;
    
    public Health Health { get; private set; }
    public Vector2 Position => transform.position;
    
    protected virtual void Start()
    {
        Health = new Health(maxHealth);
        Health.Died += TakeDead;
    }
    
    [SerializeField] protected float healthValue;
    
    public Health health { get; protected set; }

    protected virtual void Interact(IInteractable interactable){}

    public void TakeDamage(float amount)
    {
        Health.TakeDamage(amount);
    }
    
    private void TakeDead()
    {
        Destroy(gameObject);
    }
}
