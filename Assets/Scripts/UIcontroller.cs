using UnityEngine;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private ScoreDatas ScoreDatas;

    void Start()
    {
        UpdateTextScore(ScoreDatas.ScoreValue);
    }

    public void UpdateTextScore(int NewScore)
    {
        ScoreText.text = $"Score : {NewScore.ToString()}";
    }
}
