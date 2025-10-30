using UnityEngine;
using TMPro;

public class TextHUD : MonoBehaviour
{
    [SerializeField] private Collectibles _collectibles;
    [SerializeField] private TextMeshProUGUI _textHUD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _textHUD.text = "Coins : " + _collectibles._coins.ToString();
    }
}
