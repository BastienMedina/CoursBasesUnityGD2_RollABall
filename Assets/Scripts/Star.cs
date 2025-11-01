using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private CollectItems _collect;
    [SerializeField] private int StarAmount = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collect = GameObject.Find("CollectManager").gameObject.GetComponent<CollectItems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            _collect.AddCoins(StarAmount);
            Destroy(gameObject);
        }
    }
}
