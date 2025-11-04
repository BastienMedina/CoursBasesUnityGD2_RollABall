using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    [SerializeField] private UpgradesDatas _upgradeSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0, _verticalMovement);
        _movement.Normalize();
        Vector3 velocity = _movement * _upgradeSpeed.value;
        velocity.y = _rb.linearVelocity.y;
        if (_rb != null)
        {
            _rb.linearVelocity = velocity;
        }
        else
        {
            Debug.LogError("No rigidbody attached");
        }
    }
}
