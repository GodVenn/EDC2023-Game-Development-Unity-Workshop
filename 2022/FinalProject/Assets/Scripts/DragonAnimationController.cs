using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerControllerInput))]
[RequireComponent(typeof(Animator))]
public class DragonAnimationController : MonoBehaviour
{
    private PlayerControllerInput _playerInput;

    private Animator _animator;
    #region Animator parameters
    private int _isDead;
    private int _isSprintActivated;
    private int _isIdle;
    private int _jumpTrigger;
    private int _rightLeftSpeed;
    private int _frontBackSpeed;
    private int _baseMovementSpeed;
    private int _isMovingFrontBack;
    #endregion
    private void Start()
    {
        _playerInput = GetComponent<PlayerControllerInput>();
        _animator = GetComponent<Animator>();
        _isDead = Animator.StringToHash("IsDead");
        _isSprintActivated = Animator.StringToHash("IsSprintActivated");
        _isIdle = Animator.StringToHash("IsIdle");
        _jumpTrigger = Animator.StringToHash("Jump");
        _rightLeftSpeed = Animator.StringToHash("RightLeftSpeed");
        _frontBackSpeed = Animator.StringToHash("FrontBackSpeed");
        _baseMovementSpeed = Animator.StringToHash("BaseMovementSpeed");
        _isMovingFrontBack = Animator.StringToHash("IsMovingFrontBack");
    }

    private void Update()
    {
        if (_playerInput.JumpTriggered)
            _animator.SetTrigger(_jumpTrigger);

        _animator.SetFloat(_rightLeftSpeed, _playerInput.LastMoveInput.x);
        _animator.SetFloat(_baseMovementSpeed, _playerInput.Speed);
        _animator.SetFloat(_frontBackSpeed, _playerInput.LastMoveInput.y);
        _animator.SetBool(_isSprintActivated, _playerInput.Sprinting);
        _animator.SetBool(_isIdle, _playerInput.Velocity.x == 0 && _playerInput.Velocity.z == 0);
        _animator.SetBool(_isMovingFrontBack, _playerInput.FrontBackMovement);
    }

    public void MidJumpEvent(AnimationEvent animationEvent)
    {
        _animator.ResetTrigger(_jumpTrigger);
        Debug.Log("Reset");
    }
}
