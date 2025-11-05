using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _gunRotor;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private Inventories _inventory;
    [SerializeField] private CollectItems _collectManager;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _noBulletsSound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Shop _shop;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private UpgradesDatas _fireRateUpgrade;
    [SerializeField] private ButtonManager _uiManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<ButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LookCursor();
        Shoot();
    }

    void LookCursor()
    {
        Vector3 mousePos = Input.mousePosition; // recup la position du curseur sur l'ecran
        mousePos.z = Vector3.Distance(_mainCamera.transform.position, _gunRotor.transform.position); // on donne la profondeur sur l'axe z de la position de la sourie pour savoir 
                                                                                                     // sa position dans le monde
        Vector3 targetPos = _mainCamera.ScreenToWorldPoint(mousePos); // convertie la position du curseur de pixel de l'ecran en vecteur 3D
        Vector3 direction = targetPos - _gunRotor.transform.position; // calcule la distance entre le rotor du gun et le point de vis�e du curseur
        direction.y = 0; // bloque la vis�e perpendiculaire au sol
        _gunRotor.transform.rotation = Quaternion.LookRotation(direction); // fait tourn�e le rotor pour qu'il regarde dans la direction "direction" qui correspond au point du curseur dans le monde
    }

    void Shoot()
    {
        if(Input.GetMouseButtonUp(0))
        {
            CancelInvoke(nameof(LaunchBullet));
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (_uiManager.gamePause == false)
            {
                InvokeRepeating(nameof(LaunchBullet), 0f, _fireRateUpgrade.value);
            }
        }

    }

    void LaunchBullet()
    {
        if (_inventory.ammo > 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            _collectManager.AddAmmo(-1);
            _audioSource.PlayOneShot(_shootSound);
            _cameraShake.TriggerShake(0.1f, 0.05f);
            if (rb != null)
            {
                rb.linearVelocity = _bulletSpawnPoint.forward * _bulletSpeed;
            }
            Destroy(bullet, 3f);
        }
        else
        {
            _audioSource.PlayOneShot(_noBulletsSound);
        }
    }
}
