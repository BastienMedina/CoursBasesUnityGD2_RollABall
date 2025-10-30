using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private RespawnManager _respawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.GetComponent<PlayerMouvements>() != null)
        {
            _respawnManager.PlayerDead();
        }
    }
}
