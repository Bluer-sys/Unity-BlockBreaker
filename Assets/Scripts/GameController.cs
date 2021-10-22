using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _blocksContainer;

    private int blocksCount;

    private void Start()
    {
        blocksCount = _blocksContainer.childCount;
        Debug.Log(blocksCount);
    }
}
