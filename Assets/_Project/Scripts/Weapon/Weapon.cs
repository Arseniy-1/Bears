using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField, Range(0.01f, 20)] private float _reloadTime;

    private float _currentTime = 0;

    [SerializeField] protected Animator WeaponAnimator;

    [field: SerializeField] public Transform RightHandPosition { get; private set; }
    [field: SerializeField] public Transform LeftHandPosition { get; private set; }
    [field: SerializeField] public SpriteRenderer Icon { get; private set; }

    public Transform Transform { get; private set; }
    public bool IsReloaded { get; protected set; }

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
