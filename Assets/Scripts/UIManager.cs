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

    public event System.Action<PlayerStatus> OnPlayerStateChanged;
    private void UpdateUI(PlayerStatus status)
    {
        // 플레이어 상태에 따른 UI 업데이트 로직
        GetComponent<Text>().text = "HP: " + status.currentHP + "/" + status.maxHP;
        GetComponent<Text>().text += "\nScore: " + gameManager.score;
        OnPlayerStateChanged?.Invoke(status);
    }

    public static void SettingMenu()
    {
        GameObject settingMenu = GameObject.Find("SettingMenu");
        if (settingMenu != null)
        {
            settingMenu.SetActive(true);
        }
        Debug.Log("설정 메뉴가 열렸습니다.");
    }
    

}
