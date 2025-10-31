using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 0.1f;
    public int _life;
    [SerializeField] private int _maxLife = 100;
    [SerializeField] private CollectItems _collectManager;

    private bool _isAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _life = _maxLife;
        _collectManager = GameObject.Find("CollectManager").gameObject.GetComponent<CollectItems>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            EnemyFollow();
        }
        else
        {
            _player = GameObject.Find("Player");
        }
        
        EnemyDeath();
    }

    void EnemyFollow()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        transform.position += direction * _speed * Time.deltaTime;

        transform.LookAt(_player.transform.position);
    }

    void EnemyDeath()
    {
        if (_life <= 0)
        {
            if (_isAlive)
            {
                _collectManager.AddCoins(2);
                _isAlive = false;
            }
            Destroy(gameObject);
        }
    }

}
