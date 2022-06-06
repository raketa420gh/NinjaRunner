using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterRagdoll))]
[RequireComponent(typeof(CharacterAnimation))]

public class RunnerCharacter : MonoBehaviour
{
    public StateMachine RunnerCharacterStateMachine;
    public IdleRunnerState IdleRunnerState;
    
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private CharacterRagdoll _ragdoll;
    [SerializeField] private CharacterAnimation _animation;
    private IInputService _input;

    [Inject]
    public void Construct(IInputService input) => _input = input;

    private void OnEnable() => _movement.OnJump += OnJump;
    
    private void FixedUpdate()
    {
        _movement.RunForward();
        
        if (_input.Axis.x != 0)
            _movement.Move(Vector3.right * _input.Axis.x * 0.1f);
        if (Input.GetKeyDown(KeyCode.Space))
            _movement.Jump();
    }
    
    private void InitializeStateMachine()
    {
        RunnerCharacterStateMachine = new StateMachine();
        IdleRunnerState = new IdleRunnerState(this, RunnerCharacterStateMachine);
        RunnerCharacterStateMachine.ChangeState(IdleRunnerState);
    }

    private void OnJump() => _animation.ActivateAnimationTrigger(AnimationNames.Jump);
}