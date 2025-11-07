// ============================================
// [PlayerAnimation.cs]
// Role : 플레이어의 애니메이션 상태 관리
// Input : PlayerController (애니메이션 트리거)
// Output : Animator (애니메이션 재생)
// Event : OnAnimationStateChanged
// ============================================

using UnityEngine;
using UnityEngine.Animations;
using System.Collections.Generic;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    void Start() => anim = GetComponent<Animator>();

    public void UpdateJumpAnimation(PlayerStatus status)
    {
        anim.SetTrigger(status.isJumping ? "jump" : "land"); // 점프 및 착지 애니메이션
    }

    public void UpdateMovementAnimation(PlayerStatus status)
    {
        anim.SetBool("isMoving", status.isMoving); // 이동 상태에 따른 애니메이션 변경
        
    }

    public void UpdateAttackAnimation(PlayerStatus status)
    {
        anim.SetBool("attack", status.isAttacking);
    }

    public void UpdateGroundAnimation(PlayerStatus status)
    {
      anim.SetBool("isGrounded", status.isGrounded);
    }
}
