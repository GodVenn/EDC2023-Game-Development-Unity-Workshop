using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerInput : MonoBehaviour
{
    private CharacterController _characterController;
    public bool FrontBackMovement { get; private set; }
    public Vector2 LastMoveInput { get; private set; }
    public Vector2 LastLookInput { get; private set; }
    public Vector3 Velocity { get; private set; }
    public bool Sprinting { get; private set; }
    private bool _sprintButtonActivated;
    public bool JumpTriggered { get; private set; }
    private float _gravity;

    // Speed per second
    public float JumpHeight = 5f;
    public float Speed = 2f;
    public float SprintMultiplier = 2f;
    public float RotationSpeed = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _gravity = Physics.gravity.y;
    }

    // Update is called once per frame
    private void Update()
    {
        // Can either move sideways or back/forward
        FrontBackMovement = Mathf.Abs(LastMoveInput.y) > 0.5f;

        // Get input velocity
        // Can only sprint forward
        Sprinting = _sprintButtonActivated && FrontBackMovement && LastMoveInput.y > 0;
        float currentSpeed = Sprinting ? Speed * SprintMultiplier : Speed;

        Vector3 sideways = Vector3.zero;
        Vector3 forward = Vector3.zero;
        if (FrontBackMovement)
            forward = currentSpeed * LastMoveInput.y * transform.forward;
        else
            sideways = currentSpeed * LastMoveInput.x * transform.right;

        // Handle jumping and falling
        Vector3 up = new(0, Velocity.y, 0);
        up.y += _gravity * Time.deltaTime;

        if (_characterController.isGrounded)
            up.y = 0;

        if (JumpTriggered && _characterController.isGrounded)
            up.y += Mathf.Sqrt(JumpHeight * -2f * _gravity);

        // Apply velocity
        Velocity = sideways + forward + up;
        if (Velocity != Vector3.zero)
            _characterController.Move(Velocity * Time.deltaTime);

        // Handle rotation
        transform.Rotate(Vector3.up, LastLookInput.x * RotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Velocity);
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        LastMoveInput = context.ReadValue<Vector2>();
    }

    public void OnSprintInput(InputAction.CallbackContext context)
    {
        _sprintButtonActivated = context.ReadValueAsButton();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        JumpTriggered = context.ReadValueAsButton();
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        LastLookInput = context.ReadValue<Vector2>();
    }
}
