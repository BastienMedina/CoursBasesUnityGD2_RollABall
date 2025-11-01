using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 0.1f;
    private int _life;
    [SerializeField] private int _maxLife = 100;
    [SerializeField] private CollectItems _collectManager;
    [SerializeField] private GameObject _starPrefab;

    [SerializeField] private Slider _sliderHealthBar;
    [SerializeField] private Transform _canvaHealthTransform;
    private Transform _mainCamera;

    [SerializeField] private int _damages = 25;

    private bool _isAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _life = _maxLife;
        _collectManager = GameObject.Find("CollectManager").gameObject.GetComponent<CollectItems>();
        _sliderHealthBar.maxValue = _maxLife;
        _sliderHealthBar.value = _life;
        _mainCamera = Camera.main.transform;
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
        
        HealthBarLook();
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
                _collectManager.AddScore(1);
                _isAlive = false;
            }
            Instantiate(_starPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void UpdateLife(int amount)
    {
        _life -= amount;
        _sliderHealthBar.value = _life;
        EnemyDeath();
    }

    void HealthBarLook()
    {
        if (_canvaHealthTransform != null && _mainCamera != null)
        {
            _canvaHealthTransform.LookAt(_canvaHealthTransform.position + _mainCamera.forward);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _player)
        {
            collision.gameObject.GetComponent<Player>().ApplyDamage(_damages);
        }
    }
}
