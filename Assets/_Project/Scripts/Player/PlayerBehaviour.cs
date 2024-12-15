using _Project.Scripts.Item.Resource;
using PlayerSystem;
using UnityEngine;

public class PlayerBehaviour : Character
{
    [SerializeField] private PlayerMover _mover;

    private CollisionHandler _collisionHandler;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mover.Initialize(this, _rigidbody2D, _inputHandler);
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
                Animator.StartRunningWithWeapon();
            }
            else
            {
                Animator.StartRunning();
            }
        }
        else
        {
            Animator.StartIdle();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            WeaponHolder.SwitchWeapon();
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
