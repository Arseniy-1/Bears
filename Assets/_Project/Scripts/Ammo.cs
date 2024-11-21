using System;
using System.Collections;
using _Project.Scripts.Spawner;
using UnityEngine;

public class Ammo : MonoBehaviour, ISpawnable<Ammo>
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;
    private WaitForSeconds _waitLife;
    
    public event Action<Ammo> Destroying;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _waitLife = new WaitForSeconds(_lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(_damage);

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
        
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(WaitDestroy());
    }

    private void Destory()
    {
        Destroying?.Invoke(this);
    }

    private IEnumerator WaitDestroy()
    {
        yield return _waitLife;
        Destory();
    }
}