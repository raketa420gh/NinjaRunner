public class IdleRunnerState : RunnerCharacterState
{
    public IdleRunnerState(RunnerCharacter runnerCharacter, StateMachine stateMachine) : base(runnerCharacter, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _stateMachine.ChangeState(_runnerCharacter.IdleRunnerState);
    }
}