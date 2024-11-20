using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [field: SerializeField] public GunHolder GunHolder { get; private set; }
    [SerializeField] protected float maxHealth;

    public Health Health { get; protected set; }
    public Vector2 Position => transform.position;

    private void Start()
    {
        Health = new Health(maxHealth);
    }

    protected virtual void Interact(IInteractable interactable){}

    public void TakeDamage(float amount)
    {
        var hp = Health.TakeDamage(amount);
        Debug.Log(hp);
    }
}
