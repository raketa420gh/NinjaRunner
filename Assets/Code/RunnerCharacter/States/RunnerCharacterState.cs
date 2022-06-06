public class RunnerCharacterState : BaseState
{
    protected RunnerCharacter _runnerCharacter;
    protected StateMachine _stateMachine;

    protected RunnerCharacterState(RunnerCharacter runnerCharacter, StateMachine stateMachine)
    {
        _runnerCharacter = runnerCharacter;
        _stateMachine = stateMachine;
    }
}