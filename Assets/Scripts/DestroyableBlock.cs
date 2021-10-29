using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class DestroyableBlock : Block
{
    [SerializeField] private Sprite[] _damageLevels;
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _hitParticlePrefab;

    private SpriteRenderer spriteRenderer;
    private Color blockColor;

    public UnityAction WasDestroyed;

    private void OnValidate()
    {
        if (_health > 3 || _health < 0)
            _health = 3;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        blockColor = spriteRenderer.color;
    }

    private void OnCollisionEnter2D(Collision2D collision) // Получение урона при столкновении.
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            TryTakeDamege();
        }
    }

    private void TryTakeDamege()
    {
        _health--;
        CreateParticle();

        if (_health <= 0)
        {
            WasDestroyed?.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = _damageLevels[_health - 1];
        }
    }

    private void CreateParticle()
    {
        ParticleSystem effect = Instantiate(_hitParticlePrefab, transform.position, Quaternion.identity);
        effect.startColor = blockColor;
        effect.Play();
    }
}
