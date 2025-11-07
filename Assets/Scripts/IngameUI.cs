// ============================================
// [IngameUI.cs]
// Role : 게임 플래이 UI 관리
//       **PlayerController 직접 참조 하지X**
// Input : PlayerStatus (상태 정보)
// Output : UI (체력바, 사망 화면 등)
// Event : OnHealthChanged, OnPlayerDead
// ============================================

using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Text scoreText;

    private PlayerStatus playerStatus;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
        playerStatus = gameManager.playerStatus;

        playerStatus.OnHealthChanged += UpdateHPBar; //체력 변경 이벤트 구독
        UpdateHPBar(playerStatus.currentHP, playerStatus.maxHP);
        playerStatus.OnPlayerDead += PlayerDead; //사망 이벤트 구독
        UpdateScore(gameManager.score);
    }

    void UpdateHPBar(int current, int max) //체력바 업데이트
    {
        hpBar.value = (float)current / max;
    }

    public void UpdateScore(int score)//점수 업데이트
    {
        scoreText.text = $"Score: {score}";
    }

    private void PlayerDead()
    {
        // 플레이어 사망 처리 로직
        Debug.Log("플레이어가 사망했습니다.");
    }
}