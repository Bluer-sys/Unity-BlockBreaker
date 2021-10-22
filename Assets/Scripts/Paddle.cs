using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _borderDelta;
    [SerializeField] private float _reboundForce;

    private float rightBorderX;
    private float leftBorderX;

    private void Awake()
    {
        rightBorderX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0f)).x - _borderDelta;
        leftBorderX = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x + _borderDelta;
    }

    private void Update()
    {
        MoveToMousePosition();   
    }

    private void OnCollisionEnter2D(Collision2D collision) // Разворот столкнувшегося предмета относительно подноса.
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody))
        {
            Vector2 paddlePosition = transform.position;
            Vector2 ballPosition = rigidbody.transform.position;
            Vector2 ballPositionRelativePaddle = paddlePosition - ballPosition;

            float ballOffsetX = Mathf.Clamp(ballPositionRelativePaddle.x, -1.0f, 1.0f);

            rigidbody.velocity = new Vector2(-ballOffsetX, 1) * _reboundForce;
        }
    }

    private void MoveToMousePosition()
    {
        float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mousePositionX = Mathf.Clamp(mousePositionX, leftBorderX, rightBorderX);

        Vector2 newPaddlePosition = new Vector2(mousePositionX, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, newPaddlePosition, _moveSpeed * Time.deltaTime);
    }

    private void MoveHorizontalAxis()
    {
        // TODO: Сделать ввод с клавиатуры.
    }
}
