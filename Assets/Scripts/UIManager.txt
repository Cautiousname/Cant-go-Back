// ============================================
// [UIManager.cs]
// Role : UI 관리
// Input : PlayerController (플레이어 상태)
// Output : UI (플레이어 상태에 따른 UI 업데이트)
// Event : OnPlayerStateChanged
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerStatus playerStatus;
    public IngameUI ingameUI;
    public ScenesManager scenesManager;

    string hpText;
    int scoreText;

    public event System.Action<PlayerStatus> OnPlayerStateChanged;
    public event System.Action<int> OnScoreChanged;

    private void Start()
    {
        if (ingameUI == null) ingameUI = FindObjectOfType<IngameUI>();
        if (gameManager == null) gameManager = FindObjectOfType<GameManager>();
        if (scenesManager == null) scenesManager = FindObjectOfType<ScenesManager>();
    }
    private void UpdateUI(PlayerStatus status)
    {
        // 플레이어 상태에 따른 UI 업데이트 로직
        OnPlayerStateChanged?.Invoke(status);
        Debug.Log("플레이어 상태에 따른 UI가 업데이트되었습니다.");
        ingameUI.UpdateHPBar(status.CurrentHP);
        ingameUI.UpdateScoreText(gameManager.Score);

    }

    public void LoadSettingMenu()
    {
        GameObject settingMenu = GameObject.Find("SettingMenu");
        if (settingMenu != null)
        {
            settingMenu.SetActive(true);
        }
        Debug.Log("설정 메뉴가 열렸습니다.");
    }

    public void MainMenu()
    {
        scenesManager.LoadMainMenu();
        Debug.Log("메인 메뉴로 이동합니다.");
    }
    public void LoadStageSelection()
    {
        scenesManager.LoadStageSelection();
        Debug.Log("스테이지 선택 화면으로 이동합니다.");
    }

}
