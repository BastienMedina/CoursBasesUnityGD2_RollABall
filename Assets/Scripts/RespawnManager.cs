using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private ButtonManager _buttonManager;
    [SerializeField] private CanvasGroup _deathScreen;
    [SerializeField] private Collectibles _collectible;
    [SerializeField] private Inventories _inventory;


    public void RespawnPlayer()
    {
        GameObject currentPlayer = Instantiate(_playerPrefab, _playerSpawnPoint.position, _playerSpawnPoint.rotation);
        currentPlayer.name = _playerPrefab.name;
        _cameraFollow.SetTarget(currentPlayer);
        _inventory.ammo = 100;
        _collectible._coins = 0;
    }

    public void PlayerDead()
    {
        _buttonManager.ShowScreen(_deathScreen);
    }
}
