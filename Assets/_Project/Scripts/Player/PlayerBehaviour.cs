using _Project.Scripts.Item.Resource;
using EnemyStateMashine;
using PlayerSystem;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Character
{
    [field: SerializeField] public PlayerInputController PlayerInputController { get; private set; }
    [field: SerializeField] public PlayerMover Mover { get; private set; }
    [field: SerializeField] public Jumper Jumper { get; private set; }

    [SerializeField] private WeaponSelector _weaponSelector;

    private CollisionHandler _collisionHandler;
    private EntityStateMachine _stateMachine;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        CharacterRigidbody2D = GetComponent<Rigidbody2D>();
        Mover.Initialize(this);
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += Interact;
        PlayerInputController.ShootButtonPressed += Shoot;
        PlayerInputController.SwitchButtonPressed += SwitchWeapon;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Interact;
        PlayerInputController.ShootButtonPressed -= Shoot;
        PlayerInputController.SwitchButtonPressed -= SwitchWeapon;
    }

    private void FixedUpdate()
    {
        if (TargetScanner.HasTarget)
        {
            WeaponHolder.SpotTarget();
        }
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    public void Construct(EntityStateMachine playerStateMashine)
    {
        _stateMachine = playerStateMashine;
    }

    //TODO: Так быть не должно, это не логика Player
    private void SwitchWeapon()
    {
        _weaponSelector.SwitchWeapon();
    }

    private void Shoot()
    {
        WeaponHolder.Shoot();
    }
    //

    protected override void Interact(IInteractable interactable)
    {
        interactable.ViewAction();

        if (interactable is Weapon weapon)
        {
            WeaponHolder.EquipWeapon(weapon);
        }

        if (interactable is Resource resource)
        {
            resource.Put(); // TODO - кладём в инвентарь.
        }
    }
}
