using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _deathScreen;
    [SerializeField] private RespawnManager _respawnManager;
    [SerializeField] private CanvasGroup _winScreen;
    [SerializeField] private Shop _shop;
    [SerializeField] private CanvasGroup _pauseScreen;
    [SerializeField] private CollectItems _collectItems;
    
    void Start()
    {
        HideScreen(_deathScreen);
        HideScreen(_winScreen);
        HideScreen(_pauseScreen);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_shop._gamePaused == false)
            {
                ShowScreen(_pauseScreen);
                Time.timeScale = 0;
                _shop._gamePaused = true;
            }
            else
            {
                RemovePause();
            }
        }
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

    public void RemovePause()
    {
        HideScreen(_pauseScreen);
        Time.timeScale = 1;
        _shop._gamePaused = false;
    }

    public void ResetLevel(string sceneName)
    {
        _collectItems.ResetStats();
        LoadNewScene(sceneName);
        Time.timeScale = 1;
        _shop._gamePaused = false;
    }

}
