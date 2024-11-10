using System.Collections.Generic;
using _Project.Scripts.Item;
using _Project.Scripts.Player.Inventory;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable, ITarget
{
    [SerializeField] private GunHolder _gunHolder;
    [SerializeField] private Health _health;
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private Inventory _inventory;

    public Vector2 Position => transform.position;

    private void OnEnable()
    {
        _health.Died += RaiseDeath;
        _collisionHandler.CollisionDetected += Interact;
    }

    private void OnDisable()
    {
        _health.Died -= RaiseDeath;
        _collisionHandler.CollisionDetected -= Interact;
    }

    public void TakeDamage(float amount)
    {
        _health.TakeDamage(amount);
    }

    private void Interact(IInteractable interactable)
    {
        if (interactable is Weapon weapon)
        {
            _gunHolder.EnquipWeapon(weapon);
        }
    }

    private void RaiseDeath()
    {
        Destroy(gameObject);
    }
}