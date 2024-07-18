using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(currentScene.name);
    }

    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public static void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
