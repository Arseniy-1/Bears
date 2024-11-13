using _Project.Scripts.Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputHandler))]
public class Player : Character, ITarget
{
    [SerializeField] private float _speed;

    public Vector2 Position => transform.position;
    private Mover _mover;
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputHandler = GetComponent<InputHandler>();
    }

    private void Start()
    {
        _mover = new Mover(this, _rigidbody2D, GunHolder, _inputHandler);
    }

    private void Update()
    {
        _mover.Run(_speed);
    }
    
    protected override void Interact(IInteractable interactable)
    {
        if (interactable is Weapon weapon)
        {
            GunHolder.EquipWeapon(weapon);
        }
    }
}