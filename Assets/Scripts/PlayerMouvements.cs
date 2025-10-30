using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    [SerializeField] private float _speed;

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
        _movement = new Vector3(_horizontalMovement, _rb.linearVelocity.y, _verticalMovement);
        _movement.Normalize();
        if (_rb != null)
        {
            _rb.linearVelocity = _movement * _speed;
        }
        else
        {
            Debug.LogError("No rigidbody attached");
        }
    }
}
