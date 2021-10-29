using UnityEngine;

public class BallLaunchedState : GameState
{
    [SerializeField] protected Ball _ball;
    [SerializeField] protected Paddle _paddle;
    [SerializeField] private float _launchForce;

    private Rigidbody2D ballRigidbody;

    protected override void Awake()
    {
        base.Awake();

        ballRigidbody = _ball.GetComponent<Rigidbody2D>();
    }

    public override void Enter()
    {
        base.Enter();

        LaunchBall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void InputUpdate()
    {
        base.InputUpdate();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        _paddle.MoveToMousePosition();
    }

    private void LaunchBall()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePosition - _ball.transform.position;
        ballRigidbody.velocity = mouseDirection.normalized * _launchForce;
    }
}
