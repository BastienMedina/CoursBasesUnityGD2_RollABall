using UnityEngine;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Inventories _inventory;

    public void AddCoins(int amount)
    {
        _collectibles._coins += amount;
    }

    public void AddAmmo(int amount)
    {
        _inventory.ammo += amount;
    }

    public void AddScore(int amount)
    {
        _collectibles.score += amount;
    }

    public void ResetStats()
    {
        _collectibles._coins = 0;
        _inventory.ammo = 100;
        _collectibles.score = 0;
    }
}
