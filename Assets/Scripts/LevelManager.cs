using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNeWLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
