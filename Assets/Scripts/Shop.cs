using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ammoPriceText;
    [SerializeField] private TextMeshProUGUI _fireRatePriceText;
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private Inventories _inventory;
    [SerializeField] private CanvasGroup _shopScreen;
    [SerializeField] private ButtonManager _uiManager;

    [SerializeField] private int _ammoPrice = 15;
    [SerializeField] private int _fireRatePrice = 20;
    [SerializeField] private Player _playerScript;

    private bool _canBuy = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseShop();
        _playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(_uiManager.gamePause)
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
            _playerScript.ResetPlayerLife();
        }
    }

    void OpenShop()
    {
        _shopScreen.alpha = 1;
        _shopScreen.interactable = true;
        _shopScreen.blocksRaycasts = true;
        Time.timeScale = 0;
        _uiManager.gamePause = true;
    }

    void CloseShop()
    {
        _shopScreen.alpha = 0;
        _shopScreen.interactable = false;
        _shopScreen.blocksRaycasts = false;
        Time.timeScale = 1;
        _uiManager.gamePause = false;
    }

    void ShowPrice(int price, TextMeshProUGUI text)
    {
        text.text = "$ " + price.ToString();
    }
}