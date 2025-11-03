using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textButtonTitleUpgrade01;
    [SerializeField] private TextMeshProUGUI _textButtonTitleUpgrade02;
    [SerializeField] private TextMeshProUGUI _textButtonTitleUpgrade03;
    [SerializeField] private TextMeshProUGUI _textButtonUnderUpgrade01;
    [SerializeField] private TextMeshProUGUI _textButtonUnderUpgrade02;
    [SerializeField] private TextMeshProUGUI _textButtonUnderUpgrade03;
    [SerializeField] private Button _ButtonUpgrade01;
    [SerializeField] private Button _ButtonUpgrade02;
    [SerializeField] private Button _ButtonUpgrade03;

    [SerializeField] private UpgradesDatas _upgradeSpeed;
    [SerializeField] private UpgradesDatas _upgradeLife;
    [SerializeField] private UpgradesDatas _upgradeFireRate;
    [SerializeField] private UpgradesDatas _upgradeDamages;
    [SerializeField] private UpgradesDatas _upgradeCoins;

    [SerializeField] private CanvasGroup _upgradeScreen;

    private List<int> _listIndexUpgrades;
    private List<UpgradesDatas> _listUpgrades;
    private int id = 3;

    void Update()
    {
        GenerateRamdomUpgradeNumber();
        ShowOrHideUpgradeScreen(false);
    }

    void Start()
    {
        _listUpgrades = new List<UpgradesDatas>
        {
            _upgradeSpeed,
            _upgradeLife,
            _upgradeFireRate,
            _upgradeDamages,
            _upgradeCoins
        };
        ShowOrHideUpgradeScreen(false);
    }

    void ChangeText(TextMeshProUGUI textRef, string textName)
    {
        textRef.text = textName;
    }

    void SetButtonUpgrade(UpgradesDatas _data, Button _button, TextMeshProUGUI _title, TextMeshProUGUI _description, Action<UpgradesDatas> _fonction, int indexList)
    {
        _title.text = _data.title;
        _description.text = _data.description;
        _button.onClick.AddListener(() => _fonction(_listUpgrades[_listIndexUpgrades[indexList]]));
    }

    public void UpgradeArguments(UpgradesDatas _data)
    {
        _data.value += _data.increaseData;
        ShowOrHideUpgradeScreen(false);
    }

    void ShowOrHideUpgradeScreen(bool _showScreen)
    {
        if (_showScreen)
        {
            Time.timeScale = 0f;
            id = 0;
            _upgradeScreen.alpha = 1f;
            _upgradeScreen.interactable = true;
            _upgradeScreen.blocksRaycasts = true;
            SetButtonUpgrade(_listUpgrades[_listIndexUpgrades[0]], _ButtonUpgrade01, _textButtonTitleUpgrade01, _textButtonUnderUpgrade01, UpgradeArguments, 0);
            SetButtonUpgrade(_listUpgrades[_listIndexUpgrades[1]], _ButtonUpgrade02, _textButtonTitleUpgrade02, _textButtonUnderUpgrade02, UpgradeArguments, 1);
            SetButtonUpgrade(_listUpgrades[_listIndexUpgrades[2]], _ButtonUpgrade03, _textButtonTitleUpgrade03, _textButtonUnderUpgrade03, UpgradeArguments, 2);
        }
        else
        {
            _upgradeScreen.alpha = 0f;
            _upgradeScreen.interactable = false;
            _upgradeScreen.blocksRaycasts = false;
            Time.timeScale = 1f;
            _listIndexUpgrades.Clear();
        }
    }

    void GenerateRamdomUpgradeNumber()
    {
        if (id < 3)
        {
            int index = UnityEngine.Random.Range(0, _listUpgrades.Count - 1);
            if (_listIndexUpgrades.Contains(index))
            {

            }
            else
            {
                _listIndexUpgrades.Add(index);
                id++;
            }
        }
    }

}
