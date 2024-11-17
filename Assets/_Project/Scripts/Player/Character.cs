using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [field: SerializeField] public TargetScanner TargetScanner { get; private set; }
    [field: SerializeField] public GunHolder GunHolder { get; private set; }

    [SerializeField] protected Health health;

    protected virtual void Interact(IInteractable interactable){}

    public Vector2 Position => transform.position;

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
    }
}
