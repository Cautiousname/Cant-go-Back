// ============================================
// [PlayerStatus.cs]
// Role : 플레이어의 상태(HP, Ground, Move 등) 
//       **데이터 베이스 UI, 애니메이션, 전투 등에서 참조**
// Input : PlayerController (상태 갱신)
// Output : UIManager (HP 표시), GameManager (죽음 알림)
// Event : OnHealthChanged, OnPlayerDead
// isCursed 변수 추가(왼쪽 방향 이동 불가)
// ============================================

using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerStatus : MonoBehaviour
{
    public bool isGrounded;
    public bool isMoving;
    public bool isAttacking;
    public int currentHP;
    public int maxHP;
    public bool isCursed;

    // 생존 상태 변수

    // 이벤트: 상태 변경 시 UI 등에서 자동 반응 가능
    public event Action<int, int> OnHealthChanged;// 체력 변경 이벤트
    public event Action OnPlayerDead;// 플레이어 사망 이벤트

    public void TakeDamage(int damage) // 데미지 처리
    {
        currentHP = Mathf.Max(currentHP - damage, 0); // 체력 감소
        OnHealthChanged?.Invoke(currentHP, maxHP); // 체력 변경 알림
        if (currentHP <= 0)
        {
            OnPlayerDead?.Invoke();
        }
    }

    public void Heal(int amount) // 회복 처리
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        OnHealthChanged?.Invoke(currentHP, maxHP);
    }
    /*
    public void SetGrounded(bool grounded)
    {
        isGrounded = grounded;
    }

    public enum PlayerState { Idle, Run, Jump, Hit, Dead }
    PlayerState state;

    void ChangeState(PlayerState newState)
    {
        state = newState;
        animator.Play(newState.ToString());
    }
    */ 
}
