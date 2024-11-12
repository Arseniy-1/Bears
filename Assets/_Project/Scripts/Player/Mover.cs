using UnityEngine;

public class Mover
{
    private InputHandler _inputHandler;
    private Rigidbody2D _rigidbody2D;
    private Turning _turning;

    public float HorizontalSpeed => _rigidbody2D.velocity.x;

    public Mover(Character character, Rigidbody2D rigidbody2D, TargetScanner targetScanner, InputHandler inputHandler)
    {
        _turning = new Turning(character, targetScanner);
        _rigidbody2D = rigidbody2D;
        _inputHandler = inputHandler;
    }

    public void Run(float speed)
    {
        float currentHorizontalSpeed = _inputHandler.HorizontalDirection * speed;
        float currentVerticalSpeed = _inputHandler.VerticalDirection * speed;

        _rigidbody2D.velocity = new Vector2(currentHorizontalSpeed, currentVerticalSpeed);
        _turning.CorrectFlip((int)currentHorizontalSpeed);
    }
}
