using UnityEngine;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;

    public void AddCoins(int amount)
    {
        _collectibles._coins += amount;
    }
}
