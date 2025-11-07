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
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    // 생존 상태 변수
    public bool isGrounded; public bool isMoving; public bool isJumping; public bool isAttacking;
    public bool isCursed;
    public int CurrentHP => HP; public int MaxHP => 100;
    public int HP { get; private set; } = 100;
    public bool IsDead => HP <= 0; public bool isDead;
    

    // 이벤트 선언 (GameManager가 구독할 수 있음)
    public event Action<int> OnHPChanged;
    public event Action OnDeath;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        OnHPChanged?.Invoke(HP);

        if (HP <= 0)
        {
            HP = 0;
            OnDeath?.Invoke();
        }
    }
    public void Heal(int amount)
    {
        HP += amount;
        if (HP > 100) HP = 100;
        OnHPChanged?.Invoke(HP);
    }
    public void CursePlayer()
    {
        isCursed = true;
    }
    
}
