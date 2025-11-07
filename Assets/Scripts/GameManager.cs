// ============================================
// [GameManager.cs]
// Role    : 게임 상태 및 점수 관리
// Input   : Unity Input System
// Output  : PlayerStatus (상태 갱신), UI (점수 및 생명 표시)
// Depends : SceneManagement
/*  게임 기본 오브젝트 구조
    [GameManager] ⇄ [PlayerState] → [UIManager]
                ↑
        (Scene / Enemy / Event)
*/
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;// 싱글톤 인스턴스
    public PlayerStatus playerStatus;
    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않음
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        playerStatus.OnPlayerDead += GameOver; // 플레이어 사망 이벤트
    }

    void GameOver() // 플레이어 사망 처리
    {
        playerStatus.currentHP -= 1;

        if (playerStatus.currentHP > 0)
        {
            RespawnPlayer();// 플레이어 리스폰 
        }
        else
        {
            SceneManager.LoadScene("GameOver"); // 게임오버 처리
        }
    }

    void RespawnPlayer() // 플레이어 리스폰 로직
    {
        // 예시: 현재 씬 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int value)
    {
        score += value; // UIManager에게도 점수 변경 알려주기 가능
        
    }
}