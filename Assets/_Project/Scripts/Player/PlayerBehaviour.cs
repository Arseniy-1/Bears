using _Project.Scripts.Item.Resource;
using EnemyStateMashine;
using PlayerSystem;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : Character
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private WeaponSelector _weaponSelector;

    private CollisionHandler _collisionHandler;
    private Rigidbody2D _rigidbody2D;
    private EntityStateMachine _stateMachine;

    [field: SerializeField] public InputHandler InputHandler {  get; private set; }

    private void Awake()
    {
        List<IState> states = new List<IState>
        {
            new 
        };

        _stateMachine = new EntityStateMachine();
        _collisionHandler = GetComponent<CollisionHandler>();
        InputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mover.Initialize(this, _rigidbody2D, InputHandler);
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += Interact;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Interact;
    }

    private void FixedUpdate()
    {
        if (_mover.IsRunning())
        {
            if (WeaponHolder.HasWeapon)
            {
                CharacterAnimator.StartRunningWithWeapon();
            }
            else
            {
                CharacterAnimator.StartRunning();
            }
        }
        else
        {
            CharacterAnimator.StartIdle();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _weaponSelector.SwitchWeapon();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            WeaponHolder.Shoot();
        }
    }

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
