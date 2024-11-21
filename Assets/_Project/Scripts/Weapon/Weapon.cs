using _Project.Scripts.Spawner;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _reloadTime;

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

public abstract class RangeWeapon<T> : Weapon where T : Ammo
{
    [SerializeField] protected Transform ShootPoint;

    protected MotherAmmoBoss AmmoSpawner;

    public void Construct(MotherAmmoBoss ammoSpawner)
    {
        AmmoSpawner = ammoSpawner;
    }

    protected override void Attack()
    {
        Debug.Log(AmmoSpawner==null);
        Ammo ammo = AmmoSpawner.Spawn<T>();
        ammo.Init(ShootPoint.transform.position, GetBulletDirection());

        ammo.Activate();
    }

    protected abstract Quaternion GetBulletDirection();
}