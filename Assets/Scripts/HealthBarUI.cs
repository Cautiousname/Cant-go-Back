// ============================================
// [HealthBarUI]
// 필요한 버튼들 추가:메뉴 -소리설정 재시작 스테이지
// 채력바 슬라이더
// 불러온것: 플레이어 스탯
// ============================================
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerStatus playerStatus;

    void Update()
    {   
        healthSlider.value = playerStatus.currentHP; //채력바 갱신
    }

    /// <summary> // 게임 종료 </summary>
    public void OnExitButtonClicked()
    {
        
        Application.Quit();
    }
}