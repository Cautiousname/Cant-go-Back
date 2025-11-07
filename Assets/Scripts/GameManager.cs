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
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    public event System.Action<int> OnScoreChanged;

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChanged?.Invoke(score);
        }
    }

    void Start()
    {
        // PlayerStatus 이벤트 구독
        if (playerStatus != null)
        {
            playerStatus.OnHPChanged += HandleHPChanged;
            playerStatus.OnDeath += HandlePlayerDeath;
        }

        // UIManager 이벤트 구독
        UIManager uiManager = FindObjectOfType<UIManager>();


    }

    void HandleHPChanged(int newHP)
    {
        Debug.Log($"Player HP: {newHP}");
    }

    void HandlePlayerDeath()
    {
        Debug.Log("Player Dead → Game Over!");
        // 게임 오버 처리 로직
    }

        // 기존 코드

    // 점수 변수와 Score 프로퍼티 추가
   

}