using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private Button _nextSceneButton;

    private int scenesCount;

    private void OnEnable()
    {
        scenesCount = SceneManager.sceneCountInBuildSettings;

        _nextSceneButton.onClick.AddListener(OnSwitchScene);
    }

    private void OnDisable()
    {
        _nextSceneButton.onClick.RemoveListener(OnSwitchScene);
    }

    private void OnSwitchScene()
    {
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        int nextSceneNumber = currentSceneNumber + 1;

        if (nextSceneNumber >= scenesCount)
        {
            nextSceneNumber = 0;
        }

        SceneManager.LoadScene(nextSceneNumber);
    }
}
