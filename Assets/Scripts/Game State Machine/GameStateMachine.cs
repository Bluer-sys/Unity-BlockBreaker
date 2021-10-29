using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState CurrentState { get; private set; }

    public void EnterState(GameState newState)
    {
        ExitCurrentState();

        CurrentState = newState;
        CurrentState.Enter();
    }

    private void ExitCurrentState()
    {
        if(CurrentState != null)
        {
            CurrentState.Exit();
        }
    }
}
