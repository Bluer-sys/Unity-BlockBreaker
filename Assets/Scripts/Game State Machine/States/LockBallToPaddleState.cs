using UnityEngine;

public class LockBallToPaddleState : GameState
{
    [SerializeField] protected Ball _ball;
    [SerializeField] protected Paddle _paddle;

    private Vector2 paddleToBallVector;

    public override void Enter()
    {
        base.Enter();

        paddleToBallVector = _ball.transform.position - _paddle.transform.position;
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void InputUpdate()
    {
        base.InputUpdate();

        if(Input.GetMouseButtonDown(0))
        {
            StateMachine.EnterState(NextState);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Vector2 paddlePosition = _paddle.transform.position;
        _ball.transform.position = paddlePosition + paddleToBallVector;

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        _paddle.MoveToMousePosition();
    }
}
