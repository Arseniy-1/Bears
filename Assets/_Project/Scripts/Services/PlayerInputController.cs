using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _payerInput;

    public Vector2 InputDirection => _payerInput.Player.Move.ReadValue<Vector2>();

    public event Action JumpButtonPressed;
    public event Action MoveButtonPressed;

    public event Action ShootButtonPressed;
    public event Action SwitchButtonPressed;

    private void Awake()
    {
        _payerInput = new PlayerInput();
        _payerInput.Enable();
    }

    private void OnEnable()
    {
        _payerInput.Player.Jump.performed += OnJumpPerformed;
        _payerInput.Player.Shoot.performed += OnShootPreformed;
        _payerInput.Player.SwitchWeapon.performed += OnSwitchWeaponPreformed;
    }

    private void OnDisable()
    {
        _payerInput.Player.Jump.performed -= OnJumpPerformed;
        _payerInput.Player.Shoot.performed -= OnShootPreformed;
        _payerInput.Player.SwitchWeapon.performed -= OnSwitchWeaponPreformed;
    }

    private void Update()
    {
        ReadIMovemetInput();
    }

    private void OnJumpPerformed(InputAction.CallbackContext callbackContext)
    {
        JumpButtonPressed?.Invoke();
    }

    private void OnShootPreformed(InputAction.CallbackContext callbackContext)
    {
        ShootButtonPressed?.Invoke();
    }

    private void OnSwitchWeaponPreformed(InputAction.CallbackContext callbackContext)
    {
        SwitchButtonPressed?.Invoke();
    }

    private void ReadIMovemetInput()
    {
        MoveButtonPressed?.Invoke();
    }
}
