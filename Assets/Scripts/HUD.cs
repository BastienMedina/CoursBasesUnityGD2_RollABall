using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Inventories _inventory;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _ammoText;

    // Update is called once per frame
    void Update()
    {
        TextAmmoUpdater();
        TextCoinsUpdater();
    }

    void TextAmmoUpdater()
    {
        _ammoText.text = _inventory.ammo.ToString();
    }

    void TextCoinsUpdater()
    {
        _coinsText.text = _collectibles._coins.ToString();
    }
}
