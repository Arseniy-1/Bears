using UnityEngine;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] public SpriteRenderer spriteCharacter;
    [SerializeField] public SpriteRenderer spriteWeapon;
    [SerializeField] protected Health health;
    [field: SerializeField] public GunHolder GunHolder { get; private set; }
    
    protected virtual void Interact(IInteractable interactable){}
    
    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
    }
}
