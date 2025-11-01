using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 0f;
    [SerializeField] private float _shakeMagnitude = 0.1f;
    [SerializeField] private float _dampingSpeed = 1f;
    private Vector3 _originalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shakeDuration > 0)
        {
            transform.localPosition = _originalPosition + Random.insideUnitSphere * _shakeMagnitude;
            _shakeDuration -= Time.deltaTime * _dampingSpeed;
        }
        else
        {
            _shakeDuration = 0f;
            transform.localPosition = _originalPosition;
        }
    }  
    
    public void TriggerShake(float Duration, float magnitude)
    {
        _shakeDuration = Duration;
        _shakeMagnitude = magnitude;
    }
}
