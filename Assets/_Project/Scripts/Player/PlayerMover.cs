using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Character))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputHandler _inputHandler;

    private Character _character;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Turning _turning;

    public float HorizontalSpeed => _rigidbody2D.velocity.x;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _turning = new Turning(_character);
    }

    private void Update()
    {
        float currentHorizontalSpeed = _inputHandler.HorizontalDirection * _speed;
        float currentVerticalSpeed = _inputHandler.VerticalDirection * _speed;

        _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
        _turning.CorrectFlip(currentHorizontalSpeed < 0);
    }
}
