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

    //Fonction appeler a chaque activation du monobehavior
    private void OnEnable()
    {
        //Bind entre la fonction UpdateTextScore avec OntargetCollected
        PlayerCollect.OnTargetCollected += UpdateTextScore;
    }
    
    //Faction appeler a chaque desactivation du monobehavior
    private void OnDisable()
    {
        //Unbind entre la fonction UpdateTextScore avec OntargetCollected
        PlayerCollect.OnTargetCollected -= UpdateTextScore;
    }
}
