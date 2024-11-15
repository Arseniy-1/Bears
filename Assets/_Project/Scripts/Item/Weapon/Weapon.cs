using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _reloadTime;
    
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] protected Animator WeaponAnimator;

    private float _currentTime = 0;

    public Transform Transform { get; private set; }
    public bool IsReloaded { get; protected set; } = false;

    private void FixedUpdate()
    {
        if (_currentTime < _reloadTime && IsReloaded == false)
            _currentTime += Time.deltaTime;

        if (_currentTime >= _reloadTime)
            Reload();
    }

    private void Awake()
    {
        Transform = transform;
    }

    protected abstract void Attack();

    public virtual void TryAttack()
    {
        if (IsReloaded == false)
            return;

        Attack();

        IsReloaded = false;
    }

    public virtual void Reload()
    {
        _currentTime = 0;
        IsReloaded = true;
        //todo: Play reload animation
    }
}

class Animal
{
    protected float Weight;

    public virtual void Test()
    {
        Debug.Log("im Animal");
    }
}

class Cat: Animal
{
    public override void Test()
    {
        base.Test();
        Debug.Log("im Animal");
    }
}
