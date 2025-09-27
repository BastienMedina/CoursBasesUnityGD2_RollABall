using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject DeathScreen;
    [SerializeField] private GameObject ScoreScreen;
    [SerializeField] private GameObject MainCamera;

    void Start()
    {
        Instantiate(ScoreScreen);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Death();
        }
        if (collision.gameObject.GetComponent<DeadZoneDestroy>()  != null)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        Destroy(ScoreScreen.gameObject);
        Instantiate(DeathScreen);
        Instantiate(MainCamera);
    }
}
