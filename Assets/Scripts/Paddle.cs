using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _mouseMoveSpeed;
    //[SerializeField] private float _keyboardMoveSpeed;
    [SerializeField] private float _borderDelta;
    [SerializeField] private float _reboundForce;

    private float rightBorderX;
    private float leftBorderX;

    private void Awake()
    {
        rightBorderX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x - _borderDelta;
        leftBorderX = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x + _borderDelta;
    }

    private void OnCollisionEnter2D(Collision2D collision) // Разворот столкнувшегося предмета относительно подноса.
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody))
        {
            Vector2 paddlePosition = transform.position;
            Vector2 ballPosition = rigidbody.transform.position;
            Vector2 ballPositionRelativePaddle = paddlePosition - ballPosition;

            float ballOffsetX = Mathf.Clamp(ballPositionRelativePaddle.x, -1.0f, 1.0f);

            rigidbody.velocity = new Vector2(-ballOffsetX, 1);
            rigidbody.velocity = rigidbody.velocity.normalized * _reboundForce;
        }
    }

    public void MoveToMousePosition()
    {
        float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePositionX = Mathf.Clamp(mousePositionX, leftBorderX, rightBorderX);

        Vector2 newPaddlePosition = new Vector2(mousePositionX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, newPaddlePosition, _mouseMoveSpeed * Time.deltaTime);
    }

    /*private void MoveHorizontalAxis()
    {
        float inputAxis = Input.GetAxisRaw("Horizontal");

        float movePositionX = Mathf.Clamp(transform.position.x + inputAxis * _keyboardMoveSpeed * Time.deltaTime, leftBorderX, rightBorderX);
        transform.position = new Vector2(movePositionX, transform.position.y);
    }*/
}
