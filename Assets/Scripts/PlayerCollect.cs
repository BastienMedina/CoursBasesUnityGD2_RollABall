using UnityEngine;
using System;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas scoreData;
    [SerializeField] private UIcontroller UIcontroller;

//Definition de l'action (event dispatcher), avec le parametre d'entrée(aussi appeler input), ici c'est un int
    public static Action<int> OnTargetCollected;

    public void UpdateScore(int Value)
    {
        scoreData.ScoreValue = Mathf.Clamp(scoreData.ScoreValue + Value, min:0, max:scoreData.ScoreValue + Value);
        //UIcontroller.UpdateTextScore(scoreData.ScoreValue);
        //Call l'event, on invoke l'input entre parenthese, en C#
        OnTargetCollected?.Invoke(scoreData.ScoreValue);
    }
}
