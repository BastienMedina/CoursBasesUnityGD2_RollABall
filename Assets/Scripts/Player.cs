using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private RespawnManager _respawnManager;
    private int _life;
    [SerializeField] private CollectItems _collectItems;

    [SerializeField] private Slider _healthBarSlider;
    [SerializeField] private UpgradesDatas _upgradeLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPlayerLife();
        _healthBarSlider.maxValue = Mathf.RoundToInt(_upgradeLife.value);
        _healthBarSlider.value = _life;
        _collectItems = GameObject.Find("CollectManager").GetComponent<CollectItems>();
        _collectItems.ResetStats();
    }

    // Update is called once per frame
    void Update()
    {
        _healthBarSlider.maxValue = Mathf.RoundToInt(_upgradeLife.value);
    }

    public void ApplyDamage(int amount)
    {
        _life -= amount;
        _healthBarSlider.value = _life;
        PlayerDeath();
    }

    void PlayerDeath()
    {
        if (_life <= 0)
        {
            Destroy(gameObject);
            _respawnManager.PlayerDead();
        }
    }

    public void ResetPlayerLife()
    {
        _life = Mathf.RoundToInt(_upgradeLife.value);
    }
}
