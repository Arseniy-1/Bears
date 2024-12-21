using System;
using System.Collections;
using _Project.Scripts.Spawner;
using UnityEngine;

public abstract class Ammo : MonoBehaviour, IDestoyable<Ammo>
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;
    private WaitForSeconds _waitLife;

    public event Action<Ammo> Destroed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _waitLife = new WaitForSeconds(_lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);

            Destory();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(_damage);

        if (collision.collider.TryGetComponent(out Ammo ammo))
            return;

        Destory();
    }

    public void Activate()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    public void Init(Vector3 startPosition, Quaternion rotation)
    {
        transform.position = startPosition;
        transform.rotation = rotation;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(WaitDestroy());
    }

    protected virtual void Destory()
    {
        Destroed?.Invoke(this);
    }

    private IEnumerator WaitDestroy()
    {
        yield return _waitLife;
        Destory();
    }
}