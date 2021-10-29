using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _blocksContainer;
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private ScoreViewer _scoreViewer;

    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private GameState _firstState;

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
        _stateMachine.EnterState(_firstState);

        SubscribeDestroyEvent();
    }

    private void Start()
    {
        blocksCount = _blocksContainer.childCount;

        _scoreViewer.SetBlocksCount(blocksCount);
        _scoreViewer.SetScore(destroyedBlocksCount);
    }

    private void Update()
    {
        _stateMachine.CurrentState.InputUpdate();
        _stateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicUpdate();
    }

    private void OnBlockDestroyed()
    {
        destroyedBlocksCount++;
        _scoreViewer.SetScore(destroyedBlocksCount);

        if (destroyedBlocksCount == blocksCount)
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
