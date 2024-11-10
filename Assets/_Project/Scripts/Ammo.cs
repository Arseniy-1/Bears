using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Activate()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamagable damagable))
            damagable.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
