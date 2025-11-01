using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private RespawnManager _respawnManager;
    private int _maxLife = 150;
    private int _life;

    [SerializeField] private Slider _healthBarSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _life = _maxLife;
        _healthBarSlider.maxValue = _maxLife;
        _healthBarSlider.value = _life;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
