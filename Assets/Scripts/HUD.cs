using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Inventories _inventory;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private TextMeshProUGUI _coinsText;

    // Update is called once per frame
    void Update()
    {
        TextAmmoUpdater();
        TextCoinsUpdater();
        TextScoreUpdater();
    }

    void TextAmmoUpdater()
    {
        _ammoText.text = "Ammunitions : " + _inventory.ammo.ToString();
    }

    void TextCoinsUpdater()
    {
        _coinsText.text = "$ " + _collectibles._coins.ToString();
    }

    void TextScoreUpdater()
    {
        _scoreText.text = _collectibles.score.ToString();
    }
}
