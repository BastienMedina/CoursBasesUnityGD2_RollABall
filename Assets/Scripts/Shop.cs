using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoPriceText;
    [SerializeField] private TextMeshProUGUI _fireRatePriceText;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Inventories _inventory;
    [SerializeField] private WeaponsCaracteristics _gunCaracteristics;
    [SerializeField] private CanvasGroup _shopScreen;

    [SerializeField] private int _ammoPrice = 15;
    [SerializeField] private int _fireRatePrice = 20;

    private bool _canBuy = false;
    private bool _gamePaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseShop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(_gamePaused)
            {
                CloseShop();
            }
            else
            {
                OpenShop();
            }
        }
        ShowPrice(_ammoPrice, _ammoPriceText);
        ShowPrice(_fireRatePrice, _fireRatePriceText);
    }

    public void BuyAmmo(int quantity)
    {
        Buy(_ammoPrice);
        if (_canBuy)
        {
            _inventory.ammo += quantity;
            _canBuy = false;
        }
    }

    void Buy(int price)
    {
        if (_collectibles._coins >= price)
        {
            _collectibles._coins -= price;
            _canBuy = true;
        }
    }

    public void BuyFireRate()
    {
        Buy(_fireRatePrice);
        if (_canBuy)
        {
            _gunCaracteristics.fireRate -= 0.1f;
            if (_gunCaracteristics.fireRate <= 0 )
            {

            }
            _fireRatePrice += _fireRatePrice * 2;
        }
    }

    void OpenShop()
    {
        _shopScreen.alpha = 1;
        _shopScreen.interactable = true;
        _shopScreen.blocksRaycasts = true;
        Time.timeScale = 0;
        _gamePaused = true;
    }

    void CloseShop()
    {
        _shopScreen.alpha = 0;
        _shopScreen.interactable = false;
        _shopScreen.blocksRaycasts = false;
        Time.timeScale = 1;
        _gamePaused = false;
    }

    void ShowPrice(int price, TextMeshProUGUI text)
    {
        text.text = "$ " + price.ToString();
    }
}
