using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class DestroyableBlock : MonoBehaviour
{
    [SerializeField] private Sprite[] _damageLevels;
    [SerializeField] private int _health;

    private SpriteRenderer spriteRenderer;

    public UnityAction WasDestroyed;

    private void OnValidate()
    {
        if (_health > 3 || _health < 0)
            _health = 3;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
}
