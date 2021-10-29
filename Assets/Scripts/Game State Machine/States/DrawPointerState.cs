using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawPointerState : GameState
{
    [SerializeField] private Ball _ball;

    private LineRenderer lineRenderer;

    protected override void Awake()
    {
        base.Awake();

        lineRenderer = GetComponent<LineRenderer>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        lineRenderer.SetPosition(0, Vector2.zero);
        lineRenderer.SetPosition(1, Vector2.zero);
    }

    public override void InputUpdate()
    {
        base.InputUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            StateMachine.EnterState(NextState);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();

        DrawLinePointer();
    }

    public void DrawLinePointer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePosition - _ball.transform.position;
        var ray = new Ray2D(_ball.transform.position, mouseDirection);

        int layerMask = 1 << 7;
        layerMask = ~layerMask;
        var hit = Physics2D.Raycast(ray.origin, ray.direction, 50, layerMask);
        Debug.Log(hit.collider.name);


        lineRenderer.SetPosition(0, _ball.transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }
}
