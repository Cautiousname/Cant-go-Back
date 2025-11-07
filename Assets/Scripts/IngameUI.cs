// ============================================
// [IngameUI.cs]
// Role : 게임 플레이 UI 관리
// Input : PlayerStatus (상태 정보)
// Output : UI (체력바, 점수, 사망 화면 등)
// Event : OnHealthChanged, OnPlayerDead
// ============================================

using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Slider hpBar;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private PlayerStatus playerStatus;
    private GameManager gameManager;

    private void Start()
    {
        // 싱글톤이나 Find로 참조 (상황에 따라 DI로 대체 가능)
        playerStatus = FindObjectOfType<PlayerStatus>();
        gameManager = FindObjectOfType<GameManager>();

        // PlayerStatus 이벤트 구독
        if (playerStatus != null)
        {
            playerStatus.OnHPChanged += UpdateHPBar;
            playerStatus.OnDeath += ShowGameOverScreen;
        }

        // GameManager 이벤트 구독 (예: 점수 갱신)
        if (gameManager != null)
        {
            gameManager.OnScoreChanged += UpdateScoreText;
        }

        // 초기값 설정
        UpdateHPBar(playerStatus.CurrentHP);
        UpdateScoreText(gameManager.Score);
    }

    private void OnDestroy()
    {
        // 이벤트 구독 해제 (메모리 릭 방지)
        if (playerStatus != null)
        {
            playerStatus.OnHPChanged -= UpdateHPBar;
            playerStatus.OnDeath -= ShowGameOverScreen;
        }

        if (gameManager != null)
        {
            gameManager.OnScoreChanged -= UpdateScoreText;
        }
    }

    // Overload for Action<int> delegate
    public void UpdateHPBar(int currentHP)
    {
        if (hpBar != null && playerStatus != null)
            hpBar.value = (float)currentHP / playerStatus.MaxHP;
    }

    public void UpdateScoreText(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

    public void ShowGameOverScreen()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

}
