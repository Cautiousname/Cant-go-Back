// ============================================
// [ButtonUI.cs]
// Role : 버튼 관리
// Input : 클릭
// Output : UI (메인 UI 버튼 동작)
// Event : button clicks
// ============================================

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("게임 시작 버튼이 클릭되었습니다.");
    }
    public void OpenSettings(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("설정 버튼이 클릭되었습니다.");
    }
    public void ReturnToMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("메인 메뉴 버튼이 클릭되었습니다.");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("게임 종료 버튼이 클릭되었습니다.");
    }

    public void Stage1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Stage 1: 클릭되었습니다.");
    }
    public void Stage2(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Stage 2: 클릭되었습니다.");
    }
    public void Stage3(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Stage 3: 클릭되었습니다.");
    }
        public void Stage4(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Stage 4: 클릭되었습니다.");
    }
}