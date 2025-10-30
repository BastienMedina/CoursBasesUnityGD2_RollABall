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
}
