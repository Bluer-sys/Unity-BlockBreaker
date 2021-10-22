using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle _paddle1;
    [SerializeField] private float _launchForce;

    private Rigidbody2D rigidbody;
    private Vector2 paddleToBallVector;
    private bool hasStarted;
    private AudioSource collisionSound;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collisionSound = GetComponent<AudioSource>();

        paddleToBallVector = transform.position - _paddle1.transform.position;
    }

    private void OnEnable()
    {
        hasStarted = false;
    }

    private void Update()
    {
        if (!hasStarted)
        {
            LockToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ѕроигрывание звуков при столкновении с чем-либо.
    {
        if (hasStarted)
        {
            collisionSound.pitch = Random.Range(1, 1.4f);
            collisionSound.Play();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            hasStarted = true;
            rigidbody.velocity = Vector2.up * _launchForce;
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePosition = _paddle1.transform.position;
        transform.position = paddlePosition + paddleToBallVector;
    }
}
