using UnityEngine;

public class ClassicBullet : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private UpgradesDatas _upgradeDamage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            other.gameObject.GetComponent<Enemy>().UpdateLife(Mathf.RoundToInt(_upgradeDamage.value));
            _audioSource.PlayOneShot(_hitSound);
            Destroy(gameObject);
        }
    }
}
