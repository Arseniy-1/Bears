using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteCharacter; 
    [SerializeField] public SpriteRenderer spriteWeapon;
    [SerializeField] protected GunHolder gunHolder;
    [SerializeField] protected Health health;
    [SerializeField] protected CollisionHandler collisionHandler;
    
    private void OnEnable()
    {
        health.Died += RaiseDeath;
        collisionHandler.CollisionDetected += Interact;
    }

    private void OnDisable()
    {
        health.Died -= RaiseDeath;
        collisionHandler.CollisionDetected -= Interact;
    }

    public void TakeDamage(float amount)
    {
        health.TakeDamage(amount);
    }

    protected virtual void Interact(IInteractable interactable) { }

    private void RaiseDeath()
    {
        Destroy(gameObject);
    }
}
