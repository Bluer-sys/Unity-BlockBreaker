using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _blocksContainer;
    [SerializeField] private SceneSwitcher _sceneSwitcher;
    [SerializeField] private Button _nextSceneButton;

    private int blocksCount;
    private int destroyedBlocksCount;

    private void Awake()
    {
        _nextSceneButton.gameObject.SetActive(false);
        destroyedBlocksCount = 0;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        SubscribeDestroyEvent();
    }

    private void Start()
    {
        blocksCount = _blocksContainer.childCount;
    }

    private void OnBlockDestroyed()
    {
        destroyedBlocksCount++;

        if(destroyedBlocksCount == blocksCount)
        {
            UnsubscribeDestroyEvent();

            Cursor.visible = true;
            Time.timeScale = 0;
            _nextSceneButton.gameObject.SetActive(true);
        }
    }

    private void UnsubscribeDestroyEvent()
    {
        var blocks = _blocksContainer.GetComponentsInChildren<DestroyableBlock>();

        foreach (var block in blocks)
        {
            block.WasDestroyed -= OnBlockDestroyed;
        }
    }

    private void SubscribeDestroyEvent()
    {
        var blocks = _blocksContainer.GetComponentsInChildren<DestroyableBlock>();

        foreach (var block in blocks)
        {
            block.WasDestroyed += OnBlockDestroyed;
        }
    }
}
