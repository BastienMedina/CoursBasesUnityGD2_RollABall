using UnityEngine;

public class RetryButtonDead : MonoBehaviour
{

    [SerializeField] private GameObject Player;

    public void Retry()
    {
        Instantiate(Player);
        Destroy(gameObject);
        Debug.LogError("tu a bien appuyer sur le bouton bg !!");
    }
}
