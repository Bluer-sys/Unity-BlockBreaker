using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _bounceFactor;

    private Rigidbody2D rigidbody;
    private AudioSource collisionSound;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collisionSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // ѕроигрывание звуков при столкновении с чем-либо.
    {
        collisionSound.pitch = Random.Range(1, 1.5f);
        collisionSound.Play();

        SetRandomBounceFactor();
    }

    public void SetRandomBounceFactor()
    {
        float randomBounceFactor = Random.Range(-_bounceFactor, _bounceFactor);
        Vector2 bounceTweak = new Vector2(randomBounceFactor, randomBounceFactor);
        rigidbody.velocity += bounceTweak;
    }
}
