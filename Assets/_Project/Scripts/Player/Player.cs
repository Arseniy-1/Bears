using _Project.Scripts.Item.Resource;
using _Project.Scripts.Player;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class Player : Character
{
    [SerializeField] private float _speed;

    private CollisionHandler _collisionHandler;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private Mover _mover;

    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _inputHandler = GetComponent<InputHandler>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mover = new Mover(this, _rigidbody2D, _inputHandler);
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += Interact;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= Interact;
    }
    
    private void Start()
    {
        _mover = new Mover(this, _rigidbody2D, _inputHandler);
        health = new Health();
    }

    private void Update()
    {
        _mover.Run(_speed);
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