using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]private int ennemyValue = 1;

    private void OnCollisionEnter(Collision Collision)
    {
        if(Collision.gameObject.GetComponent<PlayerCollect>() != null)
        {
            Destroy(gameObject);
            Collision.gameObject.GetComponent<PlayerCollect>().UpdateScore(ennemyValue);
        }
            
    }
}
