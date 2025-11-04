using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private CollectItems _collect;

    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _amplitude = 0.25f;
    [SerializeField] private float _frequency = 2f;
    [SerializeField] private UpgradesDatas _upgradeCoins;
    private Vector3 _startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _collect = GameObject.Find("CollectManager").gameObject.GetComponent<CollectItems>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CoinAnimation();
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            _collect.AddCoins(_upgradeCoins.value);
            Destroy(gameObject);
        }
    }

    void CoinAnimation()
    {
        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime, Space.World);
        float newY = _startPosition.y + Mathf.Sin(Time.time * _frequency) * _amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
