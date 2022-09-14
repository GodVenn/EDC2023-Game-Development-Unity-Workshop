using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterControllerScript : MonoBehaviour
{
    public CharacterController Controller;

    public float Gravity;
    
    public float JumpHeight;
    public float Speed;
    public float RotationSpeed;

    public Vector3 Velocity = Vector3.zero;

    private Vector2 MoveInput;
    private Vector2 LookInput;

    private bool _jumpTriggered;
    private bool _sprintButtonActivated;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Gravity = Physics.gravity.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();

        transform.Rotate(Vector3.up, LookInput.x * RotationSpeed * Time.deltaTime);

        Controller.Move(Velocity * Time.deltaTime);
    }

    private void HandleHorizontalMovement()
    {
        float currentSpeed = Speed;
        if (_sprintButtonActivated)
            currentSpeed = Speed * 2f;

        Vector3 forward = MoveInput.y * currentSpeed * transform.forward;
        Vector3 sideways = MoveInput.x * currentSpeed * transform.right;
        Velocity.x = forward.x + sideways.x;
        Velocity.z = forward.z + sideways.z;
    }

    private void HandleVerticalMovement()
    {
        Velocity.y += Gravity * Time.deltaTime;

        if (Controller.isGrounded)
        {
            Velocity.y = 0;
        }

        if (_jumpTriggered && Controller.isGrounded)
        {
            float yVel = Mathf.Sqrt(JumpHeight * -2f * Gravity);
            Velocity.y = yVel;
        }
    }

    public void OnJumpInput(CallbackContext context)
    {
        _jumpTriggered = context.ReadValueAsButton();
        Debug.Log("jump");
    }

    public void OnMoveInput(CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnLookInput(CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }

    public void OnSprintInput(CallbackContext context)
    {
        _sprintButtonActivated = context.ReadValueAsButton();
    }
}
