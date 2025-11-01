using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _deathScreen;
    [SerializeField] private RespawnManager _respawnManager;
    [SerializeField] private CanvasGroup _winScreen;
    
    void Start()
    {
        HideScreen(_deathScreen);
        HideScreen(_winScreen);
    }

    public void HideScreen(CanvasGroup screen)
    {
        if (screen != null)
        {
            screen.alpha = 0;
            screen.interactable = false;
            screen.blocksRaycasts = false;
        }
    }

    public void ShowScreen(CanvasGroup screen)
    {
        if (screen != null)
        {
            screen.alpha = 1;
            screen.interactable = true;
            screen.blocksRaycasts = true;
        }
    }

    public void RetryButton()
    {
        _respawnManager.RespawnPlayer();
        HideScreen(_deathScreen);
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
