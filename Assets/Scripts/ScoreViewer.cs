using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreViewer : MonoBehaviour
{
    private int blocksCount;
    private TMP_Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    public void SetScore(int currentScore)
    {
        scoreText.text = currentScore.ToString() + " / " + blocksCount.ToString(); 
    }

    public void SetBlocksCount(int blocksCount)
    {
        this.blocksCount = blocksCount;
    }
}
