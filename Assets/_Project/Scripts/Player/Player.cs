using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamagable, ITarget
{
    [SerializeField] private float _speed;

    public Vector2 Position => transform.position;
    private Mover _mover;

    private void Awake()
    {
        _mover = new Mover(this, GetComponent<Rigidbody2D>(), gunHolder.TargetScanner, GetComponent<InputHandler>());
    }

    private void Update()
    {
        _mover.Run(_speed);
    }
    
    protected override void Interact(IInteractable interactable)
    {
        if (interactable is Weapon weapon)
        {
            gunHolder.EnquipWeapon(weapon);
        }
    }
    
}