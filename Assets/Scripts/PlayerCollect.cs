using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas scoreData;
    [SerializeField] private UIcontroller UIcontroller;

    public void UpdateScore(int Value)
    {
        scoreData.ScoreValue = Mathf.Clamp(scoreData.ScoreValue + Value, min:0, max:scoreData.ScoreValue + Value);
        UIcontroller.UpdateTextScore(scoreData.ScoreValue);
    }
}
