using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject ScoreScreen;

    void Start()
    {
        Instantiate(ScoreScreen);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
            Instantiate(DeathScreen);
        }
    }
}
