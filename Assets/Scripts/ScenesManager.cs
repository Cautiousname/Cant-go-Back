// ============================================
// [ScenesManager.cs]
// Role : 씬 관리
// Input : 
// Output : 
// Event : 
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void LoadStageSelection()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameoverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
public void LoadLevel(string levelName)
{
    SceneManager.LoadScene(levelName);
}
}