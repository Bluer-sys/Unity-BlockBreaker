using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DestroyableBlock : MonoBehaviour
{
    [SerializeField] private Sprite[] _damageLevels;

    private SpriteRenderer spriteRenderer;
    private int health;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        health = _damageLevels.Length;
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
        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = _damageLevels[health - 1];
        }
    }
}
