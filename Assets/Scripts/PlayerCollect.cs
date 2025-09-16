using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas scoreData;

    public void UpdateScore(int Value)
    {
        scoreData.ScoreValue = Mathf.Clamp(scoreData.ScoreValue + Value, min:0, max:scoreData.ScoreValue + Value);
    }
}
