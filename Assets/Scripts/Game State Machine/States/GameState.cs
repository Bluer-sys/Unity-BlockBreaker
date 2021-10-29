using UnityEngine;

[RequireComponent(typeof(GameStateMachine))]
public abstract class GameState : MonoBehaviour
{
    [SerializeField] protected GameState NextState;

    protected GameStateMachine StateMachine;

    protected virtual void Awake()
    {
        StateMachine = GetComponent<GameStateMachine>();
    }

    public virtual void Enter()
    {   
    }

    public virtual void Exit()
    {
    }

    public virtual void InputUpdate()
    {
    }

    public virtual void PhysicUpdate()
    {
    }

    public virtual void LogicUpdate()
    {
    }
}
