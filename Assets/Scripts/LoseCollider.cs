using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private string gameOverSceneName = "Game Over";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: ������� ��������� �����, � �� ������������ ��������.

        Cursor.visible = true;
        SceneManager.LoadScene(gameOverSceneName);
    }
}
