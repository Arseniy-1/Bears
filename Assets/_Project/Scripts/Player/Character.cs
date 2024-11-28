using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [field: SerializeField] public TargetScanner TargetScanner { get; protected set; }
    [field: SerializeField] public WeaponHolder WeaponHolder { get; protected set; }

    [field: SerializeField] public Animator Anim { get; protected set; }
    [field: SerializeField] protected Health health = new Health();

    protected virtual void Interact(IInteractable interactable) { }

    public Vector2 Position => transform.position;

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
    }
}