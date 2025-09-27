using UnityEngine;

public class RetryButtonDead : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject MainCamera;

    public void Retry()
    {
        Destroy(MainCamera.gameObject);
        Instantiate(Player);
        Destroy(gameObject);
        Debug.LogError("tu a bien appuyer sur le bouton bg !!");
    }
}
