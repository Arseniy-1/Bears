using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [SerializeField] protected Health health;
    [field: SerializeField] public GunHolder GunHolder { get; private set; }
    
    protected virtual void Interact(IInteractable interactable){}

    public Vector2 Position => transform.position;

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
    }
}
