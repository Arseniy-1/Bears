using PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    
    private PlayerInput _payerInput;

    private void OnEnable()
    {
        _payerInput.Player.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        _payerInput.Player.Jump.performed -= OnJumpPerformed;
    }

    private void Awake()
    {
        _payerInput = new PlayerInput();
        _payerInput.Enable();
    }

    private void Update()
    {
        ReadIMovemetInput();
    }

    private void OnJumpPerformed(InputAction.CallbackContext callbackContext)
    {
        //TODO: Call player to jump
    }

    private void ReadIMovemetInput()
    {
        Vector2 inputDirection = _payerInput.Player.Move.ReadValue<Vector2>();
        _playerMover.Run(inputDirection);
    }
}
