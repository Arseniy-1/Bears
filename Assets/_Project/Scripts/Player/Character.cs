using UnityEngine;

public class Character : MonoBehaviour, IDamagable, ITarget
{
    [field: SerializeField] public CharacterAnimator Animator { get; protected set; }
    [field: SerializeField] public TargetScanner TargetScanner { get; protected set; }
    [field: SerializeField] public WeaponHolder WeaponHolder { get; protected set; }
    [field: SerializeField] public CharacterAnimator CharacterAnimator { get; protected set; }
    [field: SerializeField] public Rigidbody2D CharacterRigidbody2D { get; protected set; }

    [field: SerializeField] protected Health Health;

    public Vector2 Position => transform.position;

    protected virtual void Interact(IInteractable interactable)
    {
    }

    public void TakeDamage(float amount)
    {
        Health.TakeDamage(amount);
        Animator.TakeDamage();
    }

    public void TakeHeal(float amount)
    {
        Health.Heal(amount);
        Animator.TakeHeal();
    }

    public void TestTakeItem()
    {
        Debug.Log("Item");
        Animator.TakeItem();
    }
}