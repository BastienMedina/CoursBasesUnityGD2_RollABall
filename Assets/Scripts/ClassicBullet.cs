using UnityEngine;

public class ClassicBullet : MonoBehaviour
{
    [SerializeField] private int _damages = 25;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponent<Enemy>()._life -= _damages;
        }
    }
}
