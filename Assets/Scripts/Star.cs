using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private CollectItems _collect;
    [SerializeField] private int StarAmount = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMouvements>() != null)
        {
            _collect.AddCoins(StarAmount);
            Destroy(gameObject);
        }
    }
}
